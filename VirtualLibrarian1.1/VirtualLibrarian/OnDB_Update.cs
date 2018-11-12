using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class OnDB_Update
    {

        I_InLibrary Lib = new Library();

        //define an event
        public delegate void load();
        event load loadL;

        //this event will invoke a delegate to reload lists after it's been raised
        public void UpadateEvent()
        {
            loadL += Lib.loadLibraryBooks;
            loadL += Lib.loadReaders;
            loadL.Invoke();
        }
    }
}
