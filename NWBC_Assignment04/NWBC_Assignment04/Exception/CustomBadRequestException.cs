namespace NWBC_Assignment04.Exception;

public class CustomBadRequestException : System.Exception
{
    public CustomBadRequestException(string message) : base(message) { }
}