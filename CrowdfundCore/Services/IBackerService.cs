using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IBackerService
    {
        Task<ApiResult<Backer>> AddBackerAsync(AddBackerOptions options);

        Task<bool> UpdateBackerOptionsAsync(int id, UpdateBackerOptions options);

        IQueryable<Backer> SearchBackersAsync(SearchBackerOptionsOptions options);
    }
}

