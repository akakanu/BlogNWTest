using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNWTest.Models
{
    public class Blog
    {
        public Post Post { get; set; }
        public Categorie Categorie { get; set; }
        public List<Categorie> categories { get; set; }
        public List<Post> posts { get; set; }

    }
}
