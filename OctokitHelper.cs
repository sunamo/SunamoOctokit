namespace SunamoOctokit;

public class OctokitHelper : IAuthentize<object>
{
    public GitHubClient github;
    public object BasicAuth(string login, string password)
    {
        var basicAuth = new Credentials(login, password);
        github.Credentials = basicAuth;
        return null;
    }
    public object TokenAuth(string token)
    {
        github.Credentials = new Credentials(token);
        return null;
    }
    public
        IAuthentize<object>
        Init(string appName)
    {
        github = new GitHubClient(new ProductHeaderValue(appName));
        //if (credentials.Login != null)
        //{
        //}
        //else if (credentials.Token != null)
        //{
        //}
        //else
        //{
        //    throw new Exception("Can't authentize, was not entered basic auth and token");
        //}
        return this;
    }

    /// <summary>
    /// When alsoPrivate, account is ignored
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public
#if ASYNC
        async Task<IReadOnlyList<Repository>>
#else
void
#endif
        GetAccountRepos(string account, bool alsoPrivate)
    {
        IReadOnlyList<Repository> repos = [];

        if (alsoPrivate)
        {
            repos =
#if ASYNC
            await
#endif
                github.Repository.GetAllForUser(account);
        }
        else
        {
            repos = await github.Repository.GetAllForCurrent();
        }
        return repos;
    }
    public ResultWithExceptionOctokit<Repository> CreateNewRepo(string repoName)
    {
        Repository created = null;
        // Create
        try
        {
            var repository = new NewRepository(repoName)
            {
                AutoInit = false,
                Description = "",
                LicenseTemplate = "mit",
                Private = false
            };
            var context = github.Repository.Create(repository);
            created = context.Result;
            return new ResultWithExceptionOctokit<Repository>(created);
        }
        catch (AggregateException e)
        {
            return new ResultWithExceptionOctokit<Repository>(Exceptions.TextOfExceptions(e));
            //Console.WriteLine($"E: For some reason, the repository {RepositoryName}  can't be created. It may already exist. {e.Message}");
        }
    }
}