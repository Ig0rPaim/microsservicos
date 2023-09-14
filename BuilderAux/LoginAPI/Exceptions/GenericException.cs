namespace LoginAPI.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException()
        {
        }

        public GenericException(string mensagem) : base(mensagem)
        {
        }

        public GenericException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
        {
        }
    }
}
