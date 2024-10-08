using Forum.Domain.Entities;
using Forum.Infrastructure.Data;
using Forum.Infrastructure.Repository;
using Forum.Infrastructure.Repository.IRepository;
using Forum.Infrastructure.Services.UserService;
using Forum.Logic.Commands.CreateCommands;
using Forum.Logic.Commands.HandleCommands;
using Forum.Logic.Queries.QueryHandlers;
using Forum.Logic.Queries.Querys;
using Forum.Server.GraphQl;
using Forum.Server.GraphQl.Queries;
using Forum.Server.GraphQl.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services  = builder.Services;

services.AddControllers();
builder.Services.AddGraphQLServer();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Forum"))
);


services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader());
});

//Graphql
services.AddGraphQL();
services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<UserType>();

services.AddScoped<UserQueries>();


//Repositories
services.AddScoped<IRepository<User>, Repository<User>>();

//Services
services.AddScoped<IUserService, UserService>();

//CQRS
services.AddTransient<IRequestHandler<GetAllUsersQuery, IEnumerable<User>>, GetAllUsersQueryHandler>();
services.AddTransient<IRequestHandler<GetUserQuery, User> , GetUserQueryHandler>();
services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseRouting();
app.UseCors();
app.MapGraphQL();

app.Run();
