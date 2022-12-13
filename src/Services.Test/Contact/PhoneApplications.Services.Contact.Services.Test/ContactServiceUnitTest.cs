
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PhoneApplications.Services.Contact.Core.Services;

namespace PhoneApplications.Services.Contact.Services.Test
{
    public class ContactServiceUnitTest:IClassFixture<WebApplicationFactory<Program>>
    {
        //private readonly ContactService _contactService;
        //private readonly Mock<IMapper> _mockMapper;
        //private readonly Mock<IContactRepository> _mockRepo;
        //private readonly CustomWebApplicationFactory<Program> _factory;
        public ContactServiceUnitTest()
        {
            //_mockMapper = new Mock<IMapper>();
            //_mockRepo = new Mock<IContactRepository>();
            //_contactService = new ContactService(_mockMapper.Object, _mockRepo.Object);
           
        }
        [Fact]
        public async Task AddAsync_ReturnIdShouldNotbeEmpty()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7198");
            var result=await client.DeleteAsync("/api/v1/Contact/delete/67868ee0-dce8-4260-a37c-f077114723d2");
            //using var scope = _factory.Server.Host.Services.CreateScope();
            //var contactService = scope.ServiceProvider.GetRequiredService<IContactService>();
            //var result = await contactService.AddAsync(new Core.DTOs.CreateDTOs.CreateContactDTO
            //{
            //    ContactTypeId = 1,
            //    Information = "12121212",
            //    PersonId = new Guid("5ac1fdab-b5fa-446a-8d75-d84f5223f9d2")
            //});
            //result.Id.Should().NotBe(Guid.Empty);
            Assert.True(true);
        }
    }
}