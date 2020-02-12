using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public class BackerService :IBackerService
    {
        public List<Backer> BackerList = new List<Backer>();
        public Backer AddBacker(AddBackerOptions newBacker)
        {
            if (newBacker == null) {
                return null;
            }
            if (newBacker.Donate <= 0.0M) {
                return null;
            }
            if (newBacker.user == null) {
                return null;
            }

            var Backer = new Backer()
            {
                donate = newBacker.Donate,
                user = newBacker.user,

            };
            BackerList.Where(p => p.id_backer == Backer.id_backer).FirstOrDefault();
            return Backer;
        }
        public bool UpdateBackerOptions(string id,UpdateBackerOptions options)
        {
            if (string.IsNullOrEmpty(id)) {
                return false;
            }
            if (options == null) {
                return false;
            }
            return true;

            if (options.newDonate <= 0) {
                return false;
            }
            var UpdateBacker = SearchBackerById(id);
            UpdateBacker.donate = options.newDonate;
            return true;
        }
        public Backer SearchBackerById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                return null;
            }
            var backer=BackerList.Where(p => p.id_backer == id).FirstOrDefault();
            return backer;
        }
    }
}
