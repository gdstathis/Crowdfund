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
        public async Task<ApiResult<Status>> AddStatusAsync(AddStatusOptions options, int projectId)
        {
            if (options == null) {
                return new ApiResult<Status>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrEmpty(options.comments)) {
                return new ApiResult<Status>(
                    StatusCode.BadRequest, "Null comments");
            }

            if (options.project==null) {
                return new ApiResult<Status>(
                    StatusCode.BadRequest, "Null Project");
            }


            var status = new Status()
            {
                comments=options.comments,
                Project=options.project,
                ProjectId=options.ProjectId

            };

            await context.AddAsync(status);

            try {
                await context.SaveChangesAsync();
                Console.WriteLine("ok status");
            } catch (Exception ex) {
                Console.WriteLine("fail add status");
                Console.WriteLine(ex);
                return new ApiResult<Status>(
                    StatusCode.InternalServerError, "Could not save status");
            }

            return ApiResult<Status>.CreateSuccess(status);
        }
    }
}