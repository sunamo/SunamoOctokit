namespace SunamoOctokit;

/// <summary>
/// Helper class for interacting with GitHub API through Octokit library.
/// </summary>
public class OctokitHelper : IAuthenticate<object>
{
    /// <summary>
    /// Gets or sets the GitHub client instance used for API communication.
    /// </summary>
    public GitHubClient GitHubClient { get; set; } = null!;

    /// <summary>
    /// Authenticates using basic credentials (login and password).
    /// </summary>
    /// <param name="login">The GitHub login username.</param>
    /// <param name="password">The GitHub password.</param>
    /// <returns>Always returns null.</returns>
    public object BasicAuthenticate(string login, string password)
    {
        var credentials = new Credentials(login, password);
        GitHubClient.Credentials = credentials;
        return null!;
    }

    /// <summary>
    /// Authenticates using a personal access token.
    /// </summary>
    /// <param name="token">The GitHub personal access token.</param>
    /// <returns>Always returns null.</returns>
    public object TokenAuthenticate(string token)
    {
        GitHubClient.Credentials = new Credentials(token);
        return null!;
    }

    /// <summary>
    /// Initializes the GitHub client with the specified application name.
    /// </summary>
    /// <param name="appName">The application name used in the product header for API requests.</param>
    /// <returns>The current instance as <see cref="IAuthenticate{T}"/>.</returns>
    public IAuthenticate<object> Initialize(string appName)
    {
        GitHubClient = new GitHubClient(new ProductHeaderValue(appName));
        return this;
    }

    /// <summary>
    /// Gets repositories for the specified account or the current authenticated user.
    /// When <paramref name="isIncludingPrivate"/> is true, fetches repositories for the specified account.
    /// When false, fetches all repositories for the currently authenticated user.
    /// </summary>
    /// <param name="account">The GitHub account name to fetch repositories for.</param>
    /// <param name="isIncludingPrivate">When true, fetches repositories for the specified account. When false, fetches all repositories for the currently authenticated user.</param>
    /// <returns>A read-only list of repositories.</returns>
    public
#if ASYNC
        async Task<IReadOnlyList<Repository>>
#else
        void
#endif
        GetAccountRepositories(string account, bool isIncludingPrivate)
    {
        IReadOnlyList<Repository> repositories = [];

        if (isIncludingPrivate)
        {
            repositories =
#if ASYNC
            await
#endif
                GitHubClient.Repository.GetAllForUser(account);
        }
        else
        {
            repositories =
#if ASYNC
                await
#endif
                GitHubClient.Repository.GetAllForCurrent();
        }
        return repositories;
    }

    /// <summary>
    /// Creates a new public repository on GitHub with MIT license.
    /// </summary>
    /// <param name="repositoryName">The name of the repository to create.</param>
    /// <returns>A result containing the created repository or an exception message.</returns>
    public ResultWithExceptionOctokit<Repository> CreateRepository(string repositoryName)
    {
        try
        {
            var newRepository = new NewRepository(repositoryName)
            {
                AutoInit = false,
                Description = "",
                LicenseTemplate = "mit",
                Private = false
            };
            var createTask = GitHubClient.Repository.Create(newRepository);
            var createdRepository = createTask.Result;
            return new ResultWithExceptionOctokit<Repository>(createdRepository);
        }
        catch (AggregateException aggregateException)
        {
            Console.WriteLine($"Failed to create repository: {aggregateException.Message}");
            return new ResultWithExceptionOctokit<Repository>(Exceptions.TextOfExceptions(aggregateException));
        }
    }
}
