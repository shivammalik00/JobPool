using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPool.Models;
using JobPool.Models.Repositories;

namespace JobPool.UnitOfWorkModel
{
    public interface IUnitOfWork
    {
        IApplicationDbContext Context { get; }
        IGeneralRepository GeneralRepository { get; set; }

        void SaveChanges();
    }
}
