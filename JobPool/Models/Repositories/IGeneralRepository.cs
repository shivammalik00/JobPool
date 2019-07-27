using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPool.ViewModels;

namespace JobPool.Models.Repositories
{
    public interface IGeneralRepository
    {
        IEnumerable<State> GetStateList();
        IEnumerable<TypeOfJob> GetTypeOfJobList();

        int SaveJob(PostedJob postJob);

        int UpdateJob(JobFormViewModel viewModel, string userId);

        IEnumerable<PostedJob> GetJobsOfRecruiter(string userId);
        IEnumerable<PostedJob> JobsForCandidate();
        PostedJob GetJobForEdit(string userId, Guid id);

        int CancelTheJob(string userId, Guid id);

        PostedJob GetJobForAppling(Guid id);

        bool GetAppliedDetails(string userId, Guid jobId);

        int ApplyForJob( string userId, Guid jobId);

        IEnumerable<PostedJob> SearchJobsUsingCondition(PostedJob postedJob);

        IEnumerable<JobApplied> GetAppliersList( Guid jobId);

        JobApplied GetApplierDetails(string userId, Guid jobId);









    }
}
