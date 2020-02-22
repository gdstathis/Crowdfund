using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IStatusService
    {
        Task<ApiResult<Status>> AddStatus(AddStatusOptions options, int projectId);
    
    }
}
