using System;
using System.Collections.Generic;
using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class ProjectService
    {
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

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return null;
            }

            if (options.Budget<=0) {
                return null;
            }

            //if (options.Creator == null) {
            //    return null;
            //}
            var newProject = new Project()
            {
                budget = options.Budget,
                Description = options.Description,
                Title = options.Title,    
            };

            context.Add(newProject);

            try {
                context.SaveChanges();
                Console.WriteLine("ok project");
            } catch (Exception ex) {
                Console.WriteLine("fail add project");
                Console.WriteLine(ex);
                return null;
            }

            return newProject;
        }

        public Project getProjectById(int id)
        {
            if (id <=0) {
                return null;
            }
            var project = context.Set<Project>().Find(id);
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

            var updproject = getProjectById(id);
            if (updproject == null) {
                return false;
            }

            if (updproject.Description != null) {
                updproject.Description = options.Description;
            }

            if (updproject.Title != null) {
                updproject.Title = options.Title;
            }

            context.Update(updproject);
            
            return true;
        }

        public IQueryable<Project> SearchProjects(
            SearchProjectOptions options)
        {
            if (options == null) {
                return null;
            }
            var query = context.Set<Project>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(options.Title)) {
                query = query.Where(t => t.Title == options.Title);
            }
            if (!string.IsNullOrWhiteSpace(options.Description)) {
                query = query.Where(d => d.Description == options.Description);
            }
            if (options.Id > 0) {
                query = query.Where(i => i.Id == options.Id);
            }
            return query.Take(10);
        }
    }
}
