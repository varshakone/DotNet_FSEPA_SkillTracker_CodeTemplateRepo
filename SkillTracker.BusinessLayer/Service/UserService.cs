using MongoDB.Driver;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service.Repository;
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
        private readonly IUserRepository _userRepository;
       
        /// <summary>
        /// Create Object of type IUserRepository
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Save new user into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> CreateNewUser(User user)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }

        /// <summary>
        /// delete user details from database
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
       
        public async Task<int> RemoveUser(string firstname, string lastname)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }


        /// <summary>
        /// update user details into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
     public async Task<int> UpdateUser(User user)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }


        /// <summary>
        /// return list of all users 
        /// </summary>
        /// <returns></returns>
       
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search user by it's email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        
        public async Task<User> SearchUserByEmail(string Email)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search user by it's first name
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns></returns>
        
        public async Task<User> SearchUserByFirstName(string firstname)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }


        /// <summary>
        /// Search user by it's mobile number
        /// </summary>
        /// <param name="mobilenumber"></param>
        /// <returns></returns>
        
        public async Task<User> SearchUserByMobile(long mobilenumber)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }


        /// <summary>
        /// Search user by it's skill range between start value and end value
        /// </summary>
        /// <param name="startvalue"></param>
        /// <returns></returns>
       
        public async Task<IEnumerable<User>> SearchUserBySkillRange(int startvalue, int endvalue)
        {
            //Business Logic to call UserRepository method
            throw new NotImplementedException();
        }
    }
}
