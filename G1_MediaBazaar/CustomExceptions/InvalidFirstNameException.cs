namespace CustomExceptions
{
    public class InvalidFirstNameException : Exception
    {
        public InvalidFirstNameException(string message):base(message) { }
    }
}