namespace NWBC_Assignment05.Exception;

public class CustomBadRequestException : System.Exception
{
    public CustomBadRequestException(string message) : base(message) { }
}