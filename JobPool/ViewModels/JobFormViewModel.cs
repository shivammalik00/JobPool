using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using JobPool.Controllers;
using JobPool.Models;

namespace JobPool.ViewModels
{
    public class JobFormViewModel
    {

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Skills")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "Job Designation")]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Job Valid Till")]
        public DateTime ValidTill { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Job Category")]
        public string JobCategory { get; set; }

        [Required]
        public IEnumerable<State> State { get; set; }
        [Required]
        [Display(Name = "State")]
        public int State_Id { get; set; }

        //[Required]
        //public IEnumerable<TypeOfJob> TypeOfJobs { get; set; }
        [Required]
        [Display(Name = "Type Of Job")]
        public string TypeOfJob_Id { get; set; }

        [Required]
        [Display(Name = "Experience Required")]
        public string experience { get; set; }

        [Required]
        [Display(Name = "Expected Salary")]
        public string salary { get; set; }

        public bool IsActive { get; set; }

        public string Heading { get; set; }

        public string Action { get; set; }

        //public string Action { get; set; }

       
        


    }
}