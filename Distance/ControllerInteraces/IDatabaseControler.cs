using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.ControllerInteraces
{
    public interface IDatabaseControler
    {
        ApplicationUser GetUserById(string Id);
        List<string> GetUserRoles(ApplicationUser user);
    }
}