using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class CustomFieldsValues
    {
        public long? NumberFieldValue1 { get; set; }
        public long? NumberFieldValue2 { get; set; }
        public long? NumberFieldValue3 { get; set; }

        public string StringFieldValue1 { get; set; }
        public string StringFieldValue2 { get; set; }
        public string StringFieldValue3 { get; set; }

        public string MultilineStringFieldValue1 { get; set; }
        public string MultilineStringFieldValue2 { get; set; }
        public string MultilineStringFieldValue3 { get; set; }

        public DateTime? DateFieldValue1 { get; set; }
        public DateTime? DateFieldValue2 { get; set; }
        public DateTime? DateFieldValue3 { get; set; }

        public bool? BooleanFieldValue1 { get; set; }
        public bool? BooleanFieldValue2 { get; set; }
        public bool? BooleanFieldValue3 { get; set; }
    }
}
