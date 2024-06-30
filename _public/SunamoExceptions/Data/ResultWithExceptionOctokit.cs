namespace SunamoOctokit;


public class ResultWithExceptionOctokit<T>
{
    public T Data { get; set; }
    
    
    
    
    public string exc { get; set; }
    public ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }
    public ResultWithExceptionOctokit(string exc)
    {
        this.exc = exc;
    }
    public ResultWithExceptionOctokit(Exception exc)
    {
        this.exc = Exceptions.TextOfExceptions(exc);
    }
    
    
    
    public ResultWithExceptionOctokit()
    {
    }
}