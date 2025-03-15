using DNTCaptcha.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.BussinessLogic.Services;
using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDNTCaptcha( option => 
                                option.UseCookieStorageProvider()
                                .ShowThousandsSeparators(false).WithEncryptionKey("123456")
                                );
// Get the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add the DbContext to the service collection
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));
//Configuration Identity Services
builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<ISessionManagement, SessionManagement>();
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<ISemester, SemesterRepository>();
builder.Services.AddScoped<IRegisterCourse, RegisterCourseRepository>();
builder.Services.AddScoped<IStudyPlan, StudyPlanRepository>();
builder.Services.AddScoped<IMarks, MarksRepository>();
builder.Services.AddScoped<ISqlTransactionQuery, SqlTransactionQuery>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<ManualSeeding>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

#region Session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(480);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

// Configure the HTTP request pipeline.
var app = builder.Build();
var ManualSeedingOption = builder.Configuration.GetSection("ManualSeeding").Value;

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dataContext.Database.Migrate();
    // Resolve and call ManualSeeding
    if (ManualSeedingOption == "True")
    {
        var manualSeeding = scope.ServiceProvider.GetRequiredService<ManualSeeding>();
        await manualSeeding.ManualSeedingMethod();

    }

}

if (!app.Environment.IsDevelopment())
{ 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
