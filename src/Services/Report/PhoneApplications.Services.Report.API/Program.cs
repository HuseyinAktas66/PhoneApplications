using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Report.Core.Repositories;
using PhoneApplications.Services.Report.Core.Services;
using PhoneApplications.Services.Report.Data;
using PhoneApplications.Services.Report.Data.Repositories;
using PhoneApplications.Services.Report.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CAPDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportDb")));
builder.Services.AddCap(options =>
{
    options.UseEntityFramework<CAPDbContext>();
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportDb"));
    options.UseRabbitMQ(
        //builder.Configuration.GetValue<string>("RabbitMQHostName")
        options=>
        {
            options.ConnectionFactoryOptions = options =>
            {
                options.HostName = "localhost";
                options.UserName = "guest";
                options.Password = "guest";
                options.Port = 5672;
                options.Ssl.Enabled = false;
            };
            
        }
        );
}) ;
builder.Services.AddDbContext<ReportContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportDb"), b => b.MigrationsAssembly("PhoneApplications.Services.Report.API")));
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
