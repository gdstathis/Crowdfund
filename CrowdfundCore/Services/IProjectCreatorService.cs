using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectCreatorService
    {
        Task<ApiResult<ProjectCreator>> AddProjectCreatorAsync(AddProjectCreatorOptions options);

        Task<bool> UpdateProjectCreatorAsync(int id, UpdateProjectCreatorOptions options);

        IQueryable<ProjectCreator> SearchProjectCreatorsAsync(
            SearchProjectCreatorOptions options);
    }
}
