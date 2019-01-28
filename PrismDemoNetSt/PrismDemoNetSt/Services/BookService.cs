using System; 
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PrismDemoNetSt.Models;

namespace PrismDemoNetSt.Services
{
    public class BookService : IBookService
    {
        public async Task<List<Book>> GetBooks()
        {
            // Read json from Data folder
            var name = typeof(BookService).AssemblyQualifiedName.Split(',')[1].Trim();
            var assembly = Assembly.Load(new AssemblyName(name));
            var stream = assembly.GetManifestResourceStream(name + ".Data.Booklist1.json");

            // Parse the JSON and generate book objects
            using (var reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                var obj = new { Books = new List<Book>() };
                var result = JsonConvert.DeserializeAnonymousType(json, obj);
                return result.Books;
            }
        }
    }
}
