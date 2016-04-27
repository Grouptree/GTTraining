using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT.Training.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TrimmedContent { get; set; }

        public string ImageURL { get; set; }
        public string URL { get; set; }
        public string ArticleDate { get; set; }

        public string[] Tags { get; set; }

    }
}
