namespace SunamoOctokit._public;

/// <summary>
/// Wrapper class that holds either a successful result or an exception message from Octokit operations.
/// </summary>
/// <typeparam name="T">The type of the successful result data.</typeparam>
public class ResultWithExceptionOctokit<T>
{
    /// <summary>
    /// Gets or sets the successful result data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the exception text if the operation failed.
    /// </summary>
    public string? ExceptionText { get; set; }

    /// <summary>
    /// Initializes a new instance with successful result data.
    /// </summary>
    /// <param name="data">The successful result data.</param>
    public ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance with an exception text.
    /// </summary>
    /// <param name="exceptionText">The exception message text.</param>
    public ResultWithExceptionOctokit(string exceptionText)
    {
        ExceptionText = exceptionText;
    }

    /// <summary>
    /// Initializes a new instance with an exception object, extracting its message text.
    /// </summary>
    /// <param name="exception">The exception to extract text from.</param>
    public ResultWithExceptionOctokit(Exception exception)
    {
        ExceptionText = Exceptions.TextOfExceptions(exception);
    }

    /// <summary>
    /// Initializes a new empty instance.
    /// </summary>
    public ResultWithExceptionOctokit()
    {
    }
}
