namespace SunamoOctokit.Tests;


public class OctokitHelperTests
{
    [Fact]
    public void CreateNewRepoTest()
    {
        OctokitHelper h = new OctokitHelper();
        /*
Zde se registruje nov� app https://github.com/settings/apps/new
OAUth apps https://github.com/settings/developers
GitHub Apps https://github.com/settings/apps

        Proto se mo�n� mus� jmenovat ConsoleApp1


        */
        h.Init("ConsoleApp1").TokenAuth("TOKEN");

        var result = h.CreateNewRepo("SunamoCsproj");
        if (result.exc != null)
        {
            // josu data


        }
        else
        {
            // je chyba

        }

    }
}
