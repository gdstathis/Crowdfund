using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IProjectService
    {
        Project CreateProject(AddProjectOptions options);
        bool UpdateProject(int id, UpdateProjectOptions options);

    }
}
