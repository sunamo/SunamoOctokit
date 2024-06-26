namespace SunamoOctokit;

public interface IAuthentize<T>
{
    T BasicAuth(string login, string password);
    T TokenAuth(string token);
}
