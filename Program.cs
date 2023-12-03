using Microsoft.Data.SqlClient;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.HostedService;
using PollingScheduler.Interfaces;
using PollingScheduler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommitSatatService, CommitStatService>();
builder.Services.AddScoped<ContributorService>();
builder.Services.AddScoped<ContributorDataBaseService>();
builder.Services.AddScoped<CommitStatDataService>();
builder.Services.AddScoped<IIssueStatService, IssueStatService>();
builder.Services.AddScoped<IssuesDataService>();
builder.Services.AddScoped<IPullRequestStatService, PullRequestStatService>();
builder.Services.AddScoped<PullRequestDataService>();
builder.Services.AddSingleton<GitHubRestPollingWorker>();
builder.Services.AddHostedService<GitHubRestPollingWorker>();
builder.Services.AddScoped<DeveloperIqDataService>();


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
