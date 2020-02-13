using System.Collections.Generic;

namespace CrowdfundCore.Model
{
    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int id_user { get; set; }

       // public ICollection<ProjectCreator> ProjectCreator { get; set; }
        // public ICollection<Backer> Backer { get; set; }

        public User()
        {
            //  Backer = new List<Backer>();
           // ProjectCreator = new List<ProjectCreator>();
        }
    }
}
