using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIConsume.Models;

namespace WebAPIConsume.ViewModels
{
    public class JokeRequestURLVM
    {
        public string category { get; set; }
        public string language { get; set; }
        public string format { get; set; }
        public Joke joke { get; set; }
        public Flags flags  { get; set; }
        public int amount   { get; set; }
    }
}
