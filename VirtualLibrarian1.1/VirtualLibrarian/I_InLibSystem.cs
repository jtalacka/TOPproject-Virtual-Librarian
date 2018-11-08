using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    interface I_InLibSystem
    {
        bool checkIfExistsInDBBooks(string whatToLookFor);
        void addBook(Book book, List<string> checkedGenres);
        void editBook(string COMMAND);
        List<string> allTakenBooks();
        string searchR(string searchInfo, User currentU);
        void deleteBookFromReader(string COMMAND, string[] splitInfo);

    }
}
