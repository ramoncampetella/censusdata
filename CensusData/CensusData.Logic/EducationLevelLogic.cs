using CensusData.Entities;
using CensusData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusData.Logic
{
    public class EducationLevelLogic : IEducationLevelLogic 
    {
        private readonly IEducationLevelData _educationLevelData;
        public EducationLevelLogic(IEducationLevelData educationLevelData)
        {
            _educationLevelData = educationLevelData;
        }

        public EducationLevelResult GetAll()
        {
            return _educationLevelData.GetAll();
        }
    }
}
