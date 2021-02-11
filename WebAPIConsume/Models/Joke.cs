//using System.ComponentModel.DataAnnotations;
namespace WebAPIConsume.Models
{
    public class Joke
    {
        public string type { get; set; }
        public string joke { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public int id { get; set; }
        public Flags flags { get; set; }
    }
}
