using GraphQL.Types;

namespace Forum.Server.ViewModels
{
    public record User(Guid Id,  string firstName, string LastName, string Username, string Email);

    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Username { get; set; } = default!;

        public string Email { get; set; } = default!;
    }

    public class UserDetailsType : ObjectGraphType<UserViewModel>
    {
        public UserDetailsType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Username);
            Field(x => x.Email);
        }
    }
}
