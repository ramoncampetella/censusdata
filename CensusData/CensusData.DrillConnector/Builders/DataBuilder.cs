using CensusData.Entities;
using drill_csharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusData.DrillConnector.Builders
{
    public class DataBuilder
    {
        public static GenderResult MapToGenderResult(QueryResponse origin) {
            GenderResult destiny = new GenderResult();
            destiny.GenderStats = new List<Gender>();
            Gender gender;

            foreach (var item in origin.Rows)
            {
                gender = new Gender();
                gender.GenderName = item.gender_name;
                gender.Quantity = item.quantity;
                destiny.GenderStats.Add(gender);
            }

            return destiny;
        }

        public static EducationLevelResult MapToEducationLevelResult(QueryResponse origin)
        {
            EducationLevelResult destiny = new EducationLevelResult();
            destiny.EducationLevelStats = new List<EducationLevel>();
            EducationLevel educationLevel;

            foreach (var item in origin.Rows)
            {
                educationLevel = new EducationLevel();
                educationLevel.EducationLevelName = item.education_level_name;
                educationLevel.Quantity = item.quantity;
                destiny.EducationLevelStats.Add(educationLevel);
            }

            return destiny;
        }
    }
}
