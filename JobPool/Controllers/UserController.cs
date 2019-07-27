using JobPool.Models;
using JobPool.UnitOfWorkModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPool.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var jobsForCandidate = _unitOfWork.GeneralRepository.JobsForCandidate();
            return View(jobsForCandidate);
        }
        //[HttpPost]
        //public ActionResult Index(string query)
        //{
        //    var jobsForCandidate = _unitOfWork.GeneralRepository.JobsForCandidate();
        //    return View(jobsForCandidate);
        //}
        [Authorize]
        public ActionResult Apply(Guid id)
        {        
            var job = _unitOfWork.GeneralRepository.GetJobForAppling(id);
            return View(job);
        }
        [HttpPost]
        public ActionResult ApplyById(Guid id)
        {
            var userId = User.Identity.GetUserId();

            var exists = _unitOfWork.GeneralRepository.GetAppliedDetails(userId, id);
            if (exists)
            {
                return Json(new { message = "Already Applied" });
            }
            var i = _unitOfWork.GeneralRepository.ApplyForJob(userId, id);
            return Json(new {message="SuccessFully Applied" });
        }

        public ActionResult SearchByUser(PostedJob postedJob)
        {
            var job = _unitOfWork.GeneralRepository.SearchJobsUsingCondition(postedJob);

            return View("Index",job);
        }

    }
}