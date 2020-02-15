using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectCreatorService
    {
        ProjectCreator AddProjectCreator(AddProjectCreatorOptions options);

        bool UpdateProjectCreator(int id, ProjectCreator ProjectCreator, UpdateProjectCreatorOptions options);

        IQueryable<ProjectCreator> SearchProjectCreators(
            SearchProjectCreatorOptions options);
    }
}
