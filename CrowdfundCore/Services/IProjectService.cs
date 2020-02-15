using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectService
    {
        Project CreateProject(AddProjectOptions options);

        bool UpdateProject(int id, UpdateProjectOptions options);

        IQueryable<Project> SearchProjects(SearchProjectOptions options);
    }
}
