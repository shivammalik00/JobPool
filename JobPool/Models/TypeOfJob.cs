using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPool.Models
{
    public class TypeOfJob
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NameTypeOfJOb { get; set; }
    }
}