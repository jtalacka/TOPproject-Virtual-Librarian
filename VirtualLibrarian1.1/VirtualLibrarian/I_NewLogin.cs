using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    public interface I_NewLogin
    {
        string login(string username, string pass);
        string signup(string name, string surname,
                      string username, string pass, string birth, string email);
        int inputCheck(string whatToCheck, int c);
        bool checkIfExistsInDBUsers(string whatToLookFor);

    }
}
