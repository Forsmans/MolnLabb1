
using CV.Data;
using CV.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CV.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();



            //****************ABOUT*********************
            //Create
            app.MapPost("/about", async (ApplicationDbContext context, About newAbout) =>
            {
                context.About.Add(newAbout);
                await context.SaveChangesAsync();
                return Results.Ok(newAbout);
            });

            //Read
            app.MapGet("/abouts", async (ApplicationDbContext context) =>
            {
                return Results.Ok(await context.About.ToListAsync());
            });

            //Read by Id
            app.MapGet("/about", async (ApplicationDbContext context, int id) =>
            {
                var about = context.About.ToList().Find(x => x.Id == id);
                if(about == null)
                    return Results.NotFound($"Id:{id} could not be found");
                return Results.Ok(about);
            });

            //Update
            app.MapPut("/about/{id}", async (ApplicationDbContext context, int id, About updatedAbout) =>
            {
                var toUpdate = context.About.ToList().Find(x => x.Id == id);
                if (toUpdate == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                toUpdate.Name = updatedAbout.Name;
                toUpdate.LastName = updatedAbout.LastName;
                toUpdate.Age = updatedAbout.Age;
                toUpdate.Email = updatedAbout.Email;
                toUpdate.Phone = updatedAbout.Phone;
                toUpdate.ImagePath = updatedAbout.ImagePath;
                context.About.Update(toUpdate);
                await context.SaveChangesAsync();
                return Results.Ok(toUpdate);
            });

            //Delete
            app.MapDelete("/about", async (ApplicationDbContext context, int id) =>
            {
                var toDelete = context.About.ToList().Find(x => x.Id ==id);
                if(toDelete == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                context.About.Remove(toDelete);
                await context.SaveChangesAsync();
                return Results.Ok($"Id:{toDelete.Id} has been successfully removed");
            });





            //****************EDUCATIONS*********************
            //Create
            app.MapPost("/education", async (ApplicationDbContext context, Education newEducation) =>
            {
                context.Educations.Add(newEducation);
                await context.SaveChangesAsync();
                return Results.Ok(newEducation);
            });

            //Read
            app.MapGet("/educations", async (ApplicationDbContext context) =>
            {
                return Results.Ok(await context.Educations.ToListAsync());
            });

            //Read by Id
            app.MapGet("/education", async (ApplicationDbContext context, int id) =>
            {
                var education = context.Educations.ToList().Find(x => x.Id == id);
                if (education == null)
                    return Results.NotFound($"Id:{id} could not be found");
                return Results.Ok(education);
            });

            //Update
            app.MapPut("/education/{id}", async(ApplicationDbContext context, int id, Education updatedEducation) =>
            {
                var toUpdate = context.Educations.ToList().Find(x => x.Id ==id);
                if (toUpdate == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                toUpdate.SchoolName = updatedEducation.SchoolName;
                toUpdate.StartYear = updatedEducation.StartYear;
                toUpdate.EndYear = updatedEducation.EndYear;
                toUpdate.Title = updatedEducation.Title;
                toUpdate.Description = updatedEducation.Description;
                toUpdate.ImagePath = updatedEducation.ImagePath;
                context.Educations.Update(toUpdate);
                await context.SaveChangesAsync();
                return Results.Ok(toUpdate);
            });

            //Delete
            app.MapDelete("/education", async (ApplicationDbContext context, int id) =>
            {
                var toDelete = context.Educations.ToList().Find(x => x.Id == id);
                if (toDelete == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                context.Educations.Remove(toDelete);
                await context.SaveChangesAsync();
                return Results.Ok($"Id:{toDelete.Id} has been successfully removed");
            });





            //****************JOBS*********************
            //Create
            app.MapPost("/job", async (ApplicationDbContext context, Job newJob) =>
            {
                context.Jobs.Add(newJob);
                await context.SaveChangesAsync();
                return Results.Ok(newJob);
            });

            //Read
            app.MapGet("/jobs", async (ApplicationDbContext context) =>
            {
                return Results.Ok(await context.Jobs.ToListAsync());
            });

            //Read by Id
            app.MapGet("/job", async (ApplicationDbContext context, int id) =>
            {
                var job = context.Jobs.ToList().Find(x => x.Id == id);
                if (job == null)
                    return Results.NotFound($"Id:{id} could not be found");
                return Results.Ok(job);
            });

            //Update
            app.MapPut("/job/{id}", async (ApplicationDbContext context,int id, Job updatedJob) =>
            {
                var toUpdate = context.Jobs.ToList().Find(x => x.Id==id);
                if (toUpdate == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                toUpdate.Title = updatedJob.Title;
                toUpdate.Description = updatedJob.Description;
                toUpdate.ImagePath = updatedJob.ImagePath;
                toUpdate.StartYear = updatedJob.StartYear;
                toUpdate.EndYear = updatedJob.EndYear;
                toUpdate.CompanyName = updatedJob.CompanyName;
                context.Jobs.Update(toUpdate);
                await context.SaveChangesAsync();
                return Results.Ok(toUpdate);
            });

            //Delete
            app.MapDelete("/job", async (ApplicationDbContext context, int id) =>
            {
                var toDelete = context.Jobs.ToList().Find(x => x.Id == id);
                if (toDelete == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                context.Jobs.Remove(toDelete);
                await context.SaveChangesAsync();
                return Results.Ok($"Id:{toDelete.Id} has been successfully removed");
            });






            //****************PROJECTS*********************
            //Create
            app.MapPost("/project", async (ApplicationDbContext context, Project newProject) =>
            {
                context.Projects.Add(newProject);
                await context.SaveChangesAsync();
                return Results.Ok(newProject);
            });

            //Read
            app.MapGet("/projects", async (ApplicationDbContext context) =>
            {
                return Results.Ok(await context.Projects.ToListAsync());
            });

            //Read by Id
            app.MapGet("/project", async (ApplicationDbContext context, int id) =>
            {
                var project = context.Projects.ToList().Find(x => x.Id == id);
                if (project == null)
                    return Results.NotFound($"Id:{id} could not be found");
                return Results.Ok(project);
            });

            //Update
            app.MapPut("/project/{id}", async (ApplicationDbContext context,int id, Project updatedProject) =>
            {
                var toUpdate = context.Projects.ToList().Find(x => x.Id==id);
                if (toUpdate == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                toUpdate.Year = updatedProject.Year;
                toUpdate.Name = updatedProject.Name;
                toUpdate.Description = updatedProject.Description;
                toUpdate.ImagePath = updatedProject.ImagePath;
                context.Projects.Update(toUpdate);
                await context.SaveChangesAsync();
                return Results.Ok(toUpdate);
            });

            //Delete
            app.MapDelete("/project", async (ApplicationDbContext context, int id) =>
            {
                var toDelete = context.Projects.ToList().Find(x => x.Id == id);
                if (toDelete == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                context.Projects.Remove(toDelete);
                await context.SaveChangesAsync();
                return Results.Ok($"Id:{toDelete.Id} has been successfully removed");
            });





            //****************SKILLS*********************
            //Create
            app.MapPost("/skill", async (ApplicationDbContext context, Skill newSkill) =>
            {
                context.Skills.Add(newSkill);
                await context.SaveChangesAsync();
                return Results.Ok(newSkill);
            });

            //Read
            app.MapGet("/skills", async (ApplicationDbContext context) =>
            {
                return Results.Ok(await context.Skills.ToListAsync());
            });

            //Read by Id
            app.MapGet("/skill", async (ApplicationDbContext context, int id) =>
            {
                var skill = context.Skills.ToList().Find(x => x.Id == id);
                if (skill == null)
                    return Results.NotFound($"Id:{id} could not be found");
                return Results.Ok(skill);
            });

            //Update
            app.MapPut("/skill/{id}", async (ApplicationDbContext context, int id, Skill updatedSkill) =>
            {
                var toUpdate = context.Skills.ToList().Find(x => x.Id == id);
                if (toUpdate == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                toUpdate.Progress = updatedSkill.Progress;
                toUpdate.Name = updatedSkill.Name;
                context.Skills.Update(toUpdate);
                await context.SaveChangesAsync();
                return Results.Ok(toUpdate);
            });

            //Delete
            app.MapDelete("/skill", async (ApplicationDbContext context, int id) =>
            {
                var toDelete = context.Skills.ToList().Find(x => x.Id == id);
                if (toDelete == null)
                    return Results.NotFound($"Id:{id} could not be found.");
                context.Skills.Remove(toDelete);
                await context.SaveChangesAsync();
                return Results.Ok($"Id:{toDelete.Id} has been successfully removed");
            });


            app.Run();
        }
    }
}
