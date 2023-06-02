using FinalDigicoApi.DBAccess;
using FinalDigicoApi.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalDigicoApi.Service
{
    public class DataService
    {
        public DataService([FromServices] DBAccessor dBAccessor)
        {
            this._dbaccess = dBAccessor;
        }
        private DBAccessor _dbaccess;

        public List<BasicOccupation> GetBasicOccupations()
        {
            return _dbaccess.Occupations.ToList();
        }
        public List<BasicSkill> GetBasicSkills()
        {
            return _dbaccess.Skills.ToList();
        }


        public BasicOccupation GetBasicOccupation(string href)
        {
            var x = _dbaccess.Occupations.ToList().FirstOrDefault(o => o.selfRef == href, null);

            return x == null ? new BasicOccupation() : x;
        }

        public BasicSkill GetBasicSkill(string href)
        {
            var x = _dbaccess.Skills.ToList().FirstOrDefault(s => s.selfRef == href, null);

            return x;
        }

        public int UpdateBasicSkill(BasicSkill basicSkill)
        {
            var x = _dbaccess.Skills
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(c => c.selfRef == basicSkill.selfRef, null);
            if (x != null)
            {
                _dbaccess.Skills.Update(basicSkill);
                return _dbaccess.SaveChanges();
            }
            
            return CreateBasicSkill(basicSkill);
        }

        public int CreateBasicSkill(BasicSkill basicSkill)
        {
            _dbaccess.Skills.Add(basicSkill);
            return _dbaccess.SaveChanges();
        }

        public int DeleteBasicSkill(string href)
        {
            _dbaccess.Skills.Remove(GetBasicSkill(href));

            return _dbaccess.SaveChanges();
        }

        public int UpdateBasicOccupation(BasicOccupation basicOccupation)
        {
            var x = _dbaccess.Occupations
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(o => o.selfRef == basicOccupation.selfRef, null);
            if (x != null)
            {
                _dbaccess.Occupations.Update(basicOccupation);
                return _dbaccess.SaveChanges(); 
            }
            return CreateBasicOccupation(basicOccupation);
        }

        public int CreateBasicOccupation(BasicOccupation basicOccupation)
        {
            _dbaccess.Occupations.Add(basicOccupation);
            return _dbaccess.SaveChanges();
        }

        public int DeleteBasicOccupation(string href)
        {
            _dbaccess.Occupations.Remove(GetBasicOccupation(href));

            return _dbaccess.SaveChanges();
        }

        public void ResetDB()
        {
            foreach (var item in _dbaccess.Skills.ToList())
            {
                _dbaccess.Skills.Remove(item);
                
            }
            foreach (var item in _dbaccess.Occupations.ToList())
            {
                _dbaccess.Occupations.Remove(item);
            }
            foreach (var item in _dbaccess.occationBasicSkills.ToList())
            {
                _dbaccess.occationBasicSkills.Remove(item);
            }
            _dbaccess.SaveChanges();
        }
    }
}
