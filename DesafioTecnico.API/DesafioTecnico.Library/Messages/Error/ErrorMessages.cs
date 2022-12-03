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
        public static string ClientNotFound;
        public static string NullClientValidate;
        public static string NullOrEmptyClientNameValidate;
        public static string NullOrEmptyClientUFValidate;
        public static string NullOrEmptyClientGenderValidate;
        public static string GenderLengthCaracterError;
        public static string CityReferenceError;
    }
}
