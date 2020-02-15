using System;
using System.Collections.Generic;
using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class BackerService : IBackerService
    {
        private readonly CrowdfundCore.Data.CrowdfundDbContext context;

        public BackerService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public Backer AddBacker(AddBackerOptions options)
        {
            if (options == null) {
                return null;
            }

            if (options.Donate <= 0.0M) {
                return null;
            }

            //Email and phone must me submited for new Backer
            if (string.IsNullOrEmpty(options.Email) || string.IsNullOrEmpty(options.Phone)) {
                return null;
            }

            var Backer = new Backer()
            {
                Donate = options.Donate,            
                Email=options.Email,
                Phone=options.Phone
            };

            if (!string.IsNullOrEmpty(options.Firstname)) { Backer.Firstname = options.Firstname; }
            
            if (!string.IsNullOrEmpty(options.Lastname)) { Backer.Lastname = options.Lastname; }
            
            context.Add(Backer);
            try {
                context.SaveChanges();
                Console.WriteLine("ok new");
            } catch (Exception ex) {
                //Console.WriteLine("no new");
                return null;
            }            
            return Backer;
        }
        public bool UpdateBackerOptions(int id, UpdateBackerOptions options)
        {
            if (id <=0) {
                return false;
            }
            if (options == null) {
                return false;
            }
            var Backer = context.Set<Backer>().SingleOrDefault(p=>p.Id==id);
           
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

            if (options.NewDonate <= 0) {
                Backer.Donate = options.NewDonate;
            }

            context.Update(Backer);
            try {
                context.SaveChanges();
                Console.WriteLine("Update ok");
            } catch (Exception ex) {
                Console.WriteLine("UPDATE FAIL"+ex);
                return false;
            }
            
            return true;
        }

        public Backer GetBackerById(int id)
        {
            if (id <=0) {
                return null;
            }
            var backer = context.Set<Backer>().Find(id);
            return backer;
        }

        public IQueryable<Backer> SearchBakers(
            SearchBackerOptions options)
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
