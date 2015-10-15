using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Contingent.Api.Models.OrdersContext;
using Dapper;

using Action = Contingent.Api.Models.OrdersContext.Action;

namespace Contingent.Api.DataAccess
{
    public class ProposalsLookups
    {
        public IEnumerable<Student> GetStudents()
        {
            return new[]
            {
                new Student { Id = Guid.Parse("6173194f-59ab-46af-8eb3-b98a2a235f8b"), Name = "Кутынко Руслан Иванович", Group="ПДМ-021" },
                new Student { Id = Guid.Parse("598eddaf-2c76-4382-885e-0237d6c70820"), Name = "Данилов Пётр Артёмович", Group="ПДМ-021" },
                new Student { Id = Guid.Parse("80a3221c-14e2-4553-876c-fa82bbadd77b"), Name = "Туров Семён Вадимович", Group="ПДМ-021" },
                new Student { Id = Guid.Parse("a3a68ed9-c7b2-49b2-9d86-26510d613cd1"), Name = "Кузнецов Кирилл Ярославович", Group="ПДМ-021" },
                new Student { Id = Guid.Parse("601d3616-bf4e-472b-9ce6-c02cef37c92b"), Name = "Тетерин Максим Святославович", Group="АТ-021" },
                new Student { Id = Guid.Parse("d912a4d1-b535-4106-899d-8cbfed7dec0f"), Name = "Буров Кирилл Аркадьевич", Group="АТ-021" }
            };
        }

        public IEnumerable<Profession> GetProfessions()
        {
            return new[]
            {
                new Profession { Id=Guid.Parse("2061c5a7-256a-4ac1-9cf7-1a1bfc267fcf"), Code="1 36 00 01", Name="Строительные, дорожные машины и оборудование" },
                new Profession { Id=Guid.Parse("7ec9c2ab-eef1-404d-8110-c4ef7025ac19"), Code="1 36 00 02", Name="Строительные, дорожные машины и оборудование" },
                new Profession { Id=Guid.Parse("13156762-248f-477d-89bc-c0147be4166d"), Code="1 36 00 03", Name="Строительные, дорожные машины и оборудование" }
            };
        }

        public async Task<IEnumerable<Action>> GetActions()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return (await connection.QueryAsync("select Id, Description, Fields, IsBatch from Actions")).Select(a => new Action
                {
                    Id = a.Id,
                    Description = a.Description,
                    IsBatch = a.IsBatch,
                    Fields = ReadFieldsFromXml((string)a.Fields).Select(f => new Action.Field(f.Item1, f.Item2, f.Item3)).ToArray()
                });
            }
        }

        public async Task<IEnumerable<Reason>> GetReasons()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return (await connection.QueryAsync("select Id, Description, Fields from Reasons")).Select(a => new Reason
                {
                    Id = a.Id,
                    Description = a.Description,
                    Fields = ReadFieldsFromXml((string)a.Fields).Select(f => new Reason.Field(f.Item1, f.Item2, f.Item3)).ToArray()
                });
            }
        }

        private static IEnumerable<Tuple<string, string, string>> ReadFieldsFromXml(string dbValue)
        {
            if (string.IsNullOrEmpty(dbValue))
            {
                return Enumerable.Empty<Tuple<string, string, string>>();
            }

            return XDocument.Parse(dbValue).Descendants("Field").Select(e => new Tuple<string, string, string>(e.Attribute("id").Value, e.Attribute("caption").Value, e.Attribute("type").Value));
        }
    }
}