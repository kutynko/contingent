using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Contingent.Api.Models.OrdersContext;
using System.Threading.Tasks;

namespace Contingent.Api.DataAccess
{
    public class ProposalsRepository
    {
        public async Task<IEnumerable<Proposal>> GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.QueryAsync<Proposal>("select * from Proposals");
            }
        }
    }
}