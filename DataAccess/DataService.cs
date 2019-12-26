using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace DataAccess
{
    public static class DataService
    {
        private static OdbcConnection applicationConnection;
        private static OdbcConnection[] lockConnection;
        private static OdbcTransaction[] lockTransaction;

        private static string connectionUserName = "LYPGM";
        private static string connectionPassWord = "SAMEPGM";
        private static string userTable = "USER";
        private static string moduleTable = "MODULE";
        private static string rightTable = "RIGHT";
        private static string parameterTable = "PARAMETER";
        private static string accessTable = "ACCESS";

        public static OdbcConnection ApplicationConnection
        {
            get { return DataService.applicationConnection; }
            set { DataService.applicationConnection = value; }
        }

        public static OdbcConnection[] LockConnection
        {
            get { return DataService.lockConnection; }
            set { DataService.lockConnection = value; }
        }

        public static OdbcTransaction[] LockTransaction
        {
            get { return DataService.lockTransaction; }
            set { DataService.lockTransaction = value; }
        }

        public static string UserTable
        {
            get { return DataService.userTable; }
            set { DataService.userTable = value; }
        }

        public static string ModuleTable
        {
            get { return DataService.moduleTable; }
            set { DataService.moduleTable = value; }
        }

        public static string RightTable
        {
            get { return DataService.rightTable; }
            set { DataService.rightTable = value; }
        }

        public static string ParameterTable
        {
            get { return DataService.parameterTable; }
            set { DataService.parameterTable = value; }
        }

        public static string AccessTable
        {
            get { return DataService.accessTable; }
            set { DataService.accessTable = value; }
        }

        public static void Init()
        {
            userTable = BaseService.BaseService.PreFix + userTable;
            moduleTable = BaseService.BaseService.PreFix + moduleTable;
            rightTable = BaseService.BaseService.PreFix + rightTable;
            parameterTable = BaseService.BaseService.PreFix + parameterTable;
            accessTable = BaseService.BaseService.PreFix + accessTable;
        }

        public static int ConnectDatabase(string UserID, string PassWord, int LockCount)
        {
            if (BaseService.BaseService.ConnectionLoad == 0)
            {
                applicationConnection = new OdbcConnection(BaseService.BaseService.ConnectionString + "UID=" +
                    connectionUserName + ";PWD=" + connectionPassWord + ";");
                lockConnection = new OdbcConnection[LockCount];
                lockTransaction = new OdbcTransaction[LockCount];
                for (int i = 0; i < LockCount; i++)
                {
                    lockConnection[i] = new OdbcConnection(BaseService.BaseService.ConnectionString + "UID=" +
                        connectionUserName + ";PWD=" + connectionPassWord + ";");
                }
            }
            else
            {
                applicationConnection = new OdbcConnection(BaseService.BaseService.ConnectionString + "UID=" +
                    UserID + ";PWD=" + PassWord + ";");
                lockConnection = new OdbcConnection[LockCount];
                lockTransaction = new OdbcTransaction[LockCount];
                for (int i = 0; i < LockCount; i++)
                {
                    lockConnection[i] = new OdbcConnection(BaseService.BaseService.ConnectionString + "UID=" +
                        UserID + ";PWD=" + PassWord + ";");
                }
            }

            try
            {
                applicationConnection.Open();

                if (BaseService.BaseService.ConnectionLoad == 0)
                {
                    System.Data.Odbc.OdbcCommand commandUser = new OdbcCommand();
                    System.Data.Odbc.OdbcDataAdapter adapterUser = new OdbcDataAdapter();
                    adapterUser.SelectCommand = commandUser;
                    commandUser.CommandText = "SELECT * FROM " + BaseService.BaseService.LibraryName + "." + userTable +
                        " WHERE UPPER(SUSER)='" + UserID + "' AND SPWD='" +
                        BaseService.BaseService.EncryptPassword(PassWord) + "'";
                    commandUser.Connection = applicationConnection;
                    DataSet dsUser = new DataSet();
                    adapterUser.Fill(dsUser);
                    if (dsUser.Tables[0].Rows.Count <= 0)
                        return -2;
                    BaseService.BaseService.ApplicationUser.SUSER = UserID;
                    BaseService.BaseService.ApplicationUser.SPWD = PassWord;
                    BaseService.BaseService.ApplicationUser.SNAME = dsUser.Tables[0].Rows[0]["SNAME"].ToString();
                    BaseService.BaseService.ApplicationUser.STYPE =
                        System.Convert.ToInt32(dsUser.Tables[0].Rows[0]["STYPE"].ToString());
                    BaseService.BaseService.ApplicationUser.SDEPT = dsUser.Tables[0].Rows[0]["SDEPT"].ToString();
                }
                else
                {
                    System.Data.Odbc.OdbcCommand commandUser = new OdbcCommand();
                    System.Data.Odbc.OdbcDataAdapter adapterUser = new OdbcDataAdapter();
                    adapterUser.SelectCommand = commandUser;
                    commandUser.CommandText = "SELECT * FROM " + BaseService.BaseService.LibraryName + "." + userTable +
                        " WHERE UPPER(SUSER)='" + UserID + "'";
                    commandUser.Connection = applicationConnection;
                    DataSet dsUser = new DataSet();
                    adapterUser.Fill(dsUser);
                    BaseService.BaseService.ApplicationUser.SUSER = UserID;
                    BaseService.BaseService.ApplicationUser.SPWD = PassWord;
                    BaseService.BaseService.ApplicationUser.STYPE = 0;
                    if (dsUser.Tables[0].Rows.Count == 1)
                    {
                        BaseService.BaseService.ApplicationUser.SNAME = dsUser.Tables[0].Rows[0]["SNAME"].ToString();
                        BaseService.BaseService.ApplicationUser.STYPE =
                            System.Convert.ToInt32(dsUser.Tables[0].Rows[0]["STYPE"].ToString());
                        BaseService.BaseService.ApplicationUser.SDEPT = dsUser.Tables[0].Rows[0]["SDEPT"].ToString();
                    }
                }

                System.Data.Odbc.OdbcCommand commandRight = new OdbcCommand();
                System.Data.Odbc.OdbcDataAdapter adapterRight = new OdbcDataAdapter();
                adapterRight.SelectCommand = commandRight;
                commandRight.CommandText = "SELECT RUID, RMID, RNAME, MID, MNAME, MPID, MSPAC, MCLAS, MTYPE, MBUBB " +
                    "FROM " + BaseService.BaseService.LibraryName + "." + rightTable + 
                    " INNER JOIN " + BaseService.BaseService.LibraryName + "." + moduleTable + " " + 
                    "ON RMID=MID " + 
                    "WHERE RUID='" + UserID + "' AND RUSED=1 AND MUSED=1 ORDER BY MBUBB";
                commandRight.Connection = applicationConnection;
                DataSet dsRight = new DataSet();
                adapterRight.Fill(dsRight);
                for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
                {
                    BaseService.StructUserRight structUserRight = new BaseService.StructUserRight();
                    structUserRight.ModuleID = System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["RMID"].ToString().Trim());
                    structUserRight.ModuleName = dsRight.Tables[0].Rows[i]["MNAME"].ToString().Trim();
                    structUserRight.ModuleParentID = System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["MPID"].ToString().Trim());
                    structUserRight.ModuleNameSpace = dsRight.Tables[0].Rows[i]["MSPAC"].ToString().Trim();
                    structUserRight.ModuleClassName = dsRight.Tables[0].Rows[i]["MCLAS"].ToString().Trim();
                    if (dsRight.Tables[0].Rows[i]["RNAME"].ToString().Trim().ToLower() == "*frm")
                    {
                        switch (System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["MTYPE"].ToString().Trim()))
                        {
                            case 0:
                                structUserRight.ModuleType = BaseService.RightModuleType.RightDirectory;
                                break;
                            case 1:
                                structUserRight.ModuleType = BaseService.RightModuleType.RightDisDirectory;
                                break;
                            case 2:
                                structUserRight.ModuleType = BaseService.RightModuleType.RightForm;
                                break;
                        }
                        structUserRight.ModuleButtonName = "";
                    }
                    else
                    {
                        structUserRight.ModuleType = BaseService.RightModuleType.RightButton;
                        structUserRight.ModuleButtonName = dsRight.Tables[0].Rows[i]["RNAME"].ToString().Trim().ToLower();
                    }
                    BaseService.BaseService.ApplicationRight.Add(structUserRight);
                }

                applicationConnection.Close();
                return 1;
            }
            catch
            {
                applicationConnection.Close();
                return -1;
            }
        }

        public static System.DateTime GetDateTime()
        {
            try
            {
                System.Data.Odbc.OdbcDataAdapter adapter = new OdbcDataAdapter();
                System.Data.Odbc.OdbcCommand comm = new OdbcCommand();
                adapter.SelectCommand = comm;
                comm.CommandText = "SELECT DISTINCT CURDATE(), CURTIME() FROM " + BaseService.BaseService.LibraryName + "." + userTable;
                comm.Connection = applicationConnection;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                System.DateTime tempTime = System.Convert.ToDateTime(ds.Tables[0].Rows[0][ds.Tables[0].Columns[1]].ToString());
                System.DateTime tempDate = System.Convert.ToDateTime(ds.Tables[0].Rows[0][ds.Tables[0].Columns[0]].ToString());
                DateTime dt = System.Convert.ToDateTime(tempDate.ToString("yyyy-MM-dd") + " " + tempTime.ToString("HH:mm:ss"));
                return dt;
            }
            catch
            {
                return System.Convert.ToDateTime("1899-01-01 00:00:00");
            }
        }
    }
}
