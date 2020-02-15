using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IBackerService
    {
        Backer AddBacker(AddBackerOptions newBacker);

        bool UpdateBackerOptions(int id, UpdateBackerOptions options);

        IQueryable<Backer> SearchBakers(SearchBackerOptionsOptions options);
    }
}

