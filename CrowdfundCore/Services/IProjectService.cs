using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectService
    {
        Task <ApiResult<Project>> CreateProject(AddProjectOptions options);

        Task<bool> UpdateProject(int id, UpdateProjectOptions options);

        IQueryable<Project> SearchProjects(SearchProjectOptionsOptions options);
    }
}
