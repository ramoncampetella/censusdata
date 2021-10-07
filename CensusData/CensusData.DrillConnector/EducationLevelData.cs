using CensusData.DrillConnector.Builders;
using CensusData.Entities;
using CensusData.Interfaces;
using drill_csharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusData.DrillConnector
{
    public class EducationLevelData : IEducationLevelData
    {
        private readonly DrillBit _drillBit;

        public EducationLevelData(DrillBit drillBit)
        {
            _drillBit = drillBit;
        }

        public EducationLevelResult GetAll()
        {
            var query = new Query<QueryResponse>(_drillBit);
            var queryResult = query.Execute(@"SELECT educationLevel education_level_name, sum(number) quantity FROM (
	                                        SELECT c.children.educationLevel as educationLevel, count(*) as number 
	                                        FROM (SELECT flatten(children) as children FROM dfs.mnt`districts`) c 
	                                        GROUP BY c.children.educationLevel
	                                        UNION ALL 
	                                        SELECT educationLevel, count(*) as number FROM dfs.mnt`districts` GROUP BY educationLevel
                                        )
                                        GROUP BY educationLevel").Result;
	

            var result = DataBuilder.MapToEducationLevelResult(queryResult);

            return result;
        }
    }
}
