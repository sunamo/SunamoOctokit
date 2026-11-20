namespace SunamoOctokit.Interfaces;

/// <summary>
/// Represents the i authenticate t type.
/// </summary>
public interface IAuthenticate<T>
{
    /// <summary>
    /// Basic authenticate.
    /// </summary>
    /// <param name="login">The login.</param>
    /// <param name="password">The password.</param>
    /// <returns>The basic authenticate result.</returns>
    T BasicAuthenticate(string login, string password);

    /// <summary>
    /// Token authenticate.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>The token authenticate result.</returns>
    T TokenAuthenticate(string token);
}
