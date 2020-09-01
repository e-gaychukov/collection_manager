using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfAdding { get; set; }
        public string AuthorId { get; set; }

        public int ItemId { get; set; }
        public Item CommentedItem { get; set; }
    }
}
