#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Threading;

#endregion

namespace Sideris
{
    public class FolderScanner : Component
    {
        public enum Action
        {
            Added,
            HashUpdated,
            DuplicateDeleted,
            DuplicateIgnored
        }

        public class FileUpdatedEventArgs : EventArgs
        {
            private Action action;

            public Action Action
            {
                get { return action; }
            }

            private FileInfo fileInfo;

            public FileInfo FileInfo
            {
                get { return fileInfo; }
            }

            public FileUpdatedEventArgs(FileInfo info, Action action)
            {
                this.fileInfo = info;
                this.action = action;
            }
        }

        public delegate void FileUpdatedEventHandler(object sender,
            FileUpdatedEventArgs e);

        public event FileUpdatedEventHandler FileUpdated;

        protected virtual void OnFileUpdated(FileUpdatedEventArgs e)
        {
            if(FileUpdated != null)
            {
                FileUpdated(this, e);
            }
        }

        private FilesDataSet files;

        public FilesDataSet Files
        {
            get { return files; }
            set { files = value; }
        }

        public FolderScanner()
        {

        }

        public void Scan()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.StartScan));
        }

        private void StartScan(object state)
        {
            string sharedFolder;
            bool subfolders;

            lock(Properties.Settings.Value)
            {
                sharedFolder = Properties.Settings.Value.SharedFolder;
                subfolders = Properties.Settings.Value.IncludeSubfolders;
            }

            // If the share directory does not exist, silently get out.
            if(!Directory.Exists(sharedFolder))
                return;

            FilesDataSet.SharesDataTable shares = files.Shares;

            // Set the Keep column of all files to false.
            // Whenever we encounter a file, the Keep column will
            // be set to true. This way, deleted files will be removed
            // from the database.
            foreach(FilesDataSet.SharesRow row in shares.Rows)
            {
                row.Keep = false;
            }

            ScanFolder(new DirectoryInfo(sharedFolder), subfolders);

            // Delete rows for all files that do not exist anymore,
            // or are not shared anymore.
            DataRow[] rows = shares.Select("Keep = false");
            foreach(DataRow row in rows)
            {
                row.Delete();
            }

            shares.AcceptChanges();
        }

        /// <summary>
        /// Scan a directory, and optionally subdirectories,
        /// for files to share.
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo for the directory to scan.</param>
        /// <param name="subfolders">Whether to scan subfolders.</param>
        private void ScanFolder(DirectoryInfo dirInfo, bool subfolders)
        {
            FileSystemInfo[] infos = dirInfo.GetFileSystemInfos();

            foreach(FileSystemInfo info in infos)
            {
                if(subfolders && info is DirectoryInfo)
                {
                    ScanFolder(info as DirectoryInfo, true);
                }
                else if(info is FileInfo)
                {
                    ProcessFile(info as FileInfo);
                }
            }
        }

        /// <summary>
        /// Update or add an entry for a file in the shared files
        /// database.
        /// </summary>
        /// <param name="info">FileInfo for the file to process.</param>
        private void ProcessFile(FileInfo info)
        {
            FilesDataSet.SharesDataTable shares = files.Shares;
            Action action;
            string hash;

            // See if this file is already in the database.
            FilesDataSet.SharesRow row = shares.FindByFullName(info.FullName);
            
            if(row != null)
            {
                // The file was found, so keep this row.
                row.Keep = true;

                // Update the hash if this file was modified since we
                // last saw it.
                if(row.LastModified < info.LastWriteTime)
                {
                    hash = ComputeHashForFile(info.FullName);

                    // Delete the row if this file is now a duplicate.
                    if(shares.Select("Hash = '" + hash + "'").Length > 0)
                    {
                        row.Delete();
                        action = Action.DuplicateDeleted;
                    }
                    else
                    {
                        // File modified, update the hash.
                        row.Hash = hash;
                        action = Action.HashUpdated;
                    }
                }
                else
                {
                    // This file was already in the database and
                    // has not been modified. 
                    return;
                }
            }
            else
            {
                hash = ComputeHashForFile(info.FullName);

                // Don't add this file if this is a duplicate.
                if(shares.Select("Hash = '" + hash + "'").Length > 0)
                {
                    action = Action.DuplicateIgnored;
                }
                else
                {
                    // This is a new file, add it.
                    shares.AddSharesRow(info.FullName, hash,
                        info.LastWriteTime, info.Length, true);
                    action = Action.Added;
                }
            }

            OnFileUpdated(new FileUpdatedEventArgs(info, action));
        }

        /// <summary>
        /// Compute the SHA1 has for a file.
        /// </summary>
        /// <param name="file">Full path of the file to hash.</param>
        /// <returns>Hex representation of the hash.</returns>
        private string ComputeHashForFile(string file)
        {
            // Compute the hash.
            SHA1Managed sha1 = new SHA1Managed();
            byte[] bytes = sha1.ComputeHash(File.OpenRead(file));

            // Turn the hash into a hex string.
            char[] hexDigits = {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

            char[] chars = new char[bytes.Length * 2];
            for(int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }
    }
}
