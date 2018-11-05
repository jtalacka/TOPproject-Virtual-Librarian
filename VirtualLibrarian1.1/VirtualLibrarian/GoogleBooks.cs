using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Books.v1;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VirtualLibrarian
{
   public class GoogleBooks
    {
        public static async Task<Book> Search(string isbn)
        {
            var service = new BooksService(new BaseClientService.Initializer()
            {
                // HttpClientInitializer = credential,
                ApplicationName = "Books API Sample",
            });
            var volumes = await service.Volumes.List(isbn).ExecuteAsync();
            try
            {
                foreach (var item in volumes.Items)
                {
                    MessageBox.Show(item.VolumeInfo.Title);
                    foreach (var author in item.VolumeInfo.Authors)
                    {
                        return new Book(isbn, item.VolumeInfo.Title,author,null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("No books was found with this isbn");
            }
            return null;
        }


    }
}
