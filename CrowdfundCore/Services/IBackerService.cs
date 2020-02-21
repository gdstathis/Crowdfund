using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IBackerService
    {
        Task<ApiResult<Backer>> AddBacker(AddBackerOptions options);

        Task<bool> UpdateBackerOptions(int id, UpdateBackerOptions options);

        IQueryable<Backer> SearchBackers(SearchBackerOptionsOptions options);
    }
}

