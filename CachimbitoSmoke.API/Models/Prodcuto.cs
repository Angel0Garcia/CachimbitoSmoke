using Microsoft.EntityFrameworkCore;

namespace CachimbitoSmoke.API.Models
{
    public class Prodcuto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        
    }
}
