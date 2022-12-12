using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Contact.Core.Repositories;
using PhoneApplications.Services.Contact.Core.Services;
using PhoneApplications.Services.Contact.Data;
using PhoneApplications.Services.Contact.Data.Repositories;
using PhoneApplications.Services.Contact.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<PersonContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PersonDb"), b => b.MigrationsAssembly("PhoneApplications.Services.Contact.API")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
