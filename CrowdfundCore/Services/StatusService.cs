using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;
using CrowdfundCore.Services;
using Microsoft.EntityFrameworkCore;
namespace CrowdfundCore.Services
{
    public class StatusService : IStatusService
    {
        private readonly Data.CrowdfundDbContext context; public StatusService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        //public async Task<ApiResult<Status>> AddStatus(AddStatusOptions options, int projectId)
        //{
        //    if (options == null)
        //    {
        //        return new ApiResult<Status>(
        //            StatusCode.BadRequest, "Null options");
        //    }
        //    var project = await context.Set<Project>().SingleOrDefaultAsync(s => s.Id == projectId);
        //    if (project == null)
        //    {
        //        return new ApiResult<Status>(
        //            StatusCode.NotFound, "Not Found project with this Id");
        //    }
        //}
    }
}