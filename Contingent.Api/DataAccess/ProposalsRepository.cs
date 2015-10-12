using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Contingent.Api.Models.OrdersContext;
using Dapper;

namespace Contingent.Api.DataAccess
{
    public class ProposalsRepository
    {
        public async Task<IEnumerable<Proposal>> GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.QueryAsync<Proposal>("select Id, Status, CreatedBy, CreatedOn from Proposals;");
            }
        }

        public async Task<Proposal> GetById(Guid id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return (await connection.QueryAsync<Proposal>("select Id, Status, CreatedBy, CreatedOn from Proposals where Id=@id;", new { id = id })).FirstOrDefault();
            }
        }

        public async Task Insert(Proposal item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                await connection.ExecuteAsync("insert into Proposals(Id, Status, CreatedBy, CreatedOn) values(@id, @status, @createdBy, @createdOn);",
                    new { id = item.Id, status = item.Status, createdBy = item.CreatedBy, createdOn = item.CreatedOn });
            }
        }

        public async Task<int> Update(Proposal item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.ExecuteAsync("update Proposals set Status=@status, CreatedBy=@createdBy, CreatedOn=@createdOn where Id=@id;",
                    new { id = item.Id, status = item.Status, createdBy = item.CreatedBy, createdOn = item.CreatedOn });
            }
        }

        public async Task<int> Delete(Guid id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.ExecuteAsync("delete from Proposals where Id=@id;", new { id = id });
            }
        }
    }
}