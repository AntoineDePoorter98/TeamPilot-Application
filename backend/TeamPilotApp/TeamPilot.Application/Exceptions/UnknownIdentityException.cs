namespace TeamPilot.Application.Exceptions;

public class UnknownIdentityException : BaseException
{
    public UnknownIdentityException(string message = "Unable to authenticate") : base(message)
    {

    }
}
