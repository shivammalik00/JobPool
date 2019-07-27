using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobPool.Models
{
    public class JobApplied
    {
        public PostedJob PostedJob { get; set; }
        public ApplicationUser JobApplier { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid PostedJobId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string JobApplierId { get; set; }
    }
}