using Forum.Server.GraphQl.Queries;

namespace Forum.Server.GraphQl
{
    public class Query
    {
        public UserQueries UserScope([Service] UserQueries queries) => queries;
    }
}
