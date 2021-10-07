using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace drill_csharp
{
    public class Query<T>
    {
        private readonly DrillBit _drillbit;

        public Query(DrillBit drillbit)
        {
            _drillbit = drillbit;
        }

        public async Task<T> Execute(string sql)
        {
            var url = "query.json";
            var query = new Dictionary<string, string>();
            query.Add("queryType", "SQL");
            query.Add("query", sql);

            var result = await _drillbit.PostRequest(url, query);
            var response = JsonConvert.DeserializeObject<T>(result);
            return response;
        }
    }
}