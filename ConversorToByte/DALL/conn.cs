using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConversorToByte.DALL
{
    public  class Conn
    {
        //public static string strConn = @"Password=01#$Sucesso;Persist Security Info=True;User ID=sa;Initial Catalog=DbFileSafe;Data Source=NP2110929\SQLEXPRESS";

        string strConn =  string.Empty;
        SqlCommand command = null;
        public Conn() 
        {
            strConn = ConfigurationManager.ConnectionStrings[0].ToString();
            command = new SqlCommand();
        }


        protected internal SqlCommand Parametriza(Procedures _proc)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = _proc.ToString();
            command.CommandTimeout = 0;
            command.Parameters.Clear();
            command.Connection = new SqlConnection(strConn);

            return command;
        }

        protected internal void FecharConexao(SqlCommand _command)
        {
            _command.Dispose();
            _command.Clone();
        }

        public byte[] Pesquisars(string prop)
        {
           
            SqlCommand command = null;

            using (SqlConnection connection = new SqlConnection("Password=presto123;Persist Security Info=True;User ID=presto_user;Initial Catalog=DB_Santander_Presto;Data Source=172.19.11.155"))
            {

                byte[] ret = null;
                try
                {

                    command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.CommandText = "sp_ArmazenarArquivoProposta";
                    command.CommandTimeout = 0;

                    command.Parameters.Add(new SqlParameter("@Proporsal", prop));
                    command.Parameters.Add(new SqlParameter("@tipo", 1));

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while(dr.Read())
                    {
                        ret = (byte[])dr[0];
                    }

                    command.Dispose();
                    command.Clone();
                    connection.Close();
                  

                }
                catch (SqlException ex)
                {
                    command.Dispose();
                    command.Clone();
                    connection.Close();
                    throw ex; ;
                }

                return ret;
            }
        }

        public  void FileStores(object parametro)
        {
            DataTable dataTable = (DataTable)parametro.GetType().GetProperty("item1").GetValue(parametro, null);
            string tableName = (string)parametro.GetType().GetProperty("item2").GetValue(parametro, null);

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                try
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null)
                    {
                        DestinationTableName = tableName
                    };

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    bulkCopy.WriteToServer(dataTable);
                    connection.Dispose();
                    connection.Close();
                    
                    dataTable.Clear();
                }

                catch (SqlException ex)
                {
                    connection.Dispose();
                    connection.Close();

                    if (ex.Number.Equals(2627))
                    {
                        string[] texto = Regex.Replace(ex.Message, @"[^0-9$]+", " ").Split(' ');
                        string _contract = texto.FirstOrDefault(r => Regex.IsMatch(r, @"(^\d{14,15}$)")).Trim();
                        dataTable.Select($"NumberContract={_contract}").ToList().ForEach(r => r.Delete());

                        var tab = new
                        {
                            item1 = dataTable,
                            item2 = tableName,
                        };

                        FileStores(tab);
                    }

                    throw ex;
                }

            }

        }

    }
}