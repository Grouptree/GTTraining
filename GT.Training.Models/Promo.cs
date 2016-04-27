using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Models
{
    public class Promo
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Copy { get; set; }
        public string URL { get; set; }
        public List<string> Tags { get; set; }
    } 
}
