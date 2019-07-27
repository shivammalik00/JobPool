using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPool.Models
{
    public class JobCategory
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Category { get; set; }
    }
}