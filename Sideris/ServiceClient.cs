#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System.Net;
using System.Timers;

#endregion

namespace Sideris
{
    public class ServiceClient : Component
    {
        private FilesDataSet files;
        private Timer pingTimer;

        public FilesDataSet Files
        {
            get { return files; }
            set { files = value; }
        }

        private SiderisService.SiderisService service;

        private ushort port
        {
            get { return Sideris.Properties.Settings.Value.Port; }
        }

        private void UpdateUrl()
        {
            string url = String.Format(
                "http://{0}/SiderisServer/SiderisService.asmx",
                Sideris.Properties.Settings.Value.DiscoveryServer);
            service.Url = url;
        }

        public ServiceClient()
        {
            service = new SiderisService.SiderisService();

            pingTimer = new Timer();
            pingTimer.Enabled = false;
            pingTimer.AutoReset = false;
            pingTimer.Elapsed += new ElapsedEventHandler(pingTimer_Elapsed);
        }

        public class ServiceExceptionEventArgs : EventArgs
        {
            private Exception exception;

            public Exception Exception
            {
                get { return exception; }
            }

            public ServiceExceptionEventArgs(Exception e)
            {
                this.exception = e;
            }
        }

        public delegate void ServiceExceptionEventHandler(object sender,
            ServiceExceptionEventArgs e);

        public event ServiceExceptionEventHandler ServiceException;

        protected virtual void OnServiceException(ServiceExceptionEventArgs e)
        {
            if(ServiceException != null)
            {
                ServiceException(this, e);
            }
        }


        //
        // Register
        //

        public enum RegistrationState
        {
            Unregistered,
            Registered
        }

        public class RegistrationStateChangedEventArgs : System.EventArgs
        {
            private RegistrationState state;

            public RegistrationState State
            {
                get { return state; }
            }

            public RegistrationStateChangedEventArgs(RegistrationState state)
            {
                this.state = state;
            }
        }

        public delegate void RegistrationStateChangedEventHandler(
            object sender,
            RegistrationStateChangedEventArgs e);

        public event RegistrationStateChangedEventHandler StateChanged;

        protected virtual void OnRegistrationStateChanged(RegistrationStateChangedEventArgs e)
        {
            if(StateChanged != null)
            {
                StateChanged(this, e);
            }
        }

        public void Register()
        {
            FilesDataSet.SharesRow[] rows = files.Shares.Select()
                as FilesDataSet.SharesRow[];
            SiderisService.File[] shares = new SiderisService.File[rows.Length];

            for(int i = 0; i < shares.Length; i++)
            {
                shares[i] = new SiderisService.File();
                shares[i].Hash = rows[i].Hash;
                string[] parts = rows[i].FullName.Split('\\');
                shares[i].Name = parts[parts.Length - 1];
                shares[i].Size = rows[i].Size;
            }

            UpdateUrl();

            string name = Sideris.Properties.Settings.Value.ComputerName;

            try
            {
                service.BeginRegister(name, port, shares,
                    new AsyncCallback(this.EndRegister), null);
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
        }

        private void EndRegister(IAsyncResult ar)
        {
            DateTime expiry;
            try
            {
                service.EndRegister(ar, out expiry);

                SetPingTimer(expiry);

                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Registered));
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
        }
        private void SetPingTimer(DateTime expiry)
        {
            TimeSpan interval = expiry - DateTime.Now;
            pingTimer.Interval = interval.TotalMilliseconds / 2.0;
            pingTimer.Start();
        }


        //
        // Search
        //

        public class SearchEventArgs : EventArgs
        {
            protected string searchText;

            public string SearchText
            {
                get { return searchText; }
            }

            public SearchEventArgs(string searchText)
            {
                this.searchText = searchText;
            }
        }

        public delegate void SearchEventHandler(object sender, SearchEventArgs e);

        public event SearchEventHandler SearchStarted;

        protected virtual void OnSearchStarted(SearchEventArgs e)
        {
            if(SearchStarted != null)
            {
                SearchStarted(this, e);
            }
        }

        public class SearchProgressChangedEventArgs : SearchEventArgs
        {
            private int progressPercentage;

            public int ProgressPercentage
            {
                get { return progressPercentage; }
            }

            public SearchProgressChangedEventArgs(string searchText,
                int progressPercentage) : base(searchText)
            {
                this.progressPercentage = progressPercentage;
            }
        }

        public delegate void SearchProgressChangedEventHandler(object sender,
            SearchProgressChangedEventArgs e);

        public event SearchProgressChangedEventHandler SearchProgressChanged;

        protected virtual void OnSearchProgressChanged(SearchProgressChangedEventArgs e)
        {
            if(SearchProgressChanged != null)
            {
                SearchProgressChanged(this, e);
            }
        }

        public class ResultsAvailableEventArgs : SearchEventArgs
        {
            private SiderisService.File[] files;

            public SiderisService.File[] Files
            {
                get { return files; }
            }

            public ResultsAvailableEventArgs(string searchText,
                SiderisService.File[] files) : base(searchText)
            {
                this.files = files;
            }
        }

        public delegate void ResultsAvailableEventHandler(
            object sender,
            ResultsAvailableEventArgs e);

        public event ResultsAvailableEventHandler ResultsAvailable;

        protected virtual void OnResultsAvailable(ResultsAvailableEventArgs e)
        {
            if(ResultsAvailable != null)
            {
                ResultsAvailable(this, e);
            }
        }

        public void Search(string text)
        {
            UpdateUrl();

            try
            {
                service.BeginSearchByName(port, text,
                    new AsyncCallback(this.SearchHashes), text);
            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
        }

        private void SearchHashes(IAsyncResult ar)
        {
            string text = ar.AsyncState as string;
            SiderisService.File[] files;

            try
            {
                files = service.EndSearchByName(ar);
            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                return;
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                return;
            }

            OnSearchStarted(new SearchEventArgs(text));
            OnResultsAvailable(new ResultsAvailableEventArgs(text, files));

            int count = files.Length;
            int current = 0;
            foreach(SiderisService.File file in files)
            {
                try
                {
                    service.BeginSearchByHash(port, file.Hash,
                        new AsyncCallback(this.EndSearch), text);
                    int progress = ++current * 100 / count;
                    OnSearchProgressChanged(
                        new SearchProgressChangedEventArgs(text, progress));
                }
                catch(WebException e)
                {
                    OnServiceException(new ServiceExceptionEventArgs(e));
                }
                catch(SoapException e)
                {
                    OnServiceException(new ServiceExceptionEventArgs(e));
                }
            }
        }

        public void SearchByHash(string hash)
        {
            UpdateUrl();

            try
            {
                service.BeginSearchByHash(port, hash,
                    new AsyncCallback(this.EndSearch), String.Empty);
                OnSearchStarted(new SearchEventArgs(String.Empty));

            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
        }

        private void EndSearch(IAsyncResult ar)
        {
            string text = ar.AsyncState as string;
            SiderisService.File[] files;

            try
            {
                files = service.EndSearchByHash(ar);
                OnResultsAvailable(new ResultsAvailableEventArgs(text, files));
            }
            catch(WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
            catch(SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
        }

        void pingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateUrl();

            DateTime expiry;
            bool stillRegistered = false;

            try
            {
                stillRegistered = service.Ping(port, out expiry);
            }
            catch(WebException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
            catch(SoapException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
            finally
            {
                if(stillRegistered)
                {
                    SetPingTimer(expiry);
                }
                else
                {
                    OnRegistrationStateChanged(
                        new RegistrationStateChangedEventArgs(
                        RegistrationState.Unregistered));
                }
            }
        }
    }
}
