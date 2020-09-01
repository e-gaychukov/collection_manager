
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string SupporterId { get; set; }

        public int ItemId { get; set; }
        public Item LikedItem { get; set; }
    }
}
