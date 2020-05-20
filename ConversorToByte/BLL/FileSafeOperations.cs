using ConversorToByte.DALL;
using ConversorToByte.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorToByte.BLL
{
    public class FileSafeOperations
    {

        public List<FileSafe> DownloadFile(string _contract)
        {
            FileSafeData fs = new FileSafeData();
            List<FileSafe> lst = fs.DownloadFiles(_contract);
            return lst;
        }
        /// <summary>
        /// Lista todos os arquivos binarizados
        /// </summary>
        /// <param name="_contractCpf">Filtro por contrato ou por numero de cpf do cliente</param>
        /// <returns>Retorna uma lista de arquivos binarizados</returns>
        public List<FileSafe> GetFilesSafe(string _parametro , string _tela)
        {
            FileSafeData fs = new FileSafeData();
            List<FileSafe> lst = fs.GetFileSafe(_parametro, _tela);
            return lst;
        }

        /// <summary>
        /// Retorna um objeto Preenchido, é obrigatorio a passagem de para de paramentro ID do registro
        /// </summary>
        /// <param name="_contrato">codigo do registro</param>
        /// <returns>retorna um objeto preenchido</returns>
        public FileSafe GetFileSafe(string _parametro, string _tela)
        {
             FileSafeData fs = new FileSafeData();
             FileSafe obj = fs.GetFileSafe(_parametro, _tela).FirstOrDefault();
            return obj;
        }

        public List<FileSafe> GetFilesAll(string _parametro, char _typeContract, DateTime[] _datasParam = null)
        {
            FileSafeData fs = new FileSafeData();
            List<FileSafe> lst = fs.GetFilesAll(_parametro, _typeContract, _datasParam);
            return lst;
        }

        public List<Users> GetUsers(string _userLogin = null)
        {
            FileSafeData fs = new FileSafeData();
            List<Users> lst = fs.GetUsers(_userLogin);
            return lst;
        }

        public void UdtUser(string _login)
        {
            FileSafeData fs = new FileSafeData();
            fs.UdtUser(_login);
        }

        public int DltUser(string _login)
        {
            FileSafeData fs = new FileSafeData();
            return fs.DltUser(_login);
        }

        public int AddUser(Users _user)
        {
            FileSafeData fs = new FileSafeData();
            return fs.AddUser(_user);
        }

        public Users CheckUser(string _login)
        {
            FileSafeData fs = new FileSafeData();
            return fs.CheckUser(_login);
        }

        public void RemoveDuplicateRegister()
        {
            FileSafeData fs = new FileSafeData();
            fs.RemoveDuplicateRegister();
        }

        public List<long> GetNumberContract(int _tela)
        {
            FileSafeData fs = new FileSafeData();
            return fs.GetNumberContract(_tela);
        }
    }
}
