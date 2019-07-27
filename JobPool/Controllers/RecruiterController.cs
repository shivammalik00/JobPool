using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPool.Models;
using JobPool.UnitOfWorkModel;
using JobPool.ViewModels;
using Microsoft.AspNet.Identity;

namespace JobPool.Controllers
{
    public class RecruiterController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public RecruiterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public ActionResult DashBoard()
        {
            var UserId = User.Identity.GetUserId();
            var JobsOfUser = _unitOfWork.GeneralRepository.GetJobsOfRecruiter(UserId);
            return View(JobsOfUser);
        }


        [Authorize]
        public ActionResult AddJob()
        {
            var model = new JobFormViewModel
            {
                State = _unitOfWork.GeneralRepository.GetStateList(),
                //TypeOfJobs = _unitOfWork.GeneralRepository.GetTypeOfJobList()
                Heading = "Post Job",
                Action = "AddJob"
            };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddJob(JobFormViewModel viewModel)
        {

            var postedJob = new PostedJob
            {
                Id = Guid.NewGuid(),
                UserId = User.Identity.GetUserId(),
                JobTitle = viewModel.JobTitle,
                Description = viewModel.Description,
                Designation = viewModel.Designation,
                State_Id = viewModel.State_Id,
                City = viewModel.City,
                //JobCategory = viewModel.JobCategory,
                Skill = viewModel.Skill,
                TypeOfJob_ID = viewModel.TypeOfJob_Id,
                ValidTill = viewModel.ValidTill,
                IsCanceled = false,
                experience = viewModel.experience,
                salary = viewModel.salary


            };
            var i = _unitOfWork.GeneralRepository.SaveJob(postedJob);

            return RedirectToAction("DashBoard", "Recruiter");
        }

        [Authorize]
        public ActionResult Edit(Guid id)
        {
            var userId = User.Identity.GetUserId();
            var job = _unitOfWork.GeneralRepository.GetJobForEdit(userId, id);
            var viewModel = new JobFormViewModel
            {
                State = _unitOfWork.GeneralRepository.GetStateList(),
                City = job.City,
                Description = job.Description,
                Designation = job.Designation,
                JobCategory = job.JobCategory,
                JobTitle = job.JobTitle,
                Skill = job.Skill,
                State_Id = job.State_Id,
                TypeOfJob_Id = job.TypeOfJob_ID,
                ValidTill = job.ValidTill,
                Heading = "Edit Job",
                Action = "Update"


            };
            return View("AddJob", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(JobFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var i = _unitOfWork.GeneralRepository.UpdateJob(viewModel, userId);
            return RedirectToAction("DashBoard", "Recruiter");

        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAppliers(Guid id)
        {
            var appliedUser = _unitOfWork.GeneralRepository.GetAppliersList(id);
            return View(appliedUser);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ApplierDetails(string userId, Guid jobId)
        {

            var applierDetails = _unitOfWork.GeneralRepository.GetApplierDetails(userId,jobId);
            return View(applierDetails);
        }
    }
}
