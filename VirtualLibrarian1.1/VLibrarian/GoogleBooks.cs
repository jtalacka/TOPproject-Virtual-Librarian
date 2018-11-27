using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VirtualLibrarian
{
   public class GoogleBooks
    {
      /*  public static async Task<Book> Search(string isbn)
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
                    foreach (var author in item.VolumeInfo.Authors)
                    {
                        return new Book(isbn, item.VolumeInfo.Title, author, null,0);
                    }
                }
            }
            catch
            {
                Console.WriteLine("No book could be found");

            }
            return null;
        }
        */

    }
}
