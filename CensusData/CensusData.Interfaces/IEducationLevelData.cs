using CensusData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusData.Interfaces
{
    public interface IEducationLevelData
    {
        EducationLevelResult GetAll();
    }
}
