using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Models
{
    public class Comment
    {
        public string PointerID { get; set; }

        public string Text { get; set; }
        public DateTime TimeAdded { get; set; }
        public string User { get; set; }
        public string UserID { get; set; }

        public string Name { get; set; }
    }
}
