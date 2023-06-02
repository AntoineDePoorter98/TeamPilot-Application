namespace TeamPilot.Application.Exceptions;

public class NoAccessException : BaseException
{
    public NoAccessException(string message = "Access Denied") : base(message)
    {

    }
}
