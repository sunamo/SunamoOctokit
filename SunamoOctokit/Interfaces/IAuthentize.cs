namespace SunamoOctokit.Interfaces;

public interface IAuthenticate<T>
{
    T BasicAuthenticate(string login, string password);

    T TokenAuthenticate(string token);
}
