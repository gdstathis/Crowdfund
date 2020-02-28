using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundCore.Services
{
    public class RewardsService : IRewardsService
    {
        private readonly Data.CrowdfundDbContext context;

        public RewardsService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
          
        }

        public async Task<ApiResult<Rewards>> CreateRewardsAsync(AddRewardsOptions options)
        {
            if (options == null) {
                return new ApiResult<Rewards>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Rewards>(
                    StatusCode.BadRequest, "Null Description");
            }

            if (options.Amount < 0.0M) {
                return new ApiResult<Rewards>(
                    StatusCode.BadRequest, "Invalid reward amount");
            }

            //if (options.projectId < 0) {
            //    return new ApiResult<Rewards>(
            //        StatusCode.BadRequest, "Invalid projectId");
            //}

            options.project = await context.Set<Project>().SingleOrDefaultAsync(i => i.Id == 1);
            var reward = new Rewards()
            {
                Amount = options.Amount,
                Description = options.Description,
                Project=options.project
                
            };
            
            await context.AddAsync(reward);

            try {
                await context.SaveChangesAsync();
                Console.WriteLine("ok reward");
            } catch (Exception ex) {
                Console.WriteLine("fail add reward");
                Console.WriteLine(ex);
                return new ApiResult<Rewards>(
                    StatusCode.InternalServerError, "Could not save reward");
            }

            return ApiResult<Rewards>.CreateSuccess(reward);
        }

        public Rewards SearchRewardById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return  context
                .Set<Rewards>()
                .SingleOrDefault(s => s.Project.Id == id);
        }
    }
}





