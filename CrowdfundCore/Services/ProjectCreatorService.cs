using System.Collections.Generic;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class ProjectCreatorService
    {

        public List<ProjectCreator> ProjectCreatorList = new List<ProjectCreator>();
        public ProjectCreator AddProjectCreator(AddProjectCreatorOptions newCreator)
        {
            if (newCreator == null) {
                return null;
            }
            if (newCreator.user == null) {
                return null;
            }
            if (newCreator.TotalCost <= 0.0M) {
                return null;
            }

            var ProjectCreator = new ProjectCreator()
            {
                user = newCreator.user,
                TotalCost = newCreator.TotalCost
            };
            return ProjectCreator;

        }
        public bool UpdateProjectCreator(ProjectCreator ProjectCreator, UpdateProjectCreatorOptions updateCreator)
        {
            if (updateCreator == null) {
                return false;
            }
            if (updateCreator.TotalCost <= 0.0M) {
                return false;
            }
            ProjectCreatorList.Find(p => p.user.id_user == ProjectCreator.user.id_user).TotalCost = updateCreator.TotalCost;

            return true;


        }
    }
}
