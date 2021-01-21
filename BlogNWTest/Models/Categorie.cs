using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNWTest.Models
{
    public class Categorie
    {
        public Categorie(string str) {
            Title = str;
        }
        public Categorie()
        {
            
        }
        public int CategorieId { get; set; }
        public string Title { get; set; }
        public List<Post> posts { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
