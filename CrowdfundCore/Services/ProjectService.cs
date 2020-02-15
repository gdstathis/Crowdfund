using System;
using System.Collections.Generic;
using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class ProjectService
    {
        public List<Project> ProjectLists = new List<Project>();
        private readonly CrowdfundCore.Data.CrowdfundDbContext context;
        public ProjectService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public Project CreateProject(AddProjectOptions options)
        {
            if (options == null) {
                return null;
            }
            if (string.IsNullOrWhiteSpace(options.Title)) {
                return null;
            }
            //if (options.Creator == null) {
            //    return null;
            //}
            var newProject = new Project()
            {
                budget = options.Budget,
               // Deadline = options.Deadline,
                Description = options.Description,
                Title = options.Title,
                
                
            };
            context.Add(newProject);
            try {
                context.SaveChanges();
                Console.WriteLine("ok");
            } catch (Exception ex) {
                Console.WriteLine("no project");
                Console.WriteLine(ex);
                return null;
            }
            return newProject;
        }
        public Project getProjectById(int id)
        {
            if (id == null) {
                return null;
            }
            var project = ProjectLists.Where(p => p.Id == id).SingleOrDefault();
            return project;
        }
        public bool UpdateProject(int id, UpdateProjectOptions options)
        {
            if (id<0) {
                return false;
            }
            if (options == null) {
                return false;
            }
            var upproject = getProjectById(id);
            if (upproject == null) {
                return false;
            }
            if (upproject.ProjectCategory != null) {
                upproject.Description = options.Description;
            }
            if (upproject.Title != null) {
                upproject.Title = options.Title;
            }
            return true;
        }
    }
}
