using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using PhoneApplications.Services.Contact.API.Controllers;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Services;
using System.Net;
using System.Text;

namespace PhoneApplications.Services.Contact.API.Test
{
    public class ContactControllerUnitTest
    {
        private readonly ContactController _contactController;
        private readonly Mock<IContactService> _mockRepo;
        public ContactControllerUnitTest()
        {
            _mockRepo = new Mock<IContactService>();
            _contactController = new ContactController(_mockRepo.Object);
        }
        [Fact]
        public async Task GetAllByPersonId_ShouldbeOk200Status()
        {
            var response= (OkObjectResult) await _contactController.GetAllByPersonId(new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2"));
            response.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAllByPersonId_ResponseTypeShouldContactDTO()
        {
            var response = (OkObjectResult)await _contactController.GetAllByPersonId(new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2"));
            var value = response.Value;
            Assert.IsType<ContactDTO[]>(value);
        }
        [Fact]
        public async Task Create_ShouldbeOk200Status()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7198");
            var contact = new CreateContactDTO
            {
                ContactTypeId=1, 
                Information="535555", 
                PersonId= new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2")
            };

            var json = JsonConvert.SerializeObject(contact);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/Contact/create/",data);            
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Delete_ShouldbeOk200Status()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7198");
            var response = await client.DeleteAsync("/api/v1/Contact/delete/e5c1ddfe-9a7f-4976-bd50-7a9c97b78436");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}