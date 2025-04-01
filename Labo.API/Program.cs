using Labo.Application.Interfaces;
using Labo.Application.Interfaces.Repositories;
using Labo.Application.Interfaces.Services;
using Labo.Application.Services;
using Labo.Infrastructure;
using Labo.Infrastructure.Repositories;
using Labo.Infrastructure.Smtp;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LaboContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("Main"))
);

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

builder.Services.AddScoped(c => new SmtpClient
{
    Host = builder.Configuration["Smtp:Host"] ?? throw new Exception("Missing Smtp Configuration"),
    Port = int.Parse(builder.Configuration["Smtp:Port"] ?? throw new Exception("Missing Smtp Configuration")),
    Credentials = new NetworkCredential
    {
        UserName = builder.Configuration["Smtp:Username"] ?? throw new Exception("Missing Smtp Configuration"),
        Password = builder.Configuration["Smtp:Password"] ?? throw new Exception("Missing Smtp Configuration"),
    }

});
builder.Services.AddScoped<IMailer, Mailer>();

// CORS CROSS ORIGIN RESOURCE SHARING
// partage de ressource inter domaine

builder.Services.AddCors(p => {
    p.AddDefaultPolicy(o =>
        o.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    );
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
