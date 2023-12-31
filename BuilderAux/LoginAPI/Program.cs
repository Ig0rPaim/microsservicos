using AutoMapper;
using LoginAPI.Config;
using LoginAPI.Data;
using LoginAPI.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AplicationDbContextUser>(
    builder.Configuration["ConnectionStrings:DatabaseUser"]
    );
// Add services to the container.
//builder.Services.AddDbContext<AplicationDbContextUser>(); // // // // //
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AplicationDbContextUser>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
    

//Mapping configurations
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpClient<IUserServices>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
