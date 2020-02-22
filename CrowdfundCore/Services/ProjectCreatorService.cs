using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundCore.Services
{
    public class ProjectCreatorService :IProjectCreatorService
    {
        private readonly CrowdfundCore.Data.CrowdfundDbContext context;

        public ProjectCreatorService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<ApiResult<ProjectCreator>> AddProjectCreatorAsync(AddProjectCreatorOptions options)
        {
            if (options == null) {
                return new ApiResult<ProjectCreator>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrEmpty(options.Email) || string.IsNullOrEmpty(options.Phone)) {
                return new ApiResult<ProjectCreator>(
                    StatusCode.BadRequest, "Null email or phone");
            }
            
            var exists = SearchProjectCreatorsAsync(
                new SearchProjectCreatorOptions() {
                    Email = options.Email
                }).Any();

            if (exists) {
                return new ApiResult<ProjectCreator>(
                    StatusCode.BadRequest, "Already exist project creator with options");
            }

            var ProjectCreator = new ProjectCreator()
            {
                Email= options.Email,
                //TotalCost = options.TotalCost,
                Firstname= options.Firstname,
                Lastname=options.Lastname,
                Phone= options.Phone
            };

            await context.AddAsync(ProjectCreator);

            try {
                await context.SaveChangesAsync();
                Console.WriteLine("ok new creator");
            } catch (Exception ex) {
                Console.WriteLine("no new");
                return new ApiResult<ProjectCreator>(
                    StatusCode.InternalServerError, "Could not save Project creator in database");
            }

            return ApiResult<ProjectCreator>.CreateSuccess(ProjectCreator);

        }
        public async Task<bool> UpdateProjectCreatorAsync(int id, UpdateProjectCreatorOptions options)
        {
            if (id < 0) {
                return false;
            }
            if (options == null) {
                return false;
            }
            if (options.TotalCost <= 0.0M) {
                return false;
            }

            var UpdProjectCreator = context.Set<ProjectCreator>().SingleOrDefault(p => p.Id == id);
            
            if (UpdProjectCreator == null) {
                return false;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.Firstname)) {
                UpdProjectCreator.Firstname = options.Firstname;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.Lastname)) {
                UpdProjectCreator.Lastname = options.Lastname;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.Email)) {
                UpdProjectCreator.Email = options.Email;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.Phone)) {
                UpdProjectCreator.Phone = options.Phone;
            }

            if (UpdProjectCreator.TotalCost > 0)
            {
                UpdProjectCreator.TotalCost = options.TotalCost;
            }

            context.Update(UpdProjectCreator);
            try {
                await context.SaveChangesAsync();
                Console.WriteLine("Update creator ok");
            } catch (Exception ex) {
                Console.WriteLine("UPDATE CREATOR FAIL" + ex);
                return false;
            }
            return true;

        }

        public IQueryable<ProjectCreator> SearchProjectCreatorsAsync(
            SearchProjectCreatorOptions options)
        {
            if (options == null) {
                return null;
            }
            var query = context.Set<ProjectCreator>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(options.Email)) {
                query = query.Where(e => e.Email == options.Email);
            }

            if (!string.IsNullOrWhiteSpace(options.Phone)) {
                query = query.Where(p => p.Phone == options.Phone);
            }

            if (options.Id > 0) {
                query = query.Where(i => i.Id == options.Id);
            }

            return query.Take(10);
        }

        public async Task<ApiResult<ProjectCreator>> GetProjectCreatorByIdAsync(int id)
        {
            if (id <= 0) {
                return new ApiResult<ProjectCreator>(
                        StatusCode.BadRequest, "Null id");
            }
            var Creator = await context.Set<ProjectCreator>().SingleOrDefaultAsync(s => s.Id == id);
            if (Creator == null) {
                return new ApiResult<ProjectCreator>(
                        StatusCode.NotFound, "Backer not found"); ;
            }
            var api = new ApiResult<ProjectCreator>();
            api.Data = Creator;
            api.ErrorCode = StatusCode.Ok;
            return api;
        }


    }
}
