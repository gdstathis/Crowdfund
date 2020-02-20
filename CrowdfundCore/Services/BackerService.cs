using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundCore.Services
{
    public class BackerService : IBackerService
    {
        private readonly CrowdfundCore.Data.CrowdfundDbContext context;

        public BackerService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<ApiResult<Backer>> AddBacker(AddBackerOptions options)
        {
            if (options == null) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Null options");
            }

            if (options.Donate < 0.0M) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Invalid Donate");
            }

            //Email and phone must me submited for new Backer
            if (string.IsNullOrEmpty(options.Email) || string.IsNullOrEmpty(options.Phone)) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Email and Vatnumber must not be null");
            }
            var exists = SearchBakers(new SearchBackerOptionsOptions()
            {
                Email = options.Email
            }).Any();
            if (exists) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Already exist Backer with this options");
            }
            var Backer = new Backer()
            {
                Donate = options.Donate,            
                Email=options.Email,
                Phone=options.Phone,
                //Firstname=options.Firstname,
                //Lastname=options.Lastname
                
            };

            if (!string.IsNullOrEmpty(options.Firstname)) { Backer.Firstname = options.Firstname; }
            
            if (!string.IsNullOrEmpty(options.Lastname)) { Backer.Lastname = options.Lastname; }
            
            await context.AddAsync(Backer);
            try {
                await context.SaveChangesAsync();
                Console.WriteLine("ok new");
            } catch (Exception ex) {
                //Console.WriteLine("no new");
                return new ApiResult<Backer>(
                    StatusCode.InternalServerError, "Could not save Backer") ;
            }            
            return ApiResult<Backer>.CreateSuccess(Backer); 
        }
        public async Task<bool> UpdateBackerOptions(int id, UpdateBackerOptions options)
        {
            if (id <=0) {
                return false;
            }
            if (options == null) {
                return false;
            }
            var Backer = await  context.Set<Backer>().SingleOrDefaultAsync(p=>p.Id==id);
           
            if (Backer == null) {
                Console.WriteLine("Does not exist baker with this id");
                return false;
            }

            if (options.Firstname != null) {
                Backer.Firstname = options.Firstname;
            }

            if (options.Lastname != null) {
                Backer.Lastname = options.Lastname;
            }

            if (options.Phone != null) {
                Backer.Phone = options.Phone;
            }

            if (options.Email != null) {
                Backer.Email = options.Email;
            }

            if (options.NewDonate < 0) {
                Backer.Donate = options.NewDonate;
            }

            context.Update(Backer);
            try {
               await context.SaveChangesAsync();
                Console.WriteLine("Update ok");
            } catch (Exception ex) {
                Console.WriteLine("UPDATE FAIL"+ex);
                return false;
            }
            
            return true;
        }

        public async Task<ApiResult<Backer>> GetBackerById(int id)
        {
            if (id <= 0) {
                return new ApiResult<Backer>(
                        StatusCode.BadRequest, "Null id");
            }
            var backer = await context.Set<Backer>().SingleOrDefaultAsync(s => s.Id == id);
            if (backer == null) {
                return new ApiResult<Backer>(
                        StatusCode.NotFound, "Backer not found"); ;
            }
            var api = new ApiResult<Backer>();
            api.Data = backer;
            api.ErrorCode = StatusCode.Ok;
            return api;
        }

        public IQueryable<Backer> SearchBakers(
            SearchBackerOptionsOptions options)
        {
            if (options == null) {
                return null;
            }
            var query = context.Set<Backer>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(options.Email)) { 
                query = query.Where(e => e.Email == options.Email);
            }
            if (!string.IsNullOrWhiteSpace(options.Phone)) {
                query = query.Where(p => p.Phone == options.Phone);
            }
            if (options.Id>0) {
                query = query.Where(i => i.Id == options.Id);
            }
            return query.Take(10);
        }
    }
}
