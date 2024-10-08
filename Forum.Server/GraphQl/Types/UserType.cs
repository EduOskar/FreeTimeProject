namespace Forum.Server.GraphQl.Types
{
    [GraphQLName("User")]
    public class UserType
    {
        [GraphQLNonNullType]
        [GraphQLType(typeof(Guid))]
        public Guid Id { get; set; }

        [GraphQLNonNullType]
        [GraphQLType(typeof(string))]
        public string FirstName { get; set; } = default!;

        [GraphQLNonNullType]
        [GraphQLType(typeof(string))]
        public string LastName { get; set; } = default!;

        [GraphQLNonNullType]
        [GraphQLType(typeof(string))]
        public string UserName { get; set; } = default!;

        [GraphQLNonNullType]
        [GraphQLType(typeof(string))]
        public string Password { get; set; } = default!;

        [GraphQLNonNullType]
        [GraphQLType(typeof(string))]
        public string Email { get; set; } = default!;
    }
}
