
using System.ComponentModel.DataAnnotations;
namespace WebAPIConsume.Models
{
    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
    }
}
