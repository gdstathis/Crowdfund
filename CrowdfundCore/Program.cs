using System;
using CrowdfundCore.Data;
using CrowdfundCore.Model;
using CrowdfundCore.Services;

namespace CrowdfundCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new CrowdfundDbContext();
            context.Database.EnsureCreated();
            
            var BackerService = new BackerService(context);
            var ProjectService = new ProjectService(context);

            BackerService.AddBacker(new Services.Options.AddBackerOptions
            {
                Firstname = "Georgios",
                Lastname = "Stathis",
                Donate = 2800,
                Email = "ggstathis234@gmail.com",
                Phone = "698312449213"
            });
            BackerService.UpdateBackerOptions(1,new Services.Options.UpdateBackerOptions
            {
                Firstname = "George",
                Lastname="Stathis",
                NewDonate=800,
                Email= "gdstathis@yahoo.gr",
                Phone="6983078378"
            });
            
            ProjectService.CreateProject(new Services.Options.AddProjectOptions
            {
                Budget = 1500,
                Title = "Proj2ect 1",
                Description = "Des2cription1",


            });
            ProjectService.UpdateProject(1,new Services.Options.UpdateProjectOptions
            {
                Budget = 1500,
                Title = "Project 1",
                Description = "Description1",
            });

            //var BackerService2 = new BackerService(context);
            //BackerService.AddBacker(new Services.Options.AddBackerOptions
            //{
            //    Firstname = "111111111111",
            //    Donate = 5112,
            //    Lastname = "11111111111111",
            //    Email = "fdssd111111111111111111fsdfsd"

            //});
            //using (var context = new CrowdfundDbContext()) {
            //        var backer1 = new IBackerService(context);
            //    customer1.AddCustomer(new TinyCrm.Core.Model.Options.AddCustomerOptions()
            //var user = new User()
            //{
            //    email="georgesta@gmail.com",
            //    firstname="Georgios",
            //    lastname="stathis",
            //    id_user=1
            //};
            //var BakerService = new BackerService();
            //var UserService = new UserService();
            //UserService.AddUser(new Services.Options.AddUserOptions
            //{
            //    email = "ASdas",
            //    firstname = "dfsdfsd",
            //    lastname = "fsdfdsfsdf",
            //    phone = "689654654"
            //});

        }
    }
}
