namespace SunamoOctokit.Interfaces;

/// <summary>
/// Interface for GitHub authentication methods.
/// </summary>
/// <typeparam name="T">The return type for authentication methods.</typeparam>
public interface IAuthenticate<T>
{
    /// <summary>
    /// Authenticates using basic credentials (login and password).
    /// </summary>
    /// <param name="login">The GitHub login username.</param>
    /// <param name="password">The GitHub password.</param>
    /// <returns>Authentication result of type <typeparamref name="T"/>.</returns>
    T BasicAuthenticate(string login, string password);

    /// <summary>
    /// Authenticates using a personal access token.
    /// </summary>
    /// <param name="token">The GitHub personal access token.</param>
    /// <returns>Authentication result of type <typeparamref name="T"/>.</returns>
    T TokenAuthenticate(string token);
}
