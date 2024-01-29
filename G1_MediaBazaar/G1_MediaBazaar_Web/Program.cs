using System;
using DataLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using SharedLibrary;
using StoreLibrary;
using UserLibrary;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
    options.SerializerSettings.Converters.Add(new DateOnlyNewtonsoftJsonConverter());
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/Login");
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorPages();

IUserDataInterface userDataInterface = new UserDataHandler();
IJobDataInterface jobDataInterface = new JobDataHandler();
IDepartmentsDataInterface departmentDataInterface = new DepartmentDataHandler();
ILocationsDataInterface locationDataInterface = new LocationDataHandler();
IWorkshiftDataInterface workshiftDataInterface = new WorkshiftDataHandler();
IProductDataInterface productDataInterface = new ProductDataHandler();
IAnnouncementDataInterface announcementDataInterface = new AnnouncementDataHandler();
IAvailability availabilityDataInterface = new AvailabilityDataHandler();
MediaBazzar.Initialize(userDataInterface, jobDataInterface, departmentDataInterface, locationDataInterface, workshiftDataInterface, productDataInterface, announcementDataInterface, availabilityDataInterface);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/LogInPage");
    }
    else
    {
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();