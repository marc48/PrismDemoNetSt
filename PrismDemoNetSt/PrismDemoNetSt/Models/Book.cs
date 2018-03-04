using Newtonsoft.Json;

namespace PrismDemoNetSt.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string FirstName { get; set; }
        public bool Read { get; set; }
    }
}
