namespace SunamoOctokit.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octokit;

/// <summary>
/// Unit tests for <see cref="OctokitHelper"/> class.
/// </summary>
[TestClass]
public class OctokitHelperTests
{
    /// <summary>
    /// Tests that Initialize creates a valid GitHubClient instance.
    /// </summary>
    [TestMethod]
    public void InitializeCreatesGitHubClientTest()
    {
        var octokitHelper = new OctokitHelper();
        octokitHelper.Initialize("TestApp");
        Assert.IsNotNull(octokitHelper.GitHubClient);
    }

    /// <summary>
    /// Tests that BasicAuthenticate sets credentials on the GitHubClient.
    /// </summary>
    [TestMethod]
    public void BasicAuthenticateSetsCredentialsTest()
    {
        var octokitHelper = new OctokitHelper();
        octokitHelper.Initialize("TestApp");
        octokitHelper.BasicAuthenticate("testuser", "testpassword");
        Assert.IsNotNull(octokitHelper.GitHubClient.Credentials);
        Assert.AreEqual(AuthenticationType.Basic, octokitHelper.GitHubClient.Credentials.AuthenticationType);
    }

    /// <summary>
    /// Tests that TokenAuthenticate sets credentials on the GitHubClient.
    /// </summary>
    [TestMethod]
    public void TokenAuthenticateSetsCredentialsTest()
    {
        var octokitHelper = new OctokitHelper();
        octokitHelper.Initialize("TestApp");
        octokitHelper.TokenAuthenticate("test-token");
        Assert.IsNotNull(octokitHelper.GitHubClient.Credentials);
        Assert.AreEqual(AuthenticationType.Oauth, octokitHelper.GitHubClient.Credentials.AuthenticationType);
    }

    /// <summary>
    /// Tests that Initialize returns the instance for method chaining.
    /// </summary>
    [TestMethod]
    public void InitializeReturnsSelfForChainingTest()
    {
        var octokitHelper = new OctokitHelper();
        var authenticator = octokitHelper.Initialize("TestApp");
        Assert.IsNotNull(authenticator);
    }

    /// <summary>
    /// Tests that CreateRepository without authentication returns an exception result.
    /// </summary>
    [TestMethod]
    public void CreateRepositoryWithoutAuthReturnsExceptionTest()
    {
        var octokitHelper = new OctokitHelper();
        octokitHelper.Initialize("TestApp");
        var result = octokitHelper.CreateRepository("TestRepo");
        Assert.IsNotNull(result.ExceptionText);
        Assert.IsNull(result.Data);
    }
}
