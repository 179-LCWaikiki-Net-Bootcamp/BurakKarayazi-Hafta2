using System;
using System.ComponentModel.DataAnnotations;

namespace GenericCrud.Models
{
    public class EntityBase
    {
        //[RegularExpression(@"0-9+",ErrorMessage ="Id must be a positive number")]
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
