using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundCore.Services
{
    public class ProjectService :IProjectService
    {
        private readonly Data.CrowdfundDbContext context;
        
        public ProjectService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        
        public async Task<ApiResult<Project>> CreateProjectAsync(AddProjectOptions options)
        {
            if (options == null) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.Title)) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Null title");
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Null description");
            }

            if (options.Budget < 0) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Invalid project budget");
            }
            options.Creator = await context.Set<ProjectCreator>().SingleOrDefaultAsync(p => p.Id == 1);
            //if (options.Creator == null) {
            //    return new ApiResult<Project>(
            //        StatusCode.BadRequest, "Null creator");
            //}

            var newProject = new Project()
            {
                budget = options.Budget,
                Description = options.Description,
                Title = options.Title,
                Creator = options.Creator,
                Photo = options.Photo,
                Video = options.Video,
                rewardPackages = options.Rewards,
              
            };
           
            await context.AddAsync(newProject);

            try {
                await context.SaveChangesAsync();
                Console.WriteLine("ok project");
            } catch (Exception ex) {
                Console.WriteLine("fail add project");
                Console.WriteLine(ex);
                return new ApiResult<Project>(
                    StatusCode.InternalServerError, "Could not save Backer");
            }

            return ApiResult<Project>.CreateSuccess(newProject); 
        }

        public async Task<ApiResult<Project>> getProjectByIdAsync(int id)
        {
            if (id <=0) {
                return new ApiResult<Project>(
                        StatusCode.BadRequest, "Null id");
            }
            var project = await context.Set<Project>().SingleOrDefaultAsync(s => s.Id == id);
            if (project == null) {
                return new ApiResult<Project>(
                        StatusCode.NotFound, "Backer not found"); ;
            }
            var api = new ApiResult<Project>();
            api.Data = project;
            api.ErrorCode = StatusCode.Ok;
            return api;
        }

        public async Task<bool> UpdateProjectAsync(int id, UpdateProjectOptions options)
        {
            if (id < 0) {
                return false;
            }

            if (options == null) {
                return false;
            }

            var updproject = await context.Set<Project>().SingleOrDefaultAsync(p => p.Id == id);

            if (updproject == null) {
                return false;
            }

            if (updproject.Description != null) {
                updproject.Description = options.Description;
            }
            
            if( updproject.budget > 0){
                updproject.budget = options.Budget;
            }

            if (updproject.Title != null) {
                updproject.Title = options.Title;
            }

            if (updproject.Photo != null) {
                updproject.Photo = options.Photo;
            }

            if (updproject.Video != null) {
                updproject.Video = options.Video;
            }

            context.Update(updproject);
            try
            {
                await context.SaveChangesAsync();
                Console.WriteLine("Update ok");
            } catch (Exception ex)
            {
                Console.WriteLine("UPDATE FAIL" + ex);
                return false;
            }
            return true;
        }

        public IQueryable<Project> SearchProjectsAsync(
            SearchProjectOptionsOptions options)
        {
            if (options == null) {
                return null;
            }

            var query = context.Set<Project>().AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(options.Title)) {
                query = query.Where(t => t.Title == options.Title);
            }

            if (!string.IsNullOrWhiteSpace(options.Description)) {
                query = query.Where(d => d.Description == options.Description);
            }

            if (options.Id > 0) {
                query = query.Where(i => i.Id == options.Id);
            }

            return query.Take(10);
        }
    }
}
