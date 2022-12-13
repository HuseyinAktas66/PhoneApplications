using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApplications.Services.Contact.API.Controllers;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.API.Test
{
    public class PersonControllerUnitTest
    {
        private readonly PersonController _personController;
        private readonly Mock<IPersonService> _mockRepo;
        public PersonControllerUnitTest()
        {
            _mockRepo = new Mock<IPersonService>();
            _personController = new PersonController(_mockRepo.Object);
        }
        [Fact]
        public async Task GetList_ShouldbeOk200Status()
        {
            var response = (OkObjectResult)await _personController.GetList();
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        [Fact]
        public async Task GetList_ResponseTypeShouldbeArrayPersonDTO()
        {
            var response = (OkObjectResult)await _personController.GetList();
            Assert.IsType<PersonDTO[]>(response.Value);
        }
        [Fact]
        public async Task Create_ShouldbeOk200Status()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7198");
            var person = new Core.DTOs.CreateDTOs.CreatePersonDTO
            {
                Name = "merhaba",
                Company = "merhaba",
                SurName = "merhaba"
            };

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/Person/create/", data);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Edit_ShouldbeOk200Status()
        {
            var response = (OkObjectResult)await _personController.Edit(
                new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2"),
                new PersonDTO
                {
                    Id=new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2"), 
                    SurName="akkan",
                    Name="hüseyin", 
                    Company="yıldız"
                }
                );
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
