using PrismDemoNetSt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismDemoNetSt.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
    }
}