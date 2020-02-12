using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Services.Options
{
    public class AddBackerOptions
    {
        public decimal Donate { get; set; }
        public User user { get; set; }

        public string id_backer { get; set; }
    }
}
