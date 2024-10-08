using Forum.Domain.Entities;
using Forum.Server.GraphQl.Types;
using Forum.Server.ViewModels;
using User = Forum.Domain.Entities.User;

namespace Forum.Server.Mapper
{
    public static class UserMapper
    {
        public static UserType ToUserType(this User user)
        {
            return new UserType
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
            };
        }

        public static IEnumerable<UserType> ToUserTypeList(this IEnumerable<User> users)
        {
            return users.Select(userType => ToUserType(userType)).ToList();
        }
    }
}
