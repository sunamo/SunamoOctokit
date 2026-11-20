namespace SunamoOctokit._public;

/// <summary>
/// Represents the result with exception octokit t type.
/// </summary>
public class ResultWithExceptionOctokit<T>
{
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the exception text.
    /// </summary>
    public string? ExceptionText { get; set; }

    /// <summary>
    /// Result with exception octokit.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>The result with exception octokit result.</returns>
    public ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception octokit class.
    /// </summary>
    /// <param name="data">The data.</param>
    public ResultWithExceptionOctokit(string exceptionText)
    {
        ExceptionText = exceptionText;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception octokit class.
    /// </summary>
    /// <param name="exceptionText">The exception text.</param>
    public ResultWithExceptionOctokit(Exception exception)
    {
        ExceptionText = Exceptions.TextOfExceptions(exception);
    }

    /// <summary>
    /// Initializes a new instance of the result with exception octokit class.
    /// </summary>
    /// <param name="exception">The exception.</param>
    public ResultWithExceptionOctokit()
    {
    }
}
