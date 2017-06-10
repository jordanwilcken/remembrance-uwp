using Microsoft.Data.Sqlite;
using persistence_component.PoorMansGenerics;
using System;
using System.Linq;

namespace persistence_component
{
    public sealed class UsersRepo
    {
        private Func<IConnection> MakeConnection { get; }

        public UsersRepo(IMakeConnection connectionMaker)
        {
            MakeConnection = connectionMaker.MakeConnection;
        }

        public UserDTO Get(string username)
        {
             var query = new QueryBuilder()
               .GetColumns(new string[] { "rowid", "username", "hashed_password" })
               .From("users")
               .Where("username = @username")
               .WithInjectionProtection(
                    new InjectionProtection(
                        new SqliteParameter[] {
                            new SqliteParameter("@username", username)
                        } ))
               .BuildQuery();

            var dtos = query
                .RunOnConnection(MakeConnection())
                .Select(fields => new UserDTO(fields));

            return dtos.First();
        }
    }
}
