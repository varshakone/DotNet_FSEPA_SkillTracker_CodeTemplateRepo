using MongoDB.Driver;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<User> _mongoCollection;

        public UserService(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<User>(typeof(User).Name);
         
        }

        //Save new user into database
        public string CreateNewUser(User user)
        {
            //MongoDB Logic to save user document into database
            return null;
        }
        //Save new user into database
        public string ValidateUserExist(User user)
        {
            //MongoDB Logic to save user document into database
            return null;
        }

        //delete user details from database
        public int RemoveUser(string firstname, string lastname)
        {
            //MongoDB Logic to delete user document into database
            return 0;
        }

        //update user details into database
        public int UpdateUser(User user)
        {
            //MongoDB Logic to update user document into database
            return 0;
        }
    }
}
