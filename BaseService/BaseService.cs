using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace BaseService
{
    public static class BaseService
    {
        private static string updateServer;
        private static string connectionString;
        private static string libraryName;
        private static string preFix;
        private static int connectionLoad = 0;
        private static string odbcName;
        private static string applicationPath;
        private static StructUser applicationUser;
        private static List<StructUserRight> applicationRight;
        private static string smgHost;
        private static string smgService;
        private static string smgConfiguration;
        private static string smgPip;
        private static string smgConverter;
        private static string smgLibrarylistentry;
        private static string smgDatabase;
        private static List<string> applicationIps;
        private static int applicationLock;
        private static Form loginFrm;
        private static bool haveMainFrame = false;
        private static int queryWindow = 0;

        public static string UpdateServer
        {
            get { return BaseService.updateServer; }
            set { BaseService.updateServer = value; }
        }

        public static string ConnectionString
        {
            get { return BaseService.connectionString; }
            set { BaseService.connectionString = value; }
        }

        public static string LibraryName
        {
            get { return BaseService.libraryName; }
            set { BaseService.libraryName = value; }
        }

        public static string PreFix
        {
            get { return BaseService.preFix; }
            set { BaseService.preFix = value; }
        }

        public static int ConnectionLoad
        {
            get { return BaseService.connectionLoad; }
            set { BaseService.connectionLoad = value; }
        }

        public static string OdbcName
        {
            get { return BaseService.odbcName; }
            set { BaseService.odbcName = value; }
        }

        public static string ApplicationPath
        {
            get { return BaseService.applicationPath; }
            set { BaseService.applicationPath = value; }
        }

        public static StructUser ApplicationUser
        {
            get { return BaseService.applicationUser; }
            set { BaseService.applicationUser = value; }
        }

        public static List<StructUserRight> ApplicationRight
        {
            get { return BaseService.applicationRight; }
            set { BaseService.applicationRight = value; }
        }

        public static string SmgHost
        {
            get { return BaseService.smgHost; }
            set { BaseService.smgHost = value; }
        }

        public static string SmgService
        {
            get { return BaseService.smgService; }
            set { BaseService.smgService = value; }
        }

        public static string SmgConfiguration
        {
            get { return BaseService.smgConfiguration; }
            set { BaseService.smgConfiguration = value; }
        }

        public static string SmgPip
        {
            get { return BaseService.smgPip; }
            set { BaseService.smgPip = value; }
        }

        public static string SmgConverter
        {
            get { return BaseService.smgConverter; }
            set { BaseService.smgConverter = value; }
        }

        public static string SmgLibrarylistentry
        {
            get { return BaseService.smgLibrarylistentry; }
            set { BaseService.smgLibrarylistentry = value; }
        }

        public static string SmgDatabase
        {
            get { return BaseService.smgDatabase; }
            set { BaseService.smgDatabase = value; }
        }

        public static List<string> ApplicationIps
        {
            get { return BaseService.applicationIps; }
            set { BaseService.applicationIps = value; }
        }

        public static int ApplicationLock
        {
            get { return BaseService.applicationLock; }
            set { BaseService.applicationLock = value; }
        }

        public static Form LoginFrm
        {
            get { return BaseService.loginFrm; }
            set { BaseService.loginFrm = value; }
        }

        public static Form Loginnew
        {
            get { return BaseService.loginFrm; }
            set { BaseService.loginFrm = value; }
        }

        public static bool HaveMainFrame
        {
            get { return BaseService.haveMainFrame; }
            set { BaseService.haveMainFrame = value; }
        }

        public static int QueryWindow
        {
            get { return BaseService.queryWindow; }
            set { BaseService.queryWindow = value; }
        }

        public static bool Init(string xmlFile)
        {
            try
            {
                applicationIps = new List<string>();

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);
                for (int i = 0; i < xmldoc.ChildNodes[1].ChildNodes.Count; i++)
                {
                    switch (xmldoc.ChildNodes[1].ChildNodes[i].Name)
                    {
                        case "UpdateServer":
                            updateServer = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "ConnectionString":
                            connectionString = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "LibraryName":
                            libraryName = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "PreFix":
                            preFix = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "ConnectionLoad":
                            connectionLoad = System.Convert.ToInt32(xmldoc.ChildNodes[1].ChildNodes[i].InnerText);
                            break;
                        case "Host":
                            smgHost = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Service":
                            smgService = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Configuration":
                            smgConfiguration = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Pip":
                            smgPip = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Converter":
                            smgConverter = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Librarylistentry":
                            smgLibrarylistentry = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "Database":
                            smgDatabase = xmldoc.ChildNodes[1].ChildNodes[i].InnerText;
                            break;
                        case "SystemIps":
                            for (int j = 0; j < xmldoc.ChildNodes[1].ChildNodes[i].ChildNodes.Count; j++)
                            {
                                applicationIps.Add(xmldoc.ChildNodes[1].ChildNodes[i].ChildNodes[j].InnerText);
                            }
                            break;
                        case "ApplicationLock":
                            applicationLock = System.Convert.ToInt32(xmldoc.ChildNodes[1].ChildNodes[i].InnerText);
                            break;
                        case "QueryWindow":
                            queryWindow = System.Convert.ToInt32(xmldoc.ChildNodes[1].ChildNodes[i].InnerText);
                            break;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string EncryptPassword(string password)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(password));
        }
    }

    public class StructUser
    {
        public string SUSER;
        public string SPWD;
        public string SNAME;
        public int STYPE;
        public string SDEPT;
        public string STEXT;
        public int SUSED;
        public decimal SMNDT;
        public decimal SMNTM;
        public string SMNUS;
        public decimal SENDT;
        public decimal SENTM;
        public string SENUS;
    }

    public class StructUserRight
    {
        public int ModuleID;
        public string ModuleName;
        public int ModuleParentID;
        public string ModuleNameSpace;
        public string ModuleClassName;
        public RightModuleType ModuleType;
        public string ModuleButtonName;
    }

    public class StructModule
    {
        public int MID;
        public string MNAME;
        public int MPID;
        public string MSPAC;
        public string MCLAS;
        public int MTYPE;
        public int MBUBB;
        public string MTEXT;
        public int MUSED;
        public decimal MMNDT;
        public decimal MMNTM;
        public string MMNUS;
        public decimal MENDT;
        public decimal MENTM;
        public string MENUS;
    }

    public struct StructRight
    {
        public string RUID;
        public int RMID;
        public string RNAME;
        public string RTEXT;
        public int RUSED;
        public decimal RMNDT;
        public decimal RMNTM;
        public string RMNUS;
        public decimal RENDT;
        public decimal RENTM;
        public string RENUS;
    }

    public class StructAccess
    {
        public string ANAME;
        public string AUSER;
        public string AMNME;
        public decimal ADATE;
        public decimal ATIME;
        public string ATEXT;
    }

    public class Field_Struct
    {
        public string FieldName;
        public string FieldType;
        public int FieldSize = 0;
        public byte FieldPrecision = 0;
        public byte FieldScale = 0;
        public bool FieldPrimaryKey = false;

        public string GridColumnText;
        public int GridColumnWidth = 100;
        public bool GridColumnVisible = true;
        public bool GridColumnSort = true;
        public string GridColumnDefault = "";
        public bool GridReadOnly = false;
        public bool GridAutoIncrement;
        public int GridIncrementSeed;
        public int GridIncrementStep;

        public bool SqlInsert;
        public bool SqlUpdate;

        public bool ControlChange;
    }

    public class Query_Struct
    {
        public string QueryName;
        public string QueryDescription;
        public string QueryType;
        public string QueryValue;
        public int QueryRange;
    }

    public enum RightModuleType { RightDirectory, RightDisDirectory, RightForm, RightButton }
    public enum UpdateState { NoneState, NewState, EditState, CopyState }
}
