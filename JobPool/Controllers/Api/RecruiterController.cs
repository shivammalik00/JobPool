using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPool.UnitOfWorkModel;
using Microsoft.AspNet.Identity;

namespace JobPool.Controllers.Api
{
    public class RecruiterController : ApiController
    {

        private IUnitOfWork _unitOfWork { get; }
        public RecruiterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var userId = User.Identity.GetUserId();
            var i = _unitOfWork.GeneralRepository.CancelTheJob(userId, id);

            if (i == 0)
                return NotFound();
            else
                return Ok();
        }

    }
}
