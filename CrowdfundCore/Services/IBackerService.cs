using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    interface IBackerService
    {
        Backer AddBacker(AddBackerOptions newBacker);

        bool UpdateBackerOptions(int id, UpdateBackerOptions options);
    }
}

