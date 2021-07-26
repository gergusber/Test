using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using TravelPoint.Client.Controllers;
using TravelPort.Domain.Models;
using TravelPort.Domain.Repository;
using TravelPort.Domain.Service;
using TravelPort.Infrastructure.Db;
using TravelPort.Infrastructure.Repositories;
using TravelPort.Infrastructure.Services;
using Xunit;

namespace ClientTests
{
    //private TestDbContext TestDbContext { get; set; }

    public class PeopleControllerTests
    {
        private TestDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
            var context = new TestDbContext(options);

            if (context.People.Any())
            {
                return context;   // Data was already seeded
            }

            context.People.AddRange(
                new People
                {
                    Id = 1,
                    Name = "German",
                    Surname = "Bertea",
                    DNI = "123456",
                    Phone = "+34657407036"
                },
                new People
                   {
                       Id = 2,
                       Name = "Person",
                       Surname = "Person",
                       DNI = "12313",
                       Phone = "+34657407036"
                   });

            context.SaveChanges();
            return context;
     
        }
        [Fact]
        public void Index_ReturnListOfPeople()
        {   
            using (var context = GetContextWithData())
            {
                var repo = new PeopleRepository(context);
                var serv = new PeopleService(repo as IPeopleRepository);
                var controller = new PeopleController(serv);

                var result = controller.Index() as ViewResult;

                Assert.NotNull(result);
                //Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
                //Assert.Equal("Index", result.ViewName);
            }

        }

        [Fact]
        public void Details_ReturnOnePerson()
        {
            using (var context = GetContextWithData())
            {
                var repo = new PeopleRepository(context);
                var serv = new PeopleService(repo as IPeopleRepository);
                var controller = new PeopleController(serv);

                var result = controller.Details(1) as ViewResult;

                Assert.NotNull(result);
                //Assert.NotNull(result);
            }

        }

        [Fact]
        public void Details_FailDueInexistentId_ReturnERROR()
        {
            using (var context = GetContextWithData())
            {
                var repo = new PeopleRepository(context);
                var serv = new PeopleService(repo as IPeopleRepository);
                var controller = new PeopleController(serv);

                var result = controller.Details(null) as ViewResult;

               Assert.Null(result);
            }

        }


        [Fact]
        public void Create_FailDueInexistentId_ReturnIndex()
        {
            using (var context = GetContextWithData())
            {
                var repo = new PeopleRepository(context);
                var serv = new PeopleService(repo as IPeopleRepository);
                var controller = new PeopleController(serv);
                var obj = new People()
                {
                    Name="German",
                    Phone="02020",
                    Surname="Ber",
                    DNI = "someDni"
                };
                var result =controller.Create(obj) as ViewResult;
                Assert.Null(result); // IF THE result is null we redirect to Index(Correct)
            }
        }


        [Fact]
        public void Create_FailDueInexistentId_ReturnCreatePageAgainWithErr()//Not WORKING
        {
            using (var context = GetContextWithData())
            {
                var repo = new PeopleRepository(context);
                var serv = new PeopleService(repo as IPeopleRepository);
                var controller = new PeopleController(serv);
                var obj = new People()
                {
                    Name = null,
                    Phone = "",
                    Surname = null,
                    DNI = null
                };
                var result = controller.Create(obj) as ViewResult;
                Assert.Null(result); //SHOULD Return error since THe model isnt valid
            }

        }
    }
}
