using System;
using System.Collections.Generic;
using System.Text;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore.Services
{
    public interface IUserService
    {
        User AddUser(AddUserOptions options);
        bool UpdateBackerOptions(int user_id, UpdateUserOptions options);
        User SearchUserById(int id);
    }
}
