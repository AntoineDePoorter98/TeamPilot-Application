namespace TeamPilot.Application.Exceptions;

public class IllegalFieldFoundException : BaseException
{
    public IllegalFieldFoundException(string message = "Request not valid") : base(message)
    {
    }
}
