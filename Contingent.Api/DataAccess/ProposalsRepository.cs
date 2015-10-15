using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Contingent.Api.Dtos.Proposals;
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

        public async Task Insert(Guid id, ProposalDto item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var proposal =  connection.ExecuteAsync("insert into Proposals(Id, Status, CreatedBy) values(@id, 0, @createdBy);", new { id = id, createdBy = "user" }, transaction);
                    var students =  connection.ExecuteAsync("insert into Proposals_2_Students(ProposalId, StudentId) values(@proposalId, @studentId);", item.Students.Select(s => new { proposalId = id, studentId = s }), transaction);
                    var actions = connection.ExecuteAsync("insert into Proposals_2_Actions(ProposalId, ActionId, [Values]) values(@proposalId, @actionId, @values);", item.Actions.Select(a => new { proposalId = id, actionId = a.Id, values = FormatFieldValuesToXml(a.FieldValues) }), transaction);
                    var reasons = connection.ExecuteAsync("insert into Proposals_2_Reasons(ProposalId, ReasonId, [Values]) values(@proposalId, @reasonId, @values);", item.Reasons.Select(r => new { proposalId = id, reasonId = r.Id, values = FormatFieldValuesToXml(r.FieldValues) }), transaction);

                    await Task.WhenAll(proposal, students, actions, reasons);
                    transaction.Commit();
                }
            }
        }

        public async Task<int> Update(Guid id, ProposalDto item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.ExecuteAsync("update Proposals set Status=@status, CreatedBy=@createdBy, CreatedOn=@createdOn where Id=@id;", item);
            }
        }

        public async Task<int> Delete(Guid id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.ExecuteAsync("delete from Proposals where Id=@id;", new { id = id });
            }
        }

        private static string FormatFieldValuesToXml(List<object> fields)
        {
            var result = new XElement("Values");
            result.Add(fields.Select(v => new XElement("Value", v, new XAttribute("field", "1"))));
            return result.ToString();
        }
    }
}