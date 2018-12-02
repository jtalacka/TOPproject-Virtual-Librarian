namespace VLibrarian
{
   public interface I_NewLogin
    {
        string login(string username, string pass);
        string signup(string username, string pass,
                                    string name, string surname, string birth, string email);
        int inputCheck(string whatToCheck, int c);
        bool checkIfExistsInDBUsers(string whatToLookFor);
        


    }
}