using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPool.Models;
using JobPool.Models.Repositories;

namespace JobPool.UnitOfWorkModel
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationDbContext Context { get; }

        public IGeneralRepository GeneralRepository { get; set; }

        public UnitOfWork(IApplicationDbContext proxy)
        {
            Context = proxy;
            GeneralRepository = new GeneralRepository(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

    }
}