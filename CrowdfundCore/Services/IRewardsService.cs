using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IRewardsService
    {
        Task<ApiResult<Rewards>> CreateRewardsAsync(AddRewardsOptions options);
    }
}
