﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.40607.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Sideris.Properties {
    
    
    sealed partial class Settings : System.Configuration.ApplicationSettingsBase {
        
        private static Settings m_Value;
        
        private static object m_SyncObject = new object();
        
        [System.Diagnostics.DebuggerNonUserCode()]
        public static Settings Value {
            get {
                if ((Settings.m_Value == null)) {
                    System.Threading.Monitor.Enter(Settings.m_SyncObject);
                    if ((Settings.m_Value == null)) {
                        try {
                            Settings.m_Value = new Settings();
                        }
                        finally {
                            System.Threading.Monitor.Exit(Settings.m_SyncObject);
                        }
                    }
                }
                return Settings.m_Value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("yoda:13060")]
        public string DiscoveryServer {
            get {
                return ((string)(this["DiscoveryServer"]));
            }
            set {
                this["DiscoveryServer"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("")]
        public string SharedFolder {
            get {
                return ((string)(this["SharedFolder"]));
            }
            set {
                this["SharedFolder"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IncludeSubfolders {
            get {
                return ((bool)(this["IncludeSubfolders"]));
            }
            set {
                this["IncludeSubfolders"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoConnect {
            get {
                return ((bool)(this["AutoConnect"]));
            }
            set {
                this["AutoConnect"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("8080")]
        public ushort Port {
            get {
                return ((ushort)(this["Port"]));
            }
            set {
                this["Port"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("Sideris")]
        public string ComputerName {
            get {
                return ((string)(this["ComputerName"]));
            }
            set {
                this["ComputerName"] = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.UserScopedSettingAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("C:\\Downloads")]
        public string DownloadsFolder {
            get {
                return ((string)(this["DownloadsFolder"]));
            }
            set {
                this["DownloadsFolder"] = value;
            }
        }
    }
}