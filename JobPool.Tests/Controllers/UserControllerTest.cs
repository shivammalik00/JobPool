using NUnit.Framework;
using JobPool.UnitOfWorkModel;
using Moq;
using JobPool.Controllers;
using JobPool.Models.Repositories;
using JobPool.Models;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web;
using System.Security.Principal;

namespace JobPool.Tests.Controllers
{
    [TestFixture]
    class UserControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private UserController _userController;
        private Mock<IGeneralRepository> _generalRepository;
        private Mock<IApplicationDbContext> _applicationDbContext;
        Guid guid = Guid.NewGuid();
        [SetUp]
        public void SetUp()
        {

            _unitOfWork = new Mock<IUnitOfWork>();
            _generalRepository = new Mock<IGeneralRepository>();
            _applicationDbContext = new Mock<IApplicationDbContext>();
            _unitOfWork.Setup(s => s.Context).
                Returns(_applicationDbContext.Object);
            _unitOfWork.Setup(s => s.GeneralRepository)
                .Returns(_generalRepository.Object);
            _userController = new UserController(_unitOfWork.Object);
        }

        public void SetUpIdentity()
        {


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.NameIdentifier, guid.ToString()),
                new Claim(ClaimTypes.Name, "Shivam"),

            };
            var request = new Mock<HttpRequestBase>();
            var identity = new ClaimsIdentity(claims, "Test");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            mockPrincipal.Setup(d => d.Identity.IsAuthenticated).Returns(true);
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);
            mockHttpContext.Setup(m => m.Request).Returns(request.Object);
            mockHttpContext.Setup(m => m.Request.IsAuthenticated).Returns(true);
        }
        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void IndexTest()
        {
            var list = new List<PostedJob>
            {
                new PostedJob
                {
                    City="banagalore",
                    JobTitle="tester",
                    ValidTill= DateTime.Now.AddDays(5),
                    IsCanceled = false
                },
                new PostedJob
                {
                    City ="Delhi",
                    JobTitle="developer",
                    ValidTill= DateTime.Now.AddDays(5),
                    IsCanceled = false
                }
            };
            _generalRepository.Setup(s => s.JobsForCandidate()).Returns(list);
            var returnlist = _userController.Index();
            Assert.IsNotNull(returnlist);
            Assert.That(returnlist, Is.InstanceOf<ViewResult>());

        }
        [Test]
        public void ApplyTest()
        {

            var job=  new PostedJob
            {
                City = "banagalore",
                JobTitle = "tester",
                ValidTill = DateTime.Now.AddDays(5),
                IsCanceled = false
            };
            SetUpIdentity();
            _generalRepository.Setup(s => s.GetJobForAppling(guid))
                .Returns(job);

            var result = _userController.Apply(guid);
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
