using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.Entities;

namespace SkillTracker.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [Route("/api/admin/test")]
        [HttpGet]
        public ActionResult<String> Get()
        {
            try
            {
               
                return "Hi";
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }
        //Rest post api to return list of users
        [Route("/api/admin/alluser")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> AllUsers()
        {
                            //Business logic to call admin servic method which returns list of users
                return null;
         }

        //Rest post api to return  user filtered by first name
        [Route("/api/admin/byfirstname")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByFirstName(String firstname)
        {
                //Business logic to call admin servic method which returns  user filtered by first name
                return null;

            }

        //Rest post api to return  user filtered by email
        [Route("/api/admin/byemail")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByEmail(String email)
        {
          
                //Business logic to call admin servic method which returns  user filtered by email id
                return null;

            }

        //Rest post api to return  user filtered by mobile number
        [Route("/api/admin/bymobile")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByMobileNumber(long mobile)
        {
            //Business logic to call admin servic method which returns  user filtered by mobile number
                return null;

            }

        //Rest post api to return  user filtered by Skill range
        [Route("/api/admin/byskillrange")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> SearchBySkillRange(int startvalue)
        {
         
                //Business logic to call admin servic method which returns list of  users filtered by range value
                return null;

            }
    }
}