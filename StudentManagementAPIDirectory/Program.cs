using BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                 .WithOrigins("http://localhost:4200")
                 .AllowAnyHeader()
                 .AllowAnyMethod();       
        });
});
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
    builder.Services.AddScoped<ISemesterService, SemesterService>();
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
