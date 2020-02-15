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
            Console.WriteLine("Hello World!");
            var backer = new Backer()
            {
                Donate = 1500,
                Email = "fsdfsdF",
                Firstname = "sdadas",
                Phone = "sadasd",
                Lastname = "Sadasd"
            };
            var backer2 = new Backer()
            {
                Donate = 15002,
                Email = "1111111111111",
                Firstname = "11111111111",
                Phone = "1111111111111111",
                Lastname = "11111111111111111111"
            };
            var BackerService = new BackerService(context);

            //BackerService.AddBacker( new Services.Options.AddBackerOptions
            //{
            //    Firstname = "Dimitris",
            //    Lastname = "Sta",
            //    Donate = 2800,
            //    Email = "pnevmatikos@codehub.gr111",
            //    Phone = "69889889891111"
            //});
            BackerService.UpdateBackerOptions(7,new Services.Options.UpdateBackerOptions
            {
                Firstname = "Georg1e",
                Lastname="Stathis",
                NewDonate=800,
                Email= "george@yahoo.gr",
                Phone="69889889891111"
            });
            var ProjectService = new ProjectService(context);
            ProjectService.CreateProject(new Services.Options.AddProjectOptions
            {
                Budget = 1500,
                Title = "1The best project22",
                Description = "Description22",


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
