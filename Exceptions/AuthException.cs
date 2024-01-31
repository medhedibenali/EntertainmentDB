namespace EntertainmentDB.Exceptions;

public class AuthException : Exception
{
    public required IDictionary<string, string> Errors { get; set; }

    public AuthException() : base() { }

    public AuthException(string? message) : base(message) { }

    public AuthException(string? message, Exception? innerException) : base(message, innerException) { }
}
