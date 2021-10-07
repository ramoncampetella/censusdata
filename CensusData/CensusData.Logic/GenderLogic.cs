using CensusData.Entities;
using CensusData.Interfaces;
using System;

namespace CensusData.Logic
{
    public class GenderLogic : IGenderLogic
    {
        private readonly IGenderData _genderData;
        public GenderLogic(IGenderData genderData)
        {
            _genderData = genderData;
        }

        public GenderResult GetAll()
        {
            return _genderData.GetAll();
        }

        public GenderResult GetMaleFemaleByDistrict(int idDistrict)
        {
            return _genderData.GetMaleFemaleByDistrict(idDistrict);
        }
    }
}
