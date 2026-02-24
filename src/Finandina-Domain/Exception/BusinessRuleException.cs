namespace Finandina_Domain.Exception
{
    public class BusinessRuleException : System.Exception
    {
        public BusinessRuleException()
        {

        }

        public BusinessRuleException(string? message) : base(message)
        {

        }

        public BusinessRuleException(string errorCode, string? message) : base($"{errorCode}: {message}")
        {

        }
    }
}
