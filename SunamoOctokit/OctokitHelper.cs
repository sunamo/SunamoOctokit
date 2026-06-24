namespace SunamoOctokit;

public class OctokitHelper : IAuthenticate<object>
{
    public GitHubClient GitHubClient { get; set; } = null!;

    public object BasicAuthenticate(string login, string password)
    {
        var credentials = new Credentials(login, password);
        GitHubClient.Credentials = credentials;
        return null!;
    }

    public object TokenAuthenticate(string token)
    {
        GitHubClient.Credentials = new Credentials(token);
        return null!;
    }

    public IAuthenticate<object> Initialize(string appName)
    {
        GitHubClient = new GitHubClient(new ProductHeaderValue(appName));
        return this;
    }

    public
        async Task<IReadOnlyList<Repository>>
        GetAccountRepositories(string account, bool isIncludingPrivate)
    {
        IReadOnlyList<Repository> repositories = [];

        if (isIncludingPrivate)
        {
            repositories =
            await
                GitHubClient.Repository.GetAllForUser(account);
        }
        else
        {
            repositories =
                await
                GitHubClient.Repository.GetAllForCurrent();
        }
        return repositories;
    }

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
