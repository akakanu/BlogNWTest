using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogNWTest.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        //[Column("varchar(100)")]
        public string Title { get; set; }
        //[Column("nvarchar(250)")]
        public string Content { get; set; }
        public DateTime PulicationDate { get; set; }
        [ForeignKey]
        public virtual Categorie Categorie { get; set; }
    }

    public enum TeaType
    {
        Tea, Coffee, GreenTea, BlackTea
    }
}
