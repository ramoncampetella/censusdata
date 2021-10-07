using CensusData.DrillConnector.Builders;
using CensusData.Entities;
using CensusData.Interfaces;
using drill_csharp;


namespace CensusData.DrillConnector
{
    public class GenderData : IGenderData
    {
        private readonly DrillBit _drillBit;
        public GenderData(DrillBit drillBit)
        {
            _drillBit = drillBit;
        }
        public GenderResult GetAll()
        {
            
            var query = new Query<QueryResponse>(_drillBit);
            var queryResult = query.Execute(@"SELECT sex gender_name, sum(number) quantity FROM(
                                        SELECT c.children.sex as SEX, count(*) as number
                                        FROM(SELECT flatten(children) as children FROM dfs.mnt`districts`) c
                                        GROUP BY c.children.sex
                                        UNION ALL
                                        SELECT sex, count(*) as number FROM dfs.mnt`districts` GROUP BY sex)
                                        GROUP BY sex").Result;

            var result = DataBuilder.MapToGenderResult(queryResult);

            return result;
        }

        public GenderResult GetMaleFemaleByDistrict(int idDistrict)
        {
            var query = new Query<QueryResponse>(_drillBit);
            var queryResult = query.Execute($@"SELECT sex gender_name, sum(number) quantity
	                                        FROM (
		                                        SELECT c.children.sex as SEX, count(*) as number 
                                                FROM (SELECT flatten(children) as children FROM dfs.mnt`districts`
                                                WHERE district = {idDistrict}) c 
                                                GROUP BY c.children.sex
	                                        UNION ALL 
		                                        SELECT sex, count(*) as number FROM dfs.mnt`districts`
		                                        WHERE district = {idDistrict}
		                                        GROUP BY sex, district)
	                                        WHERE sex in ('Female', 'Male')
	                                        GROUP BY sex").Result;

            var result = DataBuilder.MapToGenderResult(queryResult);

            return result;
        }

        
    }
}
