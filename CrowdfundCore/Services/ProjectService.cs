using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class ProjectService
    {
        public List<Project> ProjectLists=new List<Project>();
        public Project CreateProject(AddProjectOptions options)
        {
            if (options == null) {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(options.title)) {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(options.nameCreator)) {
                return null;
            }
            var newProject = new Project()
            {
                budget = options.budget,
                deadline = options.deadline,
                Description = options.Description,
                title = options.title
            };
            if (ProjectLists.Contains(newProject)) {
                return null;
            }
            ProjectLists.Add(newProject);
            return newProject;
        }
        public Project getProjectById(string id)
        {
            if (id==null) {
                return null;
            }
            var project = ProjectLists.Where(p => p.id_project == id).SingleOrDefault();
            return project;
        }
        public bool UpdateProject(string id,UpdateProjectOptions options)
        {
            if (!string.IsNullOrEmpty(id)) {
                return false;
            }
            if (options == null) {
                return false; 
            }
            var upproject = getProjectById(id);
            if (upproject == null) {
                return false;
            }
            if (upproject.projectCategory != null) {
                upproject.Description = options.Description;
            }
            if (upproject.title != null) {
                upproject.title = options.title;
            }
            return true;
        }
    }
}
