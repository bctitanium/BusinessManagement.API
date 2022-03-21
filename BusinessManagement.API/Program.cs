using BusinessManagement.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //để đọc cái file dbcontext
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "BuinessManahementApi", Version = "v1" })); //cho swagger
builder.Services.AddControllers(); //add tk này là zo nè chưa hiểu controller thì có liên qua j tới cái add-migration lắm tại cũng chưa có cái controller nào
builder.Services.AddCors();

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

app.Run();
