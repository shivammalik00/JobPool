using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JobPool.ViewModels;
using Microsoft.AspNet.Identity;

namespace JobPool.Models.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        public IApplicationDbContext ApplicationDbContext { get; }
        public GeneralRepository(IApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public IEnumerable<State> GetStateList()
        {
            return ApplicationDbContext.States.ToList();
        }

        public IEnumerable<TypeOfJob> GetTypeOfJobList()
        {
            return ApplicationDbContext.TypeOfJobs.ToList();
        }

        public int SaveJob(PostedJob postJob)
        {
            try
            {
                ApplicationDbContext.PostedJobs.Add(postJob);
                ApplicationDbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateJob(JobFormViewModel viewModel, string userId)
        {
            try
            {
                var job = ApplicationDbContext.PostedJobs
                    .Single(j => j.Id == viewModel.Id && j.UserId == userId);
                job.City = viewModel.City;
                job.Description = viewModel.Description;
                job.Designation = viewModel.Designation;
                job.JobCategory = viewModel.JobCategory;
                job.JobTitle = viewModel.JobTitle;
                job.Skill = viewModel.Skill;
                job.State_Id = viewModel.State_Id;
                job.TypeOfJob_ID = viewModel.TypeOfJob_Id;
                job.ValidTill = viewModel.ValidTill;

                ApplicationDbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int CancelTheJob(string userId, Guid id)
        {
            try
            {
                var job = ApplicationDbContext.PostedJobs.Single(j => j.Id == id && j.UserId == userId);
                if (job.IsCanceled)
                {
                    return 0;
                }
                else
                    job.IsCanceled = true;

                ApplicationDbContext.SaveChanges();
                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public IEnumerable<PostedJob> GetJobsOfRecruiter(string userID)
        {
            var JobsOfUser = ApplicationDbContext.PostedJobs
                .Where(u => u.UserId == userID && u.ValidTill > DateTime.Now && u.IsCanceled == false);
            return JobsOfUser;
        }

        public IEnumerable<PostedJob> JobsForCandidate()
        {
            try
            {
                var jobsForCandidate = ApplicationDbContext.PostedJobs
                .Where(j => j.ValidTill > DateTime.Now && j.IsCanceled == false).ToList();
                return jobsForCandidate;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public PostedJob GetJobForEdit(string userId, Guid id)
        {
            return ApplicationDbContext.PostedJobs.SingleOrDefault(j => j.Id == id && j.UserId == userId);
        }

        public PostedJob GetJobForAppling(Guid id)
        {
            var job = ApplicationDbContext.PostedJobs.Include(d => d.User).SingleOrDefault(j => j.Id == id);
            return job;
        }

        public bool GetAppliedDetails(string userId, Guid jobId)
        {
            return ApplicationDbContext.JobApplieds
                .Any(a => a.JobApplierId == userId && a.PostedJobId == jobId);
        }

        public int ApplyForJob(string userId, Guid jobId)
        {
            try
            {
                var jobApplied = new JobApplied
                {
                    PostedJobId = jobId,
                    JobApplierId = userId
                };
                ApplicationDbContext.JobApplieds.Add(jobApplied);
                ApplicationDbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }

        public IEnumerable<PostedJob> SearchJobsUsingCondition(PostedJob postedJob)
        {
            try
            {
                var _postedJob = ApplicationDbContext.PostedJobs
    .Where(j => j.JobTitle.Contains(postedJob.JobTitle)  ||
    j.Skill.Contains(postedJob.Skill) ||
    j.Designation.Contains( postedJob.Designation) ||
    j.City.Contains(postedJob.City)).ToList();
                return _postedJob;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IEnumerable<JobApplied> GetAppliersList( Guid jobId)
        {
            try
            {
                var appliedUsers = ApplicationDbContext.JobApplieds
                    .Include(u=>u.JobApplier).Where(j => j.PostedJobId == jobId);
                return appliedUsers;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public  JobApplied GetApplierDetails(string userId, Guid jobId)
        {
            try
            {
                var userDetails = ApplicationDbContext.JobApplieds
                    .Include(u => u.JobApplier)
                    .SingleOrDefault(u => u.PostedJobId == jobId && u.JobApplierId ==userId);
                return userDetails;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }

}