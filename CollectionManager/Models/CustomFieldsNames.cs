using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models
{
    public class CustomFieldsNames
    {
        public string NumberFieldName1 { get; set; }
        public string NumberFieldName2 { get; set; }
        public string NumberFieldName3 { get; set; }

        public string StringFieldName1 { get; set; }
        public string StringFieldName2 { get; set; }
        public string StringFieldName3 { get; set; }


        public string MultilineStringFieldName1 { get; set; }
        public string MultilineStringFieldName2 { get; set; }
        public string MultilineStringFieldName3 { get; set; }

        
        [DataType(DataType.DateTime)]
        public string DateFieldName1 { get; set; }

        [DataType(DataType.DateTime)]
        public string DateFieldName2 { get; set; }

        [DataType(DataType.DateTime)]
        public string DateFieldName3 { get; set; }


        public string BooleanFieldName1 { get; set; }
        public string BooleanFieldName2 { get; set; }
        public string BooleanFieldName3 { get; set; }
    }
}
