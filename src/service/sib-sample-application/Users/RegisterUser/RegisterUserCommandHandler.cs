namespace SibSample.Application.Users.RegisterUser
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Core.Data;
    using Domain.Users;
    using Domain.Users.Documents;
    using Document = Domain.Users.Documents.Document;

    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, UserContract>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _uow;

        public RegisterUserCommandHandler(IUserRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<UserContract> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var contract = request.UserContract;
            var documentList = request.UserContract.Documents.Select(x =>
                new Document(x.Value, (DocumentType)Enum.Parse(typeof(DocumentType), x.DocumentType, true))).ToList();
            var email = new Email(contract.Email);

            var user = new UserBuilder()
                .WithName(contract.Name)
                .WithEmail(email)
                .WithDocuments(documentList)
                .Build();

            await _repository.NewUser(user);
            await _uow.CommitAsync(cancellationToken);

            return new UserContract
            {
                Id = user.Id.Value,
                Documents = user.Documents.Select(x => new DocumentContract
                {
                    Id = x.Id.Value, Value = x.Value, DocumentType = x.DocumentType.ToString()
                }).ToList()
            };
        }
    }
}