using AutoMapper;
using BusinessManagement.API.DTOs.Mapping;
using BusinessManagement.API.Services;
using BusinessManagement.API.Settings;
using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.UserIdentify;
using BusinessManagement.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //để đọc cái file dbcontext
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "BusinessManagement", Version = "v1" })); //cho swagger
builder.Services.AddControllers(); //add tk này là zo nè chưa hiểu controller thì có liên qua j tới cái add-migration lắm tại cũng chưa có cái controller nào
builder.Services.AddCors();

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDetailedReceiptRepository, DetailedReceiptRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplyProductRepository, SupplyProductRepository>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped(provider =>
{
    var config = provider.GetRequiredService<IOptionsMonitor<EmailConfig>>().CurrentValue;
    SmtpClient client = new(config.Host, config.Port)
    {
        EnableSsl = config.EnableSsl,
        UseDefaultCredentials = config.UseDefaultCredentials,
        Credentials = new NetworkCredential(config.UserName, config.Password)
    };

    return client;
});

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<UserManager>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:5168")
              .AllowCredentials();
    });
});






//builder.Services.Configure<JwtTokenConfig>(Configuration.GetSection("JwtTokenConfig"));
//builder.Services.Configure<EmailConfig>(Configuration.GetSection("EmailConfig"));

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}
app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessManagement.API v1"));

app.UseHttpsRedirection();

app.UseCors("ClientPermission");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
