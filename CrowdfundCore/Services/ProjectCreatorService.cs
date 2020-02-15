using System;
using System.Collections.Generic;
using System.Linq;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class ProjectCreatorService :IProjectCreatorService
    {
        private readonly CrowdfundCore.Data.CrowdfundDbContext context;

        public ProjectCreatorService(Data.CrowdfundDbContext ctx)
        {
            context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public ProjectCreator AddProjectCreator(AddProjectCreatorOptions options)
        {
            if (options == null) {
                return null;
            }

            if (string.IsNullOrEmpty(options.Email) || string.IsNullOrEmpty(options.Phone)) {
                return null;
            }
            //if (newCreator.user == null) {
            //    return null;
            //}
            //if (newCreator.TotalCost <= 0.0M) {
            //    return null;
            //}

            var ProjectCreator = new ProjectCreator()
            {
                Email= options.Email,
                TotalCost = options.TotalCost,
                Firstname= options.Firstname,
                Lastname=options.Lastname,
                Phone= options.Phone
            };

            context.Add(ProjectCreator);
            try {
                context.SaveChanges();
                Console.WriteLine("ok new creator");
            } catch (Exception ex) {
                Console.WriteLine("no new");
                return null;
            }

            return ProjectCreator;

        }
        public bool UpdateProjectCreator(int id, ProjectCreator ProjectCreator, UpdateProjectCreatorOptions options)
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

            context.Update(UpdProjectCreator);
            try {
                context.SaveChanges();
                Console.WriteLine("Update creator ok");
            } catch (Exception ex) {
                Console.WriteLine("UPDATE CREATOR FAIL" + ex);
                return false;
            }
            return true;

        }

        public IQueryable<ProjectCreator> SearchProjectCreators(
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

        public ProjectCreator GetProjectCreatorById(int id)
        {
            if (id <= 0) {
                return null;
            }
            var Creator = context.Set<ProjectCreator>().Find(id);
            return Creator;
        }


    }
}
