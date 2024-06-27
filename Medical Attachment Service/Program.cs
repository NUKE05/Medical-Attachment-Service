using MedicalAttach.Core.Abstractions;
using MedicalAttach.DataAccess;
using MedicalAttach.DataAccess.Repository;
using MedicalAttachment.Application.Services;
using Microsoft.EntityFrameworkCore;
using static MedicalAttach.DataAccess.Repository.AttachmentRequestsRepository;
using static MedicalAttach.DataAccess.Repository.MedicalOrganizationsRepository;
using static MedicalAttach.DataAccess.Repository.UsersRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MedicalAttachDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("MedicalAttachDbContext"),
        b => b.MigrationsAssembly("MedicalAttach.DataAccess"))
);

// options.UseSqlServer(connection, b => b.MigrationsAssembly("Medical Attachment Service"))

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IMedicalOrganizationsService, MedicalOrganizationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAttachmentRequestService, AttachmentRequestService>();

builder.Services.AddScoped<IAttachmentRequestsRepository, AttachmentRequestsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IMedicalOrganizationsRepository, MedicalOrganizationsRepository>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();


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
