namespace VLibrarian
{
   public interface I_Helper
    {
        string login(string username, string pass);
        bool checkIfExistsInDBUsers(string whatToLookFor);
        string signup(string username, string pass,
                                    string name, string surname, string birth, string email);


    }
}