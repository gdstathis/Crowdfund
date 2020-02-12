using System;
using System.Collections.Generic;
using System.Text;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    interface IBackerService
    {
        Backer AddBacker(AddBackerOptions newBacker);

        bool UpdateBackerOptions(string id, UpdateBackerOptions options);
    }
}

