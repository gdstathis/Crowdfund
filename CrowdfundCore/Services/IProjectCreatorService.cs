using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectCreatorService
    {
        Task<ApiResult<ProjectCreator>> AddProjectCreator(AddProjectCreatorOptions options);

        Task<bool> UpdateProjectCreator(int id, UpdateProjectCreatorOptions options);

        IQueryable<ProjectCreator> SearchProjectCreators(
            SearchProjectCreatorOptions options);
    }
}
