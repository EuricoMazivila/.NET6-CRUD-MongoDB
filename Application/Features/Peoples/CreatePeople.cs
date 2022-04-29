using Application.Repository;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Features.Peoples;

public class CreatePeople
{
    public class CreatePeopleCommand : IRequest<People>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
    
    public class CreatePeopleValidator : AbstractValidator<CreatePeopleCommand>
    {
        public CreatePeopleValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumbers).NotEmpty();
        }        
    }
    
    public class CreatePeopleHandler : IRequestHandler<CreatePeopleCommand, People>
    {
        private readonly IPeopleRepository _peopleRepository;

        public CreatePeopleHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public async Task<People> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            var people = new People
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumbers = request.PhoneNumbers
            };

            await _peopleRepository.CreateNewPeopleAsync(people);
            return people;
        }
    }
}