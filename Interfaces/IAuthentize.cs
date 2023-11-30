using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoOctokit.Interfaces;
public interface IAuthentize<T>
{
    T BasicAuth(string login, string password);
    T TokenAuth(string token);
}
