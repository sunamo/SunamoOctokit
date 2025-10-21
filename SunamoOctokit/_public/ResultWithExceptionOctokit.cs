// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
namespace SunamoOctokit._public;


public class ResultWithExceptionOctokit<T>
{
    public T Data { get; set; }




    public string exception { get; set; }
    public ResultWithExceptionOctokit(T data)
    {
        Data = data;
    }
    public ResultWithExceptionOctokit(string exc)
    {
        this.exception = exc;
    }
    public ResultWithExceptionOctokit(Exception exc)
    {
        this.exception = Exceptions.TextOfExceptions(exc);
    }



    public ResultWithExceptionOctokit()
    {
    }
}