using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectService
    {
        Task <ApiResult<Project>> CreateProjectAsync(AddProjectOptions options);

        Task<bool> UpdateProjectAsync(int id, UpdateProjectOptions options);

        IQueryable<Project> SearchProjectsAsync(SearchProjectOptionsOptions options);
    }
}
