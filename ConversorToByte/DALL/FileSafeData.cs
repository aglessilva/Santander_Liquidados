﻿using ConversorToByte.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorToByte.DALL
{
    public class FileSafeData
    {
        private conn cnx = null;
        private SqlCommand command = null;
        
        public FileSafeData()
        {
            cnx = new conn();
        }

        public List<FileSafe> DownloadFiles(string _contract)
        {
            List<byte[]> arquivos = new List<byte[]>();

            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_DOWNLOAD_FILES);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@CONTRACTNAME", string.IsNullOrWhiteSpace(_contract) ? null : _contract));

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    FileSafe obj = null;
                    obj = new FileSafe() { NameContract = "_16", FileEncryption = (dr[0] == DBNull.Value) ? default(byte[]) : (byte[])dr[0] };
                    lst.Add(obj);

                    obj = new FileSafe() { NameContract = "_18", FileEncryption = (dr[1] == DBNull.Value) ? default(byte[]) : (byte[])dr[1] };
                    lst.Add(obj);

                    obj = new FileSafe() { NameContract = "_20", FileEncryption = (dr[2] == DBNull.Value) ? default(byte[]) : (byte[])dr[2] };
                    lst.Add(obj);

                    obj = new FileSafe() { NameContract = "_25", FileEncryption = (dr[3] == DBNull.Value) ? default(byte[]) : (byte[])dr[3] };
                    lst.Add(obj);
                   
                }

                cnx.FecharConexao(command);

            }
            catch (SqlException ex)
            {
                cnx.FecharConexao(command);
                throw ex;
            }

            return lst;
        }

        public List<FileSafe> GetFilesAll(string _contract)
        {
            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_FILES_T16_T18_t20_t25);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@CONTRACTNAME", string.IsNullOrWhiteSpace(_contract) ? null : _contract));

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                FileSafe obj = null;
                while (dr.Read())
                {
                   
                    obj = new FileSafe()
                    {
                        NameContract = dr[0].ToString(),
                        DocumentCpf = dr[1].ToString(),
                        T18 = dr[2].ToString(),
                        T20 = dr[3].ToString(),
                        T25 = dr[4].ToString(),
                    };

                    lst.Add(obj);
                }

                cnx.FecharConexao(command);

            }
            catch (SqlException ex)
            {
                cnx.FecharConexao(command);
                throw ex;
            }

            return lst;
        }

        public List<FileSafe> GetFileSafe(string _contratoCPF = null, string _tela = null, bool _isAtivo =  false)
        {
            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_FILES);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@CONTRACTNAME", string.IsNullOrWhiteSpace(_contratoCPF) ? null : _contratoCPF));
                command.Parameters.Add(new SqlParameter("@TELA", string.IsNullOrWhiteSpace(_tela) ? null : _tela));
                command.Parameters.Add(new SqlParameter("@ISATIVO", _isAtivo));

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                FileSafe obj = null;
                while (dr.Read())
                {
                    if(string.IsNullOrWhiteSpace(_tela))
                        obj = new FileSafe()
                        {
                            NameContract = dr[0].ToString(),
                            DocumentCpf  = dr[1].ToString(),
                            FileEncryption = (dr[2] == DBNull.Value) ? default(byte[]) : (byte[])dr[2] 
                        };
                    else
                        obj = new FileSafe()
                        {
                            NameContract = dr[0].ToString(),
                            FileEncryption = (dr[1] == DBNull.Value) ? default(byte[]) : (byte[])dr[1]
                        };

                    lst.Add(obj);
                }

                cnx.FecharConexao(command);

            }
            catch (SqlException ex)
            {
                cnx.FecharConexao(command);
                throw ex; 
            }

            return lst;
        }



        public List<Users> GetUsers(string _userLogin = null)
        {
            List<Users> lst = new List<Users>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_USERS);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@Usuario", string.IsNullOrWhiteSpace(_userLogin) ? null : _userLogin));
                command.Connection.Open();
                
                SqlDataReader dr = command.ExecuteReader();

                Users obj = null;
                while (dr.Read())
                {
                    obj = new Users()
                    {
                        UserLogin = dr[2].ToString(),
                        UserName = dr[4].ToString(),
                        UserEmail = dr[3].ToString(),
                        IsAtivo = Convert.ToBoolean(dr[1])
                    };

                    lst.Add(obj);
                }

                cnx.FecharConexao(command);

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UdtUser(string _login)
        {
            command = cnx.Parametriza(Procedures.SP_UDT_USERS);
            command.Parameters.Add(new SqlParameter("@LOGIN", string.IsNullOrWhiteSpace(_login) ? null : _login));
            command.Connection = command.Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            cnx.FecharConexao(command);
        }

        public int DltUser(string _login)
        {
            int ret = 0;
            command = cnx.Parametriza(Procedures.SP_DLT_USERS);
            command.Parameters.Add(new SqlParameter("@LOGIN", string.IsNullOrWhiteSpace(_login) ? null : _login));
            command.Connection = command.Connection;
            command.Connection.Open();
            ret = command.ExecuteNonQuery();
            cnx.FecharConexao(command);

            return ret;
        }

        public int AddUser(Users _user)
        {
            int ret = 0;
            try
            {
                command = cnx.Parametriza(Procedures.SP_CHK_USER);
                command.Connection = command.Connection;
                command.Connection.Open();
                command.Parameters.Add(new SqlParameter("@USERLOGIN", _user.UserLogin ));
                
                ret = (int)command.ExecuteScalar();

                cnx.FecharConexao(command);

                if (ret < 1)
                {
                    command = cnx.Parametriza(Procedures.SP_POST_USERS);
                    command.Connection = command.Connection;
                    command.Connection.Open();
                    command.Parameters.Add(new SqlParameter("@USERLOGIN", _user.UserLogin.Trim()));
                    command.Parameters.Add(new SqlParameter("@USEREMAIL", _user.UserEmail.Trim()));
                    command.Parameters.Add(new SqlParameter("@USERNAME", _user.UserName.Trim()));
                    command.Parameters.Add(new SqlParameter("@ISGESTORAPP", false));
                    ret = command.ExecuteNonQuery();
                    cnx.FecharConexao(command);
                }
                else
                    ret = 100;

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Users CheckUser(string _login)
        {
            Users obj = new Users();
            command = cnx.Parametriza(Procedures.SP_CHK_PERMICAO);
            command.Connection = command.Connection;
            command.Connection.Open();
            command.Parameters.Add(new SqlParameter("@LOGIN", _login));
            
            SqlDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {
                obj.IsGestorApp = Convert.ToBoolean(dr[0]);
                obj.IsAtivo = Convert.ToBoolean(dr[1]);
            }

            return obj;
        }
    }
}
