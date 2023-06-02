namespace TeamPilot.Application.Exceptions;

public class UnknownResourceException : BaseException
{
    public UnknownResourceException(string message = "Resource Not Found") : base(message)
    {
    }
}
