using ConversorToByte.DTO;
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
        private Conn cnx = null;
        private SqlCommand command = null;
        
        public FileSafeData()
        {
            cnx = new Conn();
        }

        public List<FileSafe> DownloadFiles(string _contract)
        {
            List<byte[]> arquivos = new List<byte[]>();

            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_DOWNLOAD_FILES);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@PARAMETRO", string.IsNullOrWhiteSpace(_contract) ? null : _contract));

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    FileSafe obj = null;
                    obj = new FileSafe() { PersonName = "_16", EncryptedFile = (dr[0] == DBNull.Value) ? default(byte[]) : (byte[])dr[0] };
                    lst.Add(obj);

                    obj = new FileSafe() { PersonName = "_18", EncryptedFile = (dr[1] == DBNull.Value) ? default(byte[]) : (byte[])dr[1] };
                    lst.Add(obj);

                    obj = new FileSafe() { PersonName = "_20", EncryptedFile = (dr[2] == DBNull.Value) ? default(byte[]) : (byte[])dr[2] };
                    lst.Add(obj);

                    obj = new FileSafe() { PersonName = "_25", EncryptedFile = (dr[3] == DBNull.Value) ? default(byte[]) : (byte[])dr[3] };
                    lst.Add(obj);

                    obj = new FileSafe() { PersonName = "_34", EncryptedFile = (dr[4] == DBNull.Value) ? default(byte[]) : (byte[])dr[4] };
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

        public List<FileSafe> GetFilesAll(string _parametro, char _typeContract, DateTime[] _datasParam = null)
        {
            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_FILES_T16_T18_T20_T25_T34);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@PARAMETRO", string.IsNullOrWhiteSpace(_parametro) ? null : _parametro));
                command.Parameters.Add(new SqlParameter("@TYPECONTRACT", _typeContract));

                if (_datasParam != null)
                {
                    command.Parameters.Add(new SqlParameter("@DATEINI", _datasParam[0]));
                    command.Parameters.Add(new SqlParameter("@DATEFIM", _datasParam[1]));
                }

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                FileSafe obj = null;
                while (dr.Read())
                {
                   
                    obj = new FileSafe()
                    {
                        PersonName = dr[0].ToString(),
                        PersonDocument = dr[1].ToString(),
                        T16 = dr[2].ToString(),
                        T18 = dr[3].ToString(),
                        T20 = dr[4].ToString(),
                        T25 = dr[5].ToString(),
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

        public List<FileSafe> GetFileSafe(string _parametro , string _tela)
        {
            List<FileSafe> lst = new List<FileSafe>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_FILES);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@PARAMETRO", string.IsNullOrWhiteSpace(_parametro) ? null : _parametro));
                command.Parameters.Add(new SqlParameter("@TELA", _tela));

                command.Connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                FileSafe obj = null;
                while (dr.Read())
                {
                    obj = new FileSafe()
                    {
                        EncryptedFile = (byte[])dr[0]
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

        public List<long> GetNumberContract(int _tela)
        {
            List<long> lst = new List<long>();
            try
            {
                command = cnx.Parametriza(Procedures.SP_GET_NUMBER_CONTRACT);
                command.Connection = command.Connection;
                command.Parameters.Add(new SqlParameter("@TELA", _tela));
                command.Connection.Open();

                SqlDataReader dr = command.ExecuteReader();
                long _numberContract  = 0;
                while (dr.Read())
                {
                    _numberContract = Convert.ToInt64(dr[0].ToString());
                    lst.Add(_numberContract);
                }

                cnx.FecharConexao(command);

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                        UserName = dr[0].ToString(),
                        UserLogin = dr[1].ToString(),
                        UserEmail = dr[2].ToString(),
                        IsAtivo = Convert.ToBoolean(dr[3])
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
                command.Parameters.Add(new SqlParameter("@USERLOGIN", _user.UserLogin));

                ret = (int)command.ExecuteScalar();

                cnx.FecharConexao(command);

                if (ret < 1)
                {
                    command = cnx.Parametriza(Procedures.SP_POST_USERS);
                    command.Connection = command.Connection;
                    command.Connection.Open();
                    command.Parameters.Add(new SqlParameter("@USERNAME", _user.UserName.Trim()));
                    command.Parameters.Add(new SqlParameter("@USERLOGIN", _user.UserLogin.Trim()));
                    command.Parameters.Add(new SqlParameter("@USEREMAIL", _user.UserEmail.Trim()));
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

        public void RemoveDuplicateRegister()
        {
            command = cnx.Parametriza(Procedures.SP_REMOVE_REGISTRO_DUPLICADOS);
            command.Connection = command.Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Dispose();
            command.Connection.Close();

        }
    }
}

