﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SkillTracker.API;
using SkillTracker.Entities;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace SkillTracker.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class FunctionalTest
    {
        // private references declaration
        private User _user;
        IConfigurationRoot config;
        private Skill _skill;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        static FileUtility fileUtility;

        public FunctionalTest()
        {
            _skill = new Skill
            {
                SkillName = ".Net microservices",
                SkillCategory = SkillCategory.DotNet,
                SkillLevel = SkillLevel.Intermediate,
                SkillType = SkillType.Programming,
                SkillTotalExperiance = 6
            };

            _user = new User
            {

                FirstName = "mini",
                LastName = "kumar",
                Email = "mini@gmail.com",
                Mobile = 9685742536,
                MapSkills = 3
            };

            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            _server = new TestServer(new WebHostBuilder()
           .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        static FunctionalTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_revised.txt";
            fileUtility.CreateTextFile();
        }

        //Test methods for Skill Controller
        [Fact]
        public async Task FunctionalTestFor_NewSkill_ActionMethod()
        {
            try
            {

                HttpContent content = new StringContent(JsonConvert.SerializeObject(_skill), Encoding.UTF8, "application/json");

                String skillResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/skill/new", content);
                var status = response.EnsureSuccessStatusCode();

                String skills = String.Empty;

                if (status.IsSuccessStatusCode)
                {
                    skillResponse = response.Content.ReadAsStringAsync().Result;
                    skills = skillResponse;
                }
                if (skills != string.Empty)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_NewSkill_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_NewSkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get New Skill Added message from api"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New Skill Added", skills);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_NewSkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_NewSkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get New Skill Added message from api but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_ReviseSkill_ActionMethod()
        {
            try
            {
                _skill.SkillLevel = SkillLevel.Expert;
                _skill.SkillTotalExperiance = 12;
                _skill.SkillType = SkillType.Programming;
                _skill.SkillCategory = SkillCategory.FullStack;
                HttpContent content = new StringContent(JsonConvert.SerializeObject(_skill), Encoding.UTF8, "application/json");

                String skillResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/skill/edit", content);
                var status = response.EnsureSuccessStatusCode();

                int editResult = 0;

                if (status.IsSuccessStatusCode)
                {
                    skillResponse = response.Content.ReadAsStringAsync().Result;
                    editResult =JsonConvert.DeserializeObject<int>( skillResponse);
                }
                if (editResult !=0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_ReviseSkill_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_ReviseSkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get New Skill Added message from api"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, editResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_ReviseSkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_ReviseSkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get New Skill Added message from api but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroySkill_ActionMethod()
        {
            try
            {
               
                HttpContent content = new StringContent(JsonConvert.SerializeObject(_skill.SkillName), Encoding.UTF8, "application/json");

                String skillResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/skill/delete?SkillName="+ _skill.SkillName,null);
                var status = response.EnsureSuccessStatusCode();

                int deleteResult = 0;

                if (status.IsSuccessStatusCode)
                {
                    skillResponse = response.Content.ReadAsStringAsync().Result;
                    deleteResult = JsonConvert.DeserializeObject<int>(skillResponse);
                }
                if (deleteResult != 0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_DestroySkill_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_DestroySkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get 1 value after successfull deletion of skill from api"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, deleteResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_DestroySkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_DestroySkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get 1 value after successfull deletion of skill from api but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for User Controller

        [Fact]
        public async Task FunctionalTestFor_NewUser_ActionMethod()
        {
            try
            {
                fileUtility.ValidateUser(_user);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(_user), Encoding.UTF8, "application/json");

                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/user/new", content);
                var status = response.EnsureSuccessStatusCode();

                String userResult = String.Empty;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    userResult = userResponse;
                }
                if (userResult == "New User Register")
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_NewUser_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_NewUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get New User Registered message from api"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New User Register", userResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_NewUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_NewUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get New User Registered message from api but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_ReviseUser_ActionMethod()
        {
            try
            {
                User user = new User
                {
                    FirstName = "prathvi",
                    LastName = "Oldaddi",
                    Email = "prathvi@gmail.com",
                    Mobile = 9960814103,
                    MapSkills = 3

                };
                 fileUtility.TestData(user);

                user.Email = "prathviraj@gmail.com";
                user.Mobile = 9960814103;
                user.MapSkills = 5;
                HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/user/edit", content);
                var status = response.EnsureSuccessStatusCode();

                int editResult = 0;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    editResult =JsonConvert.DeserializeObject<int>( userResponse);
                }
                if (editResult != 0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_ReviseUser_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_ReviseUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get 1 as success value  from api after updating user"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, editResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_ReviseUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_ReviseUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get 1 as success value  from api after updating user but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroyUser_ActionMethod()
        {
            try
            {
                User user = new User
                {
                    FirstName = "prathvi",
                    LastName = "Oldaddi",
                    Email = "prathvi@gmail.com",
                    Mobile = 9960814103,
                    MapSkills = 3

                };
                fileUtility.TestData(user);

                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/user/delete?firstname="+ user.FirstName+ "&lastname="+ user.LastName,null);
                var status = response.EnsureSuccessStatusCode();

                int deleteResult = 0;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    deleteResult = JsonConvert.DeserializeObject<int>(userResponse);
                }
                if (deleteResult != 0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_DestroyUser_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_DestroyUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get 1 as success value  from api after deleting user"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, deleteResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_DestroyUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_DestroyUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get 1 as success value  from api after deleting user but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for Admin Controller
        [Fact]
        public async Task FunctionalTestFor_AllUsers_ActionMethod()
        {
            try
            {


                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/admin/alluser", null);
                var status = response.EnsureSuccessStatusCode();

                List<User> alluserResult =null;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    alluserResult = JsonConvert.DeserializeObject<List<User>>(userResponse);
                }
                if (alluserResult.Count != 0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_AllUsers_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_AllUsers_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get list of users  from api "
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEmpty( alluserResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_AllUsers_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_AllUsers_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get list of users  from api  from api but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByFirstName_ActionMethod()
        {
            try
            { 
            String userResponse = string.Empty;
            HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/admin/byfirstname?firstname=" + _user.FirstName , null);
            var status = response.EnsureSuccessStatusCode();

            User userResult = null;

            if (status.IsSuccessStatusCode)
            {
                userResponse = response.Content.ReadAsStringAsync().Result;
                userResult = JsonConvert.DeserializeObject<User>(userResponse);
            }
            if (userResult != null && userResult.FirstName==_user.FirstName)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_InspectUserByFirstName_ActionMethod=True";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByFirstName_ActionMethod",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "Expected to get user details from api after filtering user by firstname"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
            else
            {
                Assert.NotNull(userResult);
                Assert.Equal(_user.FirstName, userResult.FirstName);

            }
        }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_InspectUserByFirstName_ActionMethod=" + "False";
        fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByFirstName_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get user details from api after filtering user by firstname but fail"
                    };
        fileUtility.WriteTestCaseResuItInXML(newcase);
                }
}
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByEmail_ActionMethod()
        {
            try
            {
               
                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/admin/byemail?email=" + _user.Email, null);
                var status = response.EnsureSuccessStatusCode();

                User userResult = null;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    userResult = JsonConvert.DeserializeObject<User>(userResponse);
                }
                if (userResult != null && userResult.FirstName == _user.FirstName)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_InspectUserByEmail_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserByEmail_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get user details from api after filtering user by email"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(userResult);
                    Assert.Equal(_user.FirstName, userResult.FirstName);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_InspectUserByEmail_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByEmail_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get user details from api after filtering user by email but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByMobileNumber_ActionMethod()
        {
            try
            {

                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/admin/bymobile?mobile=" + _user.Mobile, null);
                var status = response.EnsureSuccessStatusCode();

                User userResult = null;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    userResult = JsonConvert.DeserializeObject<User>(userResponse);
                }
                if (userResult != null && userResult.Mobile == _user.Mobile)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get user details from api after filtering user by mobilenumber"
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(userResult);
                    Assert.Equal(_user.Mobile, userResult.Mobile);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get user details from api after filtering user by mobile number but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task FunctionalTestFor_InspectUserBySkillRange_ActionMethod()
        {
            try
            {

                String userResponse = string.Empty;
                HttpResponseMessage response = await _client.PostAsync("https://localhost:5001/api/admin/byskillrange?startvalue=" + 2, null);
                var status = response.EnsureSuccessStatusCode();

               List<User> userResult = null;

                if (status.IsSuccessStatusCode)
                {
                    userResponse = response.Content.ReadAsStringAsync().Result;
                    userResult = JsonConvert.DeserializeObject<List<User>>(userResponse);
                }
                if (userResult != null && userResult.Count >0)
                {

                    //Write test result in text file

                    String testResult = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod=True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    //Write test result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expected to get user details from api after filtering user by  Map skill "
                        };
                        fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(userResult);
                    Assert.NotEmpty(userResult);

                }
            }

            catch (Exception ex)
            {

                //Write test result in text file

                String testResult = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

                //Write test result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expected to get user details from api after filtering user by Map skill but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}