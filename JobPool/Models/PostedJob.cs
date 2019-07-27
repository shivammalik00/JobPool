using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPool.Models
{
    public class PostedJob
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]

        public string TypeOfJob_ID { get; set; }
        //[ForeignKey("TypeOfJob_ID")]
        //public TypeOfJob TypeOfJob { get; set; }


        [Required]
        public int State_Id { get; set; }
        [ForeignKey("State_Id")]
        public State State { get; set; }


        [Required]
        [StringLength(100)]
        public string Skill  { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set; }

        [Required]
        public DateTime ValidTill { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [StringLength(50)]
        public string JobCategory { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
         
        public bool IsCanceled { get; set; }

        [Required]
        [StringLength(20)]
        public string experience { get; set; }

        [Required]
        [StringLength(20)]
        public string salary { get; set; }

    }
}