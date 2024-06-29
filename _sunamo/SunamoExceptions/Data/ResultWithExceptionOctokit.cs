namespace SunamoOctokit;


public class ResultWithExceptionOctokit<T>
{
    internal T Data { get; set; }
    /// <summary>
    ///     only string, because Message property isn't editable after instatiate
    ///     Usage: FubuCsprojFile
    /// </summary>
    internal string exc { get; set; }
    internal ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }
    internal ResultWithExceptionOctokit(string exc)
    {
        this.exc = exc;
    }
    internal ResultWithExceptionOctokit(Exception exc)
    {
        this.exc = Exceptions.TextOfExceptions(exc);
    }
    /// <summary>
    /// Pro případ že data josu string což je typ i exception
    /// </summary>
    internal ResultWithExceptionOctokit()
    {
    }
}