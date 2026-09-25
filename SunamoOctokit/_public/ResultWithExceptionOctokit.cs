namespace SunamoOctokit._public;

public class ResultWithExceptionOctokit<T>
{
    public T? Data { get; set; }

    public string? ExceptionText { get; set; }

    public ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }

    public ResultWithExceptionOctokit(string exceptionText)
    {
        ExceptionText = exceptionText;
    }

    public ResultWithExceptionOctokit(Exception exception)
    {
        ExceptionText = Exceptions.TextOfExceptions(exception);
    }

    public ResultWithExceptionOctokit()
    {
    }
}
