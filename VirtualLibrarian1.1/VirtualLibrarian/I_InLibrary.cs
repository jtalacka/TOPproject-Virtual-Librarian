using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    interface I_InLibrary
    {
        void loadLibraryBooks();
        void loadReaders();

        string searchAuthororTitle(string searchInfo, Book currentBook);

        List<string> genresSelected(CheckedListBox.CheckedItemCollection checkedItems);
        string genresToDisplay(List<string> genres);

        void takeORGiveBook(string[] splitInfo, string user, int quo);
        List<string> reccomendations(string username);

        void updateReaderInfo(string COMMAND);
        List<string> selectTakenBooks(string user);

    }
}
