using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System.Net;
using System.IO;
using System.Timers;

namespace Sideris
{
    public class ServiceClient : Component
    {
        private SiderisService.SiderisService service;
        private System.Windows.Forms.Timer pingTimer;
        private IContainer components;
        private FilesDataSet files;
        public FilesDataSet Files
        {
            get { return files; }
            set { files = value; }
        }

        private ushort Port
        {
            get { return (ushort)Sideris.Properties.Settings.Default.Port; }
        }

        private void UpdateUrl()
        {
            string url = String.Format(
                "http://{0}/SiderisStellar/SiderisService.asmx",
                Sideris.Properties.Settings.Default.DiscoveryServer);
            service.Url = url;
        }

        public ServiceClient()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pingTimer = new System.Windows.Forms.Timer(this.components);
            this.service = new Sideris.SiderisService.SiderisService();
            // 
            // pingTimer
            // 
            this.pingTimer.Tick += new System.EventHandler(this.pingTimer_Tick);
            // 
            // service
            // 
            this.service.Url = "http://localhost:1498/SiderisStellar/SiderisService.asmx";
            this.service.UseDefaultCredentials = true;
            this.service.UnregisterCompleted += new Sideris.SiderisService.UnregisterCompletedEventHandler(this.service_UnregisterCompleted);
            this.service.SearchByNameCompleted += new Sideris.SiderisService.SearchByNameCompletedEventHandler(this.service_SearchByNameCompleted);
            this.service.SearchByHashCompleted += new Sideris.SiderisService.SearchByHashCompletedEventHandler(this.service_SearchByHashCompleted);
            this.service.RegisterCompleted += new Sideris.SiderisService.RegisterCompletedEventHandler(this.service_RegisterCompleted);

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
            if (ServiceException != null)
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
            if (StateChanged != null)
            {
                StateChanged(this, e);
            }
        }

        public void Register()
        {
            FilesDataSet.SharesRow[] rows = files.Shares.Select()
                as FilesDataSet.SharesRow[];
            SiderisService.File[] shares = new SiderisService.File[rows.Length];

            for (int i = 0; i < shares.Length; i++)
            {
                shares[i] = new SiderisService.File();
                shares[i].Hash = rows[i].Hash;
                shares[i].Name = Path.GetFileName(rows[i].FullName);
                shares[i].Size = rows[i].Size;
            }

            UpdateUrl();

            string name = Sideris.Properties.Settings.Default.ComputerName;

            try
            {
                service.RegisterAsync(name, this.Port, shares);
            }
            catch (SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
            catch (WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(RegistrationState.Unregistered));
            }
        }

        private void service_RegisterCompleted(object sender, Sideris.SiderisService.RegisterCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                SetPingTimer(e.expires);
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(
                    RegistrationState.Registered));
            }
            else
            {
                OnServiceException(new ServiceExceptionEventArgs(e.Error));
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(
                    RegistrationState.Unregistered));
            }
        }

        private void SetPingTimer(DateTime expiry)
        {
            TimeSpan interval = expiry - DateTime.Now;
            pingTimer.Interval = (int)(interval.TotalMilliseconds / 2.0);
            pingTimer.Start();
        }

        private void pingTimer_Tick(object sender, EventArgs e)
        {
            UpdateUrl();

            try
            {
                DateTime expiry;
                if (service.Ping(this.Port, out expiry))
                {
                    SetPingTimer(expiry);
                }
            }
            catch (WebException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
            catch (SoapException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
            finally
            {
                OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(
                    RegistrationState.Unregistered));
            }
        }

        public void Unregister()
        {
            try
            {
                service.UnregisterAsync(this.Port);
            }
            catch (WebException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
            catch (SoapException ex)
            {
                OnServiceException(new ServiceExceptionEventArgs(ex));
            }
        }

        private void service_UnregisterCompleted(object sender, Sideris.SiderisService.UnregisterCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result)
                {
                    OnRegistrationStateChanged(new RegistrationStateChangedEventArgs(
                        RegistrationState.Unregistered));
                }
            }
            else
            {
                OnServiceException(new ServiceExceptionEventArgs(e.Error));
            }
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
            if (SearchStarted != null)
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
                int progressPercentage)
                : base(searchText)
            {
                this.progressPercentage = progressPercentage;
            }
        }

        public delegate void SearchProgressChangedEventHandler(object sender,
            SearchProgressChangedEventArgs e);

        public event SearchProgressChangedEventHandler SearchProgressChanged;

        protected virtual void OnSearchProgressChanged(SearchProgressChangedEventArgs e)
        {
            if (SearchProgressChanged != null)
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
                SiderisService.File[] files)
                : base(searchText)
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
            if (ResultsAvailable != null)
            {
                ResultsAvailable(this, e);
            }
        }

        public void Search(string text)
        {
            UpdateUrl();

            try
            {
                service.SearchByNameAsync(this.Port, text, text);
            }
            catch (WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
            catch (SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
        }

        private void service_SearchByNameCompleted(object sender, Sideris.SiderisService.SearchByNameCompletedEventArgs e)
        {
            string text = (string)e.UserState;
            SiderisService.File[] files;

            if (e.Error == null)
            {
                files = e.Result;
            }
            else
            {
                OnServiceException(new ServiceExceptionEventArgs(e.Error));
                return;
            }

            OnSearchStarted(new SearchEventArgs(text));

            if (files.Length > 0)
            {
                OnResultsAvailable(
                    new ResultsAvailableEventArgs(text, files));
            }
            else
            {
                OnSearchProgressChanged(
                    new SearchProgressChangedEventArgs(text, 100));
            }

            int count = files.Length;
            int current = 0;
            foreach (SiderisService.File file in files)
            {
                try
                {
                    service.SearchByHashAsync(this.Port, file.Hash, text);
                    int progress = ++current * 100 / count;
                    OnSearchProgressChanged(new SearchProgressChangedEventArgs(text, progress));
                }
                catch (WebException ex)
                {
                    OnServiceException(new ServiceExceptionEventArgs(ex));
                }
                catch (SoapException ex)
                {
                    OnServiceException(new ServiceExceptionEventArgs(ex));
                }
            }
        }

        public void SearchByHash(string hash)
        {
            UpdateUrl();

            try
            {
                service.SearchByHashAsync(this.Port, hash, String.Empty);
                OnSearchStarted(new SearchEventArgs(String.Empty));

            }
            catch (WebException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
            catch (SoapException e)
            {
                OnServiceException(new ServiceExceptionEventArgs(e));
            }
        }

        private void service_SearchByHashCompleted(object sender, Sideris.SiderisService.SearchByHashCompletedEventArgs e)
        {
            string text = (string)e.UserState;
            SiderisService.File[] files;

            if(e.Error == null)
            {
                files = e.Result;
                OnResultsAvailable(new ResultsAvailableEventArgs(text, files));
            }
            else
            {
                OnServiceException(new ServiceExceptionEventArgs(e.Error));
            }
        }
    }
}
