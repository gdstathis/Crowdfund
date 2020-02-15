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
            if (options.Email == null) {
                return null;
            }

            var Backer = new Backer()
            {
                Donate = options.Donate,
               
                Email=options.Email,
                //Lastname=options.Lastname,
                Phone=options.Phone

            };
            if (!string.IsNullOrEmpty(options.Firstname)) { Backer.Firstname = options.Firstname; }
            
            if (!string.IsNullOrEmpty(options.Lastname)) { Backer.Lastname = options.Lastname; }
            
            context.Add(Backer);
            try {
                context.SaveChanges();
                Console.WriteLine("ok new");
            } catch (Exception ex) {
                Console.WriteLine("no new");
                return null;
            }
            //BackerList.Where(p => p.Id == Backer.Id).FirstOrDefault();
            
            return Backer;
        }
        public bool UpdateBackerOptions(int id, UpdateBackerOptions options)
        {
            //if (id == null) {
            //    return false;
            //}
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
                Console.WriteLine("update ok");
            } catch (Exception ex) {
                Console.WriteLine("uPDATE FAIL"+ex);
                return false;
            }
            //var UpdateBacker = GetBackerById(id);
            //UpdateBacker.Donate = options.NewDonate;//edw prepei na to allazw kateuthian sthn vasi
            return true;
        }
        public Backer GetBackerById(int id)
        {
            if (id == null) {
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
                query = query.Where(b => b.Email == options.Email);
            }
          
            return query.Take(1);
        }
    }
}
