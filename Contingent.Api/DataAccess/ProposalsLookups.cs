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

        public async Task<IEnumerable<Action>> GetActions()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                return (await connection.QueryAsync("select Id, Description, Fields, IsButch from Actions")).Select(a => new Action
                {
                    Id = a.Id,
                    Description = a.Description,
                    IsButch = a.IsButch,
                    Fields = XDocument.Parse(a.Fields).Elements().Select((Func<XElement, Action.Field>)(e => new Action.Field(e.Attribute(XName.Get("caption", "")).Value, e.Attribute(XName.Get("type", "")).Value))).ToArray()
                });
            }
        }
    }
}