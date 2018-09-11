using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository.Interfaces
{
    public interface IUserProfileRepository
    {
        UserProfile GetProfile(string id);
        void SetProfile(string id, UserProfile profile);
    }
}