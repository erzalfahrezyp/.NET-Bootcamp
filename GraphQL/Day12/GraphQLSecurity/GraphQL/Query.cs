using HotChocolate.Authorization;

namespace GraphQLSecurity.GraphQL
{
    public class Query
    {
        public string GetMessage() => "Hello from GraphQL";
        [Authorize]
        public string GetPrivateMessage() => "Ini Pesan Rahasia";
        [Authorize(Roles = new[] {"Manager"})]
        public string GetManagerMessage() => "Hello Manager";
        [Authorize(Roles = new[] {"Admin"})]
        public string GetAdminMessage() => "Hello Admin";
    }
}
