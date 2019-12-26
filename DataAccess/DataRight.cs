using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using BaseService;

namespace DataAccess
{
    public class DataRight
    {
        public DataSet GetAllModules()
        {
            try
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(
                    "SELECT MID, MNAME, MPID, MSPAC, MCLAS, MTYPE, MBUBB, MTEXT " +
                    "FROM " + BaseService.BaseService.LibraryName + "." + DataService.ModuleTable + " " +
                    "WHERE MUSED=1 " +
                    "ORDER BY MBUBB", DataService.ApplicationConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetAllUsers()
        {
            try
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(
                    "SELECT SUSER, SNAME, STYPE, SDEPT, STEXT, SUSED " +
                    "FROM " + BaseService.BaseService.LibraryName + "." + DataService.UserTable + " " +
                    "ORDER BY SDEPT, STYPE", DataService.ApplicationConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetUserRight(string userId)
        {
            try
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(
                    "SELECT RUID, RMID, RNAME, RTEXT " +
                    "FROM " + BaseService.BaseService.LibraryName + "." + DataService.RightTable + " " +
                    "WHERE UPPER(RUID)='" + userId.ToUpper() + "' AND RUSED=1",
                    DataService.ApplicationConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetUser(string userId)
        {
            try
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(
                    "SELECT SUSER, SPWD, SNAME, STYPE, SDEPT, STEXT, RMID " +
                    "FROM " + BaseService.BaseService.LibraryName + "." + DataService.UserTable + " " +
                    "WHERE UPPER(RUID)='" + userId.ToUpper() + "' AND SUSED=1",
                    DataService.ApplicationConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertUser(BaseService.StructUser user)
        {
            try
            {
                OdbcCommand insertCommand = new OdbcCommand();
                insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
                insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.UserTable + 
                    "(SUSER, SPWD, SNAME, STYPE, SDEPT, STEXT, SUSED, SMNDT, SMNTM, SMNUS, SENDT, SENTM, SENUS) " +
                    "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SUSER", System.Data.Odbc.OdbcType.VarChar, 30, "SUSER"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SPWD", System.Data.Odbc.OdbcType.VarChar, 50, "SPWD"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SNAME", System.Data.Odbc.OdbcType.VarChar, 10, "SNAME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STYPE", System.Data.Odbc.OdbcType.Int, 4, "STYPE"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SDEPT", System.Data.Odbc.OdbcType.VarChar, 20, "SDEPT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STEXT", System.Data.Odbc.OdbcType.VarChar, 30, "STEXT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SUSED", System.Data.Odbc.OdbcType.Int, 4, "SUSED"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "SMNDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "SMNTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "SMNUS"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENDT", System.Data.Odbc.OdbcType.Decimal, 8, "SENDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENTM", System.Data.Odbc.OdbcType.Decimal, 6, "SENTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENUS", System.Data.Odbc.OdbcType.VarChar, 30, "SENUS"));

                DataAccess.DataService.ApplicationConnection.Open();
                insertCommand.Parameters["SUSER"].Value = user.SUSER;
                insertCommand.Parameters["SPWD"].Value = user.SPWD;
                insertCommand.Parameters["SNAME"].Value = user.SNAME;
                insertCommand.Parameters["STYPE"].Value = user.STYPE;
                insertCommand.Parameters["SDEPT"].Value = user.SDEPT;
                insertCommand.Parameters["STEXT"].Value = user.STEXT;
                insertCommand.Parameters["SUSED"].Value = user.SUSED;
                insertCommand.Parameters["SMNDT"].Value = user.SMNDT;
                insertCommand.Parameters["SMNTM"].Value = user.SMNTM;
                insertCommand.Parameters["SMNUS"].Value = user.SMNUS;
                insertCommand.Parameters["SENDT"].Value = user.SENDT;
                insertCommand.Parameters["SENTM"].Value = user.SENTM;
                insertCommand.Parameters["SENUS"].Value = user.SENUS;
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch(Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool CopyUser(BaseService.StructUser user, string oldUserId)
        {
            OdbcCommand insertCommand = new OdbcCommand();
            insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
            insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.UserTable +
                "(SUSER, SPWD, SNAME, STYPE, SDEPT, STEXT, SUSED, SMNDT, SMNTM, SMNUS, SENDT, SENTM, SENUS) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SUSER", System.Data.Odbc.OdbcType.VarChar, 30, "SUSER"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SPWD", System.Data.Odbc.OdbcType.VarChar, 50, "SPWD"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SNAME", System.Data.Odbc.OdbcType.VarChar, 10, "SNAME"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STYPE", System.Data.Odbc.OdbcType.Int, 4, "STYPE"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SDEPT", System.Data.Odbc.OdbcType.VarChar, 20, "SDEPT"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STEXT", System.Data.Odbc.OdbcType.VarChar, 30, "STEXT"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SUSED", System.Data.Odbc.OdbcType.Int, 4, "SUSED"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "SMNDT"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "SMNTM"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "SMNUS"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENDT", System.Data.Odbc.OdbcType.Decimal, 8, "SENDT"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENTM", System.Data.Odbc.OdbcType.Decimal, 6, "SENTM"));
            insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SENUS", System.Data.Odbc.OdbcType.VarChar, 30, "SENUS"));

            OdbcCommand insertRightCommand = new OdbcCommand();
            insertRightCommand.Connection = DataAccess.DataService.ApplicationConnection;
            insertRightCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable +
                "(RUID, RMID, RNAME, RTEXT, RUSED, RMNDT, RMNTM, RMNUS, RENDT, RENTM, RENUS) " +
                "SELECT '" + user.SUSER + "', RMID, RNAME, RTEXT, RUSED, " + user.SMNDT + ", " + user.SMNTM + ", '" +
                user.SUSER + "', " + user.SMNDT + ", " + user.SMNTM + ", '" + user.SUSER + "' " + 
                "FROM " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable + " " +
                "WHERE RUID='" + oldUserId + "' AND RUSED=1";

            DataAccess.DataService.ApplicationConnection.Open();
            OdbcTransaction transaction = DataAccess.DataService.ApplicationConnection.BeginTransaction();

            try
            {
                insertCommand.Transaction = transaction;
                insertCommand.Parameters["SUSER"].Value = user.SUSER;
                insertCommand.Parameters["SPWD"].Value = user.SPWD;
                insertCommand.Parameters["SNAME"].Value = user.SNAME;
                insertCommand.Parameters["STYPE"].Value = user.STYPE;
                insertCommand.Parameters["SDEPT"].Value = user.SDEPT;
                insertCommand.Parameters["STEXT"].Value = user.STEXT;
                insertCommand.Parameters["SUSED"].Value = user.SUSED;
                insertCommand.Parameters["SMNDT"].Value = user.SMNDT;
                insertCommand.Parameters["SMNTM"].Value = user.SMNTM;
                insertCommand.Parameters["SMNUS"].Value = user.SMNUS;
                insertCommand.Parameters["SENDT"].Value = user.SENDT;
                insertCommand.Parameters["SENTM"].Value = user.SENTM;
                insertCommand.Parameters["SENUS"].Value = user.SENUS;
                insertCommand.ExecuteNonQuery();

                insertRightCommand.Transaction = transaction;
                insertRightCommand.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ModifyUser(BaseService.StructUser user)
        {
            try
            {
                OdbcCommand updateCommand = new OdbcCommand();
                updateCommand.Connection = DataAccess.DataService.ApplicationConnection;
                updateCommand.CommandText = "UPDATE " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.UserTable + " " +
                    "SET SNAME=?, STYPE=?, SDEPT=?, STEXT=?, SUSED=?, SMNDT=?, SMNTM=?, SMNUS=? " +
                    "WHERE SUSER=?";
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SNAME", System.Data.Odbc.OdbcType.VarChar, 20, "SNAME"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STYPE", System.Data.Odbc.OdbcType.Int, 4, "STYPE"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SDEPT", System.Data.Odbc.OdbcType.VarChar, 20, "SDEPT"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("STEXT", System.Data.Odbc.OdbcType.VarChar, 30, "STEXT"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SUSED", System.Data.Odbc.OdbcType.Int, 4, "SUSED"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "SMNDT"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "SMNTM"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "SMNUS"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_SUSER", System.Data.Odbc.OdbcType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SUSER", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                updateCommand.Parameters["SNAME"].Value = user.SNAME;
                updateCommand.Parameters["STYPE"].Value = user.STYPE;
                updateCommand.Parameters["SDEPT"].Value = user.SDEPT;
                updateCommand.Parameters["STEXT"].Value = user.STEXT;
                updateCommand.Parameters["SUSED"].Value = user.SUSED;
                updateCommand.Parameters["SMNDT"].Value = user.SMNDT;
                updateCommand.Parameters["SMNTM"].Value = user.SMNTM;
                updateCommand.Parameters["SMNUS"].Value = user.SMNUS;
                updateCommand.Parameters["Original_SUSER"].Value = user.SUSER;
                updateCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ModifyUserPassword(BaseService.StructUser user)
        {
            try
            {
                OdbcCommand updateCommand = new OdbcCommand();
                updateCommand.Connection = DataAccess.DataService.ApplicationConnection;
                updateCommand.CommandText = "UPDATE " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.UserTable + " " +
                    "SET SPWD=? " +
                    "WHERE SUSER=?";
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("SPWD", System.Data.Odbc.OdbcType.VarChar, 60, "SPWD"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_SUSER", System.Data.Odbc.OdbcType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SUSER", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                updateCommand.Parameters["SPWD"].Value = user.SPWD;
                updateCommand.Parameters["Original_SUSER"].Value = user.SUSER;
                updateCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                OdbcCommand updateCommand = new OdbcCommand();
                updateCommand.Connection = DataAccess.DataService.ApplicationConnection;
                updateCommand.CommandText = "DELETE FROM " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.UserTable + " " +
                    "WHERE SUSER=?";
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_SUSER", System.Data.Odbc.OdbcType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SUSER", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                updateCommand.Parameters["Original_SUSER"].Value = userId;
                updateCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool InsertModule(BaseService.StructModule module)
        {
            try
            {
                OdbcCommand insertCommand = new OdbcCommand();
                insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
                insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.ModuleTable +
                    "(MNAME, MPID, MSPAC, MCLAS, MTYPE, MBUBB, MTEXT, MUSED, MMNDT, MMNTM, MMNUS, MENDT, MENTM, MENUS) " +
                    "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MNAME", System.Data.Odbc.OdbcType.VarChar, 30, "MNAME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MPID", System.Data.Odbc.OdbcType.Int, 4, "MPID"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MSPAC", System.Data.Odbc.OdbcType.VarChar, 30, "MSPAC"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MCLAS", System.Data.Odbc.OdbcType.VarChar, 60, "MCLAS"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MTYPE", System.Data.Odbc.OdbcType.Int, 4, "MTYPE"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MBUBB", System.Data.Odbc.OdbcType.Int, 4, "MBUBB"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MTEXT", System.Data.Odbc.OdbcType.VarChar, 30, "MTEXT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MUSED", System.Data.Odbc.OdbcType.Int, 4, "MUSED"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "MMNDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "MMNTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "MMNUS"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MENDT", System.Data.Odbc.OdbcType.Decimal, 8, "MENDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MENTM", System.Data.Odbc.OdbcType.Decimal, 6, "MENTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MENUS", System.Data.Odbc.OdbcType.VarChar, 30, "MENUS"));

                DataAccess.DataService.ApplicationConnection.Open();
                insertCommand.Parameters["MNAME"].Value = module.MNAME;
                insertCommand.Parameters["MPID"].Value = module.MPID;
                insertCommand.Parameters["MSPAC"].Value = module.MSPAC;
                insertCommand.Parameters["MCLAS"].Value = module.MCLAS;
                insertCommand.Parameters["MTYPE"].Value = module.MTYPE;
                insertCommand.Parameters["MBUBB"].Value = module.MBUBB;
                insertCommand.Parameters["MTEXT"].Value = module.MTEXT;
                insertCommand.Parameters["MUSED"].Value = module.MUSED;
                insertCommand.Parameters["MMNDT"].Value = module.MMNDT;
                insertCommand.Parameters["MMNTM"].Value = module.MMNTM;
                insertCommand.Parameters["MMNUS"].Value = module.MMNUS;
                insertCommand.Parameters["MENDT"].Value = module.MENDT;
                insertCommand.Parameters["MENTM"].Value = module.MENTM;
                insertCommand.Parameters["MENUS"].Value = module.MENUS;
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ModifyModule(BaseService.StructModule module)
        {
            try
            {
                OdbcCommand updateCommand = new OdbcCommand();
                updateCommand.Connection = DataAccess.DataService.ApplicationConnection;
                updateCommand.CommandText = "UPDATE " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.ModuleTable + " " +
                    "SET MNAME=?, MPID=?, MSPAC=?, MCLAS=?, MTYPE=?, MBUBB=?, MTEXT=?, MUSED=?, MMNDT=?, MMNTM=?, MMNUS=? " +
                    "WHERE MID=?";
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MNAME", System.Data.Odbc.OdbcType.VarChar, 30, "MNAME"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MPID", System.Data.Odbc.OdbcType.Int, 4, "MPID"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MSPAC", System.Data.Odbc.OdbcType.VarChar, 30, "MSPAC"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MCLAS", System.Data.Odbc.OdbcType.VarChar, 60, "MCLAS"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MTYPE", System.Data.Odbc.OdbcType.Int, 4, "MTYPE"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MBUBB", System.Data.Odbc.OdbcType.Int, 4, "MBUBB"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MTEXT", System.Data.Odbc.OdbcType.VarChar, 30, "MTEXT"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MUSED", System.Data.Odbc.OdbcType.Int, 4, "MUSED"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "MMNDT"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "MMNTM"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("MMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "MMNUS"));
                updateCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_MID", System.Data.Odbc.OdbcType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MID", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                updateCommand.Parameters["MNAME"].Value = module.MNAME;
                updateCommand.Parameters["MPID"].Value = module.MPID;
                updateCommand.Parameters["MSPAC"].Value = module.MSPAC;
                updateCommand.Parameters["MCLAS"].Value = module.MCLAS;
                updateCommand.Parameters["MTYPE"].Value = module.MTYPE;
                updateCommand.Parameters["MBUBB"].Value = module.MBUBB;
                updateCommand.Parameters["MTEXT"].Value = module.MTEXT;
                updateCommand.Parameters["MUSED"].Value = module.MUSED;
                updateCommand.Parameters["MMNDT"].Value = module.MMNDT;
                updateCommand.Parameters["MMNTM"].Value = module.MMNTM;
                updateCommand.Parameters["MMNUS"].Value = module.MMNUS;
                updateCommand.Parameters["Original_MID"].Value = module.MID;
                updateCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool DeleteModule(int moduleId)
        {
            try
            {
                OdbcCommand deleteCommand = new OdbcCommand();
                deleteCommand.Connection = DataAccess.DataService.ApplicationConnection;
                deleteCommand.CommandText = "DELETE FROM " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.ModuleTable + " " +
                    "WHERE MID=?";
                deleteCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_MID", System.Data.Odbc.OdbcType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MID", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                deleteCommand.Parameters["Original_MID"].Value = moduleId;
                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool UpdateUserRight(string userId, List<BaseService.StructRight> rights)
        {
            try
            {
                OdbcCommand insertCommand = new OdbcCommand();
                insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
                insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable +
                    "(RUID, RMID, RNAME, RTEXT, RUSED, RMNDT, RMNTM, RMNUS, RENDT, RENTM, RENUS) " +
                    "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RUID", System.Data.Odbc.OdbcType.VarChar, 30, "RUID"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMID", System.Data.Odbc.OdbcType.Int, 4, "RMID"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RNAME", System.Data.Odbc.OdbcType.VarChar, 30, "RNAME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RTEXT", System.Data.Odbc.OdbcType.VarChar, 30, "RTEXT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RUSED", System.Data.Odbc.OdbcType.Int, 4, "RUSED"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "RMNDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "RMNTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "RMNUS"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENDT", System.Data.Odbc.OdbcType.Decimal, 8, "RENDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENTM", System.Data.Odbc.OdbcType.Decimal, 6, "RENTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENUS", System.Data.Odbc.OdbcType.VarChar, 30, "RENUS"));

                OdbcCommand deleteCommand = new OdbcCommand();
                deleteCommand.Connection = DataAccess.DataService.ApplicationConnection;
                deleteCommand.CommandText = "DELETE FROM " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable + " " +
                    "WHERE RUID=?";
                deleteCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_RUID", System.Data.Odbc.OdbcType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RUID", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                deleteCommand.Parameters["Original_RUID"].Value = userId;
                deleteCommand.ExecuteNonQuery();

                for (int i = 0; i < rights.Count; i++)
                {
                    insertCommand.Parameters["RUID"].Value = rights[i].RUID;
                    insertCommand.Parameters["RMID"].Value = rights[i].RMID;
                    insertCommand.Parameters["RNAME"].Value = rights[i].RNAME;
                    insertCommand.Parameters["RTEXT"].Value = rights[i].RTEXT;
                    insertCommand.Parameters["RUSED"].Value = rights[i].RUSED;
                    insertCommand.Parameters["RMNDT"].Value = rights[i].RMNDT;
                    insertCommand.Parameters["RMNTM"].Value = rights[i].RMNTM;
                    insertCommand.Parameters["RMNUS"].Value = rights[i].RMNUS;
                    insertCommand.Parameters["RENDT"].Value = rights[i].RENDT;
                    insertCommand.Parameters["RENTM"].Value = rights[i].RENTM;
                    insertCommand.Parameters["RENUS"].Value = rights[i].RENUS;
                    insertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool UpdateModuleRight(string userId, int moduleId, List<BaseService.StructRight> rights)
        {
            try
            {
                OdbcCommand insertCommand = new OdbcCommand();
                insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
                insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable +
                    "(RUID, RMID, RNAME, RTEXT, RUSED, RMNDT, RMNTM, RMNUS, RENDT, RENTM, RENUS) " +
                    "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RUID", System.Data.Odbc.OdbcType.VarChar, 30, "RUID"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMID", System.Data.Odbc.OdbcType.Int, 4, "RMID"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RNAME", System.Data.Odbc.OdbcType.VarChar, 30, "RNAME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RTEXT", System.Data.Odbc.OdbcType.VarChar, 30, "RTEXT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RUSED", System.Data.Odbc.OdbcType.Int, 4, "RUSED"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNDT", System.Data.Odbc.OdbcType.Decimal, 8, "RMNDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNTM", System.Data.Odbc.OdbcType.Decimal, 6, "RMNTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RMNUS", System.Data.Odbc.OdbcType.VarChar, 30, "RMNUS"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENDT", System.Data.Odbc.OdbcType.Decimal, 8, "RENDT"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENTM", System.Data.Odbc.OdbcType.Decimal, 6, "RENTM"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("RENUS", System.Data.Odbc.OdbcType.VarChar, 30, "RENUS"));

                OdbcCommand deleteCommand = new OdbcCommand();
                deleteCommand.Connection = DataAccess.DataService.ApplicationConnection;
                deleteCommand.CommandText = "DELETE FROM " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.RightTable + " " +
                    "WHERE RUID=? AND RMID=? AND (UPPER(TRIM(RNAME))<>'*FRM')";
                deleteCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_RUID", System.Data.Odbc.OdbcType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RUID", System.Data.DataRowVersion.Original, null));
                deleteCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("Original_RMID", System.Data.Odbc.OdbcType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RMID", System.Data.DataRowVersion.Original, null));

                DataAccess.DataService.ApplicationConnection.Open();
                deleteCommand.Parameters["Original_RUID"].Value = userId;
                deleteCommand.Parameters["Original_RMID"].Value = moduleId;
                deleteCommand.ExecuteNonQuery();

                for (int i = 0; i < rights.Count; i++)
                {
                    insertCommand.Parameters["RUID"].Value = rights[i].RUID;
                    insertCommand.Parameters["RMID"].Value = rights[i].RMID;
                    insertCommand.Parameters["RNAME"].Value = rights[i].RNAME;
                    insertCommand.Parameters["RTEXT"].Value = rights[i].RTEXT;
                    insertCommand.Parameters["RUSED"].Value = rights[i].RUSED;
                    insertCommand.Parameters["RMNDT"].Value = rights[i].RMNDT;
                    insertCommand.Parameters["RMNTM"].Value = rights[i].RMNTM;
                    insertCommand.Parameters["RMNUS"].Value = rights[i].RMNUS;
                    insertCommand.Parameters["RENDT"].Value = rights[i].RENDT;
                    insertCommand.Parameters["RENTM"].Value = rights[i].RENTM;
                    insertCommand.Parameters["RENUS"].Value = rights[i].RENUS;
                    insertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("保存成功");
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable FillChildTable(string aSelectSql)
        {
            try
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(aSelectSql, DataService.ApplicationConnection);
                adapter.SelectCommand.CommandTimeout = 600000;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("发生错误！" + ex.Message);
                return null;
            }
        }

        public bool UpdateChildTable(string aInsertSql, string aUpdateSql, string aDeleteSql,
            List<Field_Struct> aFieldsList, DataTable aDataTable, int aPrimaryCount)
        {
            OdbcCommand insertCommand = new OdbcCommand();
            OdbcCommand updateCommand = new OdbcCommand();
            OdbcCommand deleteCommand = new OdbcCommand();

            int tempInt;
            try
            {
                #region INSERT
                string tempInsertText = "";
                string tempInsertValues = "";
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].SqlInsert == true)
                    {
                        if (tempInsertText == "")
                        {
                            tempInsertText = "(" + aFieldsList[i].FieldName;
                            tempInsertValues = " VALUES(?";
                        }
                        else
                        {
                            tempInsertText += ", " + aFieldsList[i].FieldName;
                            tempInsertValues += ", ?";
                        }
                    }
                }
                tempInsertText += ")";
                tempInsertValues += ")";
                insertCommand.CommandText = aInsertSql + tempInsertText + tempInsertValues;
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].SqlInsert == true)
                    {
                        if (aFieldsList[i].FieldType.ToUpper() == "DECIMAL")
                            insertCommand.Parameters.Add(new OdbcParameter(aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                                aFieldsList[i].FieldType), aFieldsList[i].FieldSize, ParameterDirection.Input, true,
                                aFieldsList[i].FieldPrecision, aFieldsList[i].FieldScale, aFieldsList[i].FieldName, DataRowVersion.Current, null));
                        else
                            insertCommand.Parameters.Add(new OdbcParameter(aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                                aFieldsList[i].FieldType), aFieldsList[i].FieldSize, aFieldsList[i].FieldName));
                    }
                }
                insertCommand.Connection = DataService.ApplicationConnection;

                #endregion

                #region UPDATE

                string tempUpdateText = "";
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].SqlUpdate == true)
                    {
                        if (tempUpdateText == "")
                            tempUpdateText = " " + aFieldsList[i].FieldName + "=?";
                        else
                            tempUpdateText += ", " + aFieldsList[i].FieldName + "=?";
                    }
                }
                tempInt = 0;
                for (int i = 0; i < aFieldsList.Count; i++)
                    if (aFieldsList[i].FieldPrimaryKey == true)
                        tempInt++;
                if (tempInt != aPrimaryCount)
                {
                    MessageBox.Show("主键错误！");
                    return false;
                }
                updateCommand.CommandText = aUpdateSql.Replace("###", tempUpdateText);
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].SqlUpdate == true)
                    {
                        if (aFieldsList[i].FieldType.ToUpper() == "DECIMAL")
                            updateCommand.Parameters.Add(new OdbcParameter(aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                                aFieldsList[i].FieldType), aFieldsList[i].FieldSize, ParameterDirection.Input, true,
                                aFieldsList[i].FieldPrecision, aFieldsList[i].FieldScale, aFieldsList[i].FieldName, DataRowVersion.Current, null));
                        else
                            updateCommand.Parameters.Add(new OdbcParameter(aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                                aFieldsList[i].FieldType), aFieldsList[i].FieldSize, aFieldsList[i].FieldName));
                    }
                }
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].FieldPrimaryKey == true)
                        updateCommand.Parameters.Add(new OdbcParameter("Original_" + aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                             aFieldsList[i].FieldType), aFieldsList[i].FieldSize, System.Data.ParameterDirection.Input, false,
                             aFieldsList[i].FieldPrecision, aFieldsList[i].FieldScale, aFieldsList[i].FieldName, DataRowVersion.Original, null));
                }
                updateCommand.Connection = DataService.ApplicationConnection;

                #endregion

                #region DELETE

                tempInt = 0;
                for (int i = 0; i < aFieldsList.Count; i++)
                    if (aFieldsList[i].FieldPrimaryKey == true)
                        tempInt++;
                if (tempInt != aPrimaryCount)
                {
                    MessageBox.Show("主键错误！");
                    return false;
                }
                deleteCommand.CommandText = aDeleteSql;
                for (int i = 0; i < aFieldsList.Count; i++)
                {
                    if (aFieldsList[i].FieldPrimaryKey == true)
                        deleteCommand.Parameters.Add(new OdbcParameter("Original_" + aFieldsList[i].FieldName, (OdbcType)Enum.Parse(typeof(OdbcType),
                            aFieldsList[i].FieldType), aFieldsList[i].FieldSize, System.Data.ParameterDirection.Input, false,
                            aFieldsList[i].FieldPrecision, aFieldsList[i].FieldScale, aFieldsList[i].FieldName, DataRowVersion.Original, null));
                }
                deleteCommand.Connection = DataService.ApplicationConnection;

                #endregion

                if (DataService.ApplicationConnection.State != ConnectionState.Open)
                    DataService.ApplicationConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败！" + ex.Message);
                return false;
            }


            OdbcTransaction transaction = DataService.ApplicationConnection.BeginTransaction();
            try
            {
                insertCommand.Transaction = transaction;
                updateCommand.Transaction = transaction;
                deleteCommand.Transaction = transaction;

                for (int i = 0; i < aDataTable.Rows.Count; i++)
                {
                    if (aDataTable.Rows[i].RowState == DataRowState.Deleted)
                    {
                        for (int j = 0; j < aFieldsList.Count; j++)
                        {
                            if (aFieldsList[j].FieldPrimaryKey == true)
                                deleteCommand.Parameters["Original_" + aFieldsList[j].FieldName].Value =
                                    aDataTable.Rows[i][aFieldsList[j].FieldName, DataRowVersion.Original];
                        }
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                for (int i = 0; i < aDataTable.Rows.Count; i++)
                {
                    if (aDataTable.Rows[i].RowState == DataRowState.Modified)
                    {
                        for (int j = 0; j < aFieldsList.Count; j++)
                        {
                            if (aFieldsList[j].SqlUpdate == true)
                            {
                                //updateCommand.Parameters[aFieldsList[j].FieldName].Value = null;
                                if (updateCommand.Parameters[aFieldsList[j].FieldName].OdbcType == OdbcType.VarChar)
                                {
                                    updateCommand.Parameters[aFieldsList[j].FieldName] = new OdbcParameter(updateCommand.Parameters[aFieldsList[j].FieldName].ParameterName,
                                            OdbcType.VarChar, 0, updateCommand.Parameters[aFieldsList[j].FieldName].SourceColumn);
                                }
                                updateCommand.Parameters[aFieldsList[j].FieldName].Value =
                                    aDataTable.Rows[i][aFieldsList[j].FieldName];
                            }
                        }
                        for (int j = 0; j < aFieldsList.Count; j++)
                        {
                            if (aFieldsList[j].FieldPrimaryKey == true)
                                updateCommand.Parameters["Original_" + aFieldsList[j].FieldName].Value =
                                    aDataTable.Rows[i][aFieldsList[j].FieldName, DataRowVersion.Original];
                        }
                        updateCommand.ExecuteNonQuery();
                    }
                }

                for (int i = 0; i < aDataTable.Rows.Count; i++)
                {
                    if (aDataTable.Rows[i].RowState == DataRowState.Added)
                    {
                        for (int j = 0; j < aFieldsList.Count; j++)
                        {
                            if (aFieldsList[j].SqlInsert == true)
                            {
                                if (insertCommand.Parameters[aFieldsList[j].FieldName].OdbcType == OdbcType.VarChar)
                                {
                                    //insertCommand.Parameters[aFieldsList[j].FieldName].OdbcType = OdbcType.Text;
                                    insertCommand.Parameters[aFieldsList[j].FieldName] = new OdbcParameter(insertCommand.Parameters[aFieldsList[j].FieldName].ParameterName,
                                        OdbcType.VarChar, 0, insertCommand.Parameters[aFieldsList[j].FieldName].SourceColumn);
                                }
                                insertCommand.Parameters[aFieldsList[j].FieldName].Value =
                                    aDataTable.Rows[i][aFieldsList[j].FieldName];
                            }
                        }
                        insertCommand.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                DataService.ApplicationConnection.Close();
                MessageBox.Show("保存成功。");
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                DataService.ApplicationConnection.Close();
                MessageBox.Show("保存失败！" + ex.Message);
                return false;
            }
        }

        public bool InsertAccess(BaseService.StructAccess access)
        {
            try
            {
                OdbcCommand insertCommand = new OdbcCommand();
                insertCommand.Connection = DataAccess.DataService.ApplicationConnection;
                insertCommand.CommandText = "INSERT INTO " + BaseService.BaseService.LibraryName + "." + DataAccess.DataService.AccessTable +
                    "(ANAME, AUSER, AMNME, ADATE, ATIME, ATEXT) " +
                    "VALUES(?, ?, ?, ?, ?, ?)";
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("ANAME", System.Data.Odbc.OdbcType.VarChar, 30, "ANAME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("AUSER", System.Data.Odbc.OdbcType.VarChar, 30, "AUSER"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("AMNME", System.Data.Odbc.OdbcType.VarChar, 60, "AMNME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("ADATE", System.Data.Odbc.OdbcType.Decimal, 8, "ADATE"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("ATIME", System.Data.Odbc.OdbcType.Decimal, 6, "ATIME"));
                insertCommand.Parameters.Add(new System.Data.Odbc.OdbcParameter("ATEXT", System.Data.Odbc.OdbcType.VarChar, 30, "ATEXT"));

                DataAccess.DataService.ApplicationConnection.Open();
                insertCommand.Parameters["ANAME"].Value = access.ANAME;
                insertCommand.Parameters["AUSER"].Value = access.AUSER;
                insertCommand.Parameters["AMNME"].Value = access.AMNME;
                insertCommand.Parameters["ADATE"].Value = access.ADATE;
                insertCommand.Parameters["ATIME"].Value = access.ATIME;
                insertCommand.Parameters["ATEXT"].Value = access.ATEXT;
                insertCommand.ExecuteNonQuery();
                DataAccess.DataService.ApplicationConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                DataAccess.DataService.ApplicationConnection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
