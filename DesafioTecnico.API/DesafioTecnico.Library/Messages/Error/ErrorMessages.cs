namespace DesafioTecnico.Library.Messages.Error
{
    public static class ErrorMessages
    {
        public static string InternalError = "Ocorreu um erro inesperado, se persistir contate o administrador";

        public static string NullCityValidate = "Preenchimento obrigatório do nome da cidade e UF";

        public static string NullOrEmptyCityNameValidate = "Preenchimento obrigatório do nome da Cidade";

        public static string NullOrEmptyCityUFValidate = "Preenchimento obrigatório do UF da Cidade";

        public static string CityNotFound = "Cidade não encontrada";

        public static string CityWithClient = "Está cidade possui clientes cadastrados não podendo ser excluida";

        public static string UFLengthError = "UF está fora do padrão que é de dois caracteres";

        public static string CityAlreadyRegistered = "Está cidade já castrada anteriormente";

        public static string ClientNotFound = "Cliente não encontrado";
        
        public static string NullClientValidate = "Dados não preenchido";
        
        public static string NullOrEmptyClientNameValidate = "Nome é obrigatorio para cliente";
        
        public static string NullOrEmptyClientUFValidate = "Cidade deve ser informada para cadastro de cliente";
        
        public static string NullOrEmptyClientGenderValidate = "Sexo deve ser informado para cadastro do cliente";
        
        public static string CityReferenceError = "cidade não encontrada durante cadastro de cliente";
    }
}
