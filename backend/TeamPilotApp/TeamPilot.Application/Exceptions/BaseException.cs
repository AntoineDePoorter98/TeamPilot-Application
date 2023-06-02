namespace TeamPilot.Application.Exceptions;

public abstract class BaseException : Exception
{
    public BaseException(string message = "Error") : base(message)
    {
    }
}
