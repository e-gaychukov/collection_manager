using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CollectionManager.Models
{
    public class Collection
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }
        public string ImageReference { get; set; }
        public CustomFieldsNames CustomFieldsNames { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }

        public List<Item> Items { get; set; }
    }
}
