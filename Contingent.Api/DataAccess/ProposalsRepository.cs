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
        public async Task<IEnumerable<ProposalReadModel>> GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return await connection.QueryAsync<ProposalReadModel>("select Id, Status, CreatedBy, CreatedOn, UpdatedOn from Proposals;");
            }
        }

        public async Task<ProposalReadModel> GetById(Guid id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                var grid = await connection.QueryMultipleAsync(@"select Id, Status, CreatedBy, CreatedOn, UpdatedOn from Proposals where Id = @id
select StudentId from Proposals_2_Students where ProposalId = @id
select ActionId, [Values] from Proposals_2_Actions where ProposalId = @id
select ReasonId, [Values] from Proposals_2_Reasons where ProposalId = @id;", new { id = id });
                var result = grid.Read<ProposalReadModel>().FirstOrDefault();

                if (result != null)
                {
                    result.Students = grid.Read<Guid>().ToList();
                    result.Actions = grid.Read().Select(row => new ActionValues { Id = row.ActionId, FieldValues = FieldsXmlHelpers.ValuesFromXml(row.Values) }).ToList();
                    result.Reasons = grid.Read().Select(row => new ReasonValues { Id = row.ReasonId, FieldValues = FieldsXmlHelpers.ValuesFromXml(row.Values) }).ToList();
                }

                return result;
            }
        }

        public async Task Insert(Guid id, ProposalEditModel item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var proposal = connection.ExecuteAsync("insert into Proposals(Id, Status, CreatedBy, CreatedOn, UpdatedOn) values(@id, 0, @createdBy, @now, @now);", new { id = id, createdBy = "user", now = DateTime.UtcNow }, transaction);
                    var students = connection.ExecuteAsync("insert into Proposals_2_Students(ProposalId, StudentId) values(@proposalId, @studentId);", item.Students.Select(s => new { proposalId = id, studentId = s }), transaction);
                    var actions = connection.ExecuteAsync("insert into Proposals_2_Actions(ProposalId, ActionId, [Values]) values(@proposalId, @actionId, @values);", item.Actions.Select(a => new { proposalId = id, actionId = a.Id, values = FieldsXmlHelpers.ValuesToXml(a.FieldValues) }), transaction);
                    var reasons = connection.ExecuteAsync("insert into Proposals_2_Reasons(ProposalId, ReasonId, [Values]) values(@proposalId, @reasonId, @values);", item.Reasons.Select(r => new { proposalId = id, reasonId = r.Id, values = FieldsXmlHelpers.ValuesToXml(r.FieldValues) }), transaction);

                    await Task.WhenAll(proposal, students, actions, reasons);
                    transaction.Commit();
                }
            }
        }

        public async Task<int> Update(Guid id, ProposalEditModel item)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteAsync(@"update Proposals set Status=@status, UpdatedOn=@now where Id=@id
delete from Proposals_2_Students where ProposalId = @id
delete from Proposals_2_Actions where ProposalId = @id
delete from Proposals_2_Reasons where ProposalId = @id;", new { id = id, status = 0, now = DateTime.UtcNow }, transaction);

                    var students = connection.ExecuteAsync("insert into Proposals_2_Students(ProposalId, StudentId) values(@proposalId, @studentId);", item.Students.Select(s => new { proposalId = id, studentId = s }), transaction);
                    var actions = connection.ExecuteAsync("insert into Proposals_2_Actions(ProposalId, ActionId, [Values]) values(@proposalId, @actionId, @values);", item.Actions.Select(a => new { proposalId = id, actionId = a.Id, values = FieldsXmlHelpers.ValuesToXml(a.FieldValues) }), transaction);
                    var reasons = connection.ExecuteAsync("insert into Proposals_2_Reasons(ProposalId, ReasonId, [Values]) values(@proposalId, @reasonId, @values);", item.Reasons.Select(r => new { proposalId = id, reasonId = r.Id, values = FieldsXmlHelpers.ValuesToXml(r.FieldValues) }), transaction);

                    await Task.WhenAll(students, actions, reasons);
                    transaction.Commit();

                    return result;
                }

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