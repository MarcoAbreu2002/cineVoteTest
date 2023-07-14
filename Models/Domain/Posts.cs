using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineVote.Models.Domain
{
    [Table("tblPosts")]
    public class Posts
    {
        [Key]
        [Column("PostsId")]
        public int PostsId { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [ForeignKey("userName")]
        [Column("userName")]
        public string userName { get; set; }

        [Column("User")]
        public User User { get; set; }

        [Column("Comments")]
        public List<Comments>? Comments { get; set; }


    }
}
