using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int TaggedItemId { get; set; }
        public Item TaggedItem { get; set; }
    }
}
