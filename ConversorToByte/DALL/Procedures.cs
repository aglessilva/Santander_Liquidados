namespace ConversorToByte.DALL
{
    public enum Procedures
    {
        /// <summary>
        /// Procedure que grava os arquivos PDF. ZIP Binalizados no banco de dados
        /// </summary>
        SP_POST_FILE_SAFE = 0,
        
        /// <summary>
        /// Atualiza Permissão de acesso de usuarios ao sistema
        /// </summary>
        SP_UDT_USERS = 1,

        /// <summary>
        /// Adiciona um novo usuario ao sistema
        /// </summary>
        SP_POST_USERS = 2,

        /// <summary>
        /// Retorna uma lista de usuários do sistema
        /// </summary>
        SP_GET_USERS = 3,

        /// <summary>
        /// Retorna o caminho fisico dos arquivos
        /// </summary>
        SP_GET_PATH_COMPANY = 4,


        /// <summary>
        /// Retorna uma lista de registro
        /// </summary>
        SP_GET_FILES = 5,

        /// <summary>
        /// retorna um allista de empresas fornecedoreas de contratos
        /// </summary>
        SP_GET_COMPANY = 6,

        /// <summary>
        /// verifica se o usuario logado pode acessar o sistema
        /// </summary>
        SP_CHK_USER = 7,

        /// <summary>
        /// checa e o usuario atual tem permissão de acesso ao sistema
        /// </summary>
        SP_CHK_PERMICAO = 8,

        /// <summary>
        /// Remove usuário do sistema
        /// </summary>
        SP_DLT_USERS = 9,

        /// <summary>
        /// Seleciona todas as telas 16,18,20,25
        /// </summary>
        SP_GET_FILES_T16_T18_T20_T25_T34 = 10,

        /// <summary>
        /// Faz o  download do contrato de todas as telas
        /// </summary>
        SP_DOWNLOAD_FILES = 11,

        /// <summary>
        /// Remove os registros duplicados das tabelas
        /// </summary>
        SP_REMOVE_REGISTRO_DUPLICADOS = 12,

        /// <summary>
        /// Retorna somente o numero de todos os contratos
        /// </summary>
        SP_GET_NUMBER_CONTRACT = 13

    }

}
