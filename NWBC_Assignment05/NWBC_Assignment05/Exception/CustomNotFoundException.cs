namespace NWBC_Assignment05.Exception;

public class CustomNotFoundException : System.Exception
{
    public CustomNotFoundException(string message) : base(message) { }
}