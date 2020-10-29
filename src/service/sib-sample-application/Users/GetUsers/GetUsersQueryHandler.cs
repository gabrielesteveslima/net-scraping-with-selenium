namespace SibSample.Application.Users.GetUsers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users;

    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserContract>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserContract>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers();
            return users.Select(x => new UserContract
            {
                Id = x.Id.Value,
                Name = x.Name,
                Email = x.Email.Value
            }).ToList();
        }
    }
}