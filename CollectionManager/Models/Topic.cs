using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Collection> Collections { get; set; }
    }
}
