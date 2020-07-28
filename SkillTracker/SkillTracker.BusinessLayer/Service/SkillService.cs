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
    public class SkillService : ISkillService
    {

        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<Skill> _mongoCollection;

        public SkillService(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<Skill>(typeof(Skill).Name);
        }

        // Save new skill upgarded by full stack engineer into database
        public string AddNewSkill(Skill skill)
        {
            //MongoDB Logic to save Skill document into database
          
        }
        // delete skill of full stack engineer from database
        public int DeleteSkill(string skillname)
        {
            //MongoDB Logic to delete Skill document into database
           
        }
        // update skill upgarded by full stack engineer from database
        public int EditSkill(Skill skill)
        {
            //MongoDB Logic to update Skill document into database
           
        }
    }
}
