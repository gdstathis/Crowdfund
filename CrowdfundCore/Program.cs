using System;
using CrowdfundCore.Model;
using CrowdfundCore.Services;

namespace CrowdfundCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var user = new User()
            {
                email="georgesta@gmail.com",
                firstname="Georgios",
                lastname="stathis",
                id_user=1
            };
         

        }
    }
}
