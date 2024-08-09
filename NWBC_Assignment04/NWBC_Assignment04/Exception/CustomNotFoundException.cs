namespace NWBC_Assignment04.Exception;

public class CustomNotFoundException : System.Exception
{
    public CustomNotFoundException(string message) : base(message) { }
}