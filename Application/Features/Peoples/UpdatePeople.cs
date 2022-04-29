using Application.Repository;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Features.Peoples;

public class UpdatePeople
{
    public class UpdatePeopleCommand : IRequest<People>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
    
    public class UpdatePeopleValidator : AbstractValidator<UpdatePeopleCommand>
    {
        public UpdatePeopleValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumbers).NotEmpty();
        }
    }
    
    public class UpdatePeopleHandler : IRequestHandler<UpdatePeopleCommand, People>
    {
        private readonly IPeopleRepository _peopleRepository;

        public UpdatePeopleHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public async Task<People> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            var people = await _peopleRepository.GetByIdAsync(request.Id);
            
            if (people is null)
            {
                throw new Exception("People not found");
            }

            people.Name = request.Name;
            people.Email = request.Email;
            people.PhoneNumbers = request.PhoneNumbers;

            await _peopleRepository.UpdatePeopleAsync(people);
            
            return people;
        }
    }
}