using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Peoples;

public class DeletePeople 
{
    public class DeletePeopleCommand : IRequest<People>
    {
        public string Id { get; set; }
    }
    
    public class DeletePeopleHandler : IRequestHandler<DeletePeopleCommand, People>
    {
        private readonly IPeopleRepository _peopleRepository;

        public DeletePeopleHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public async Task<People> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
        {
            var people = await _peopleRepository.GetByIdAsync(request.Id);
            
            if (people is null)
            {
                throw new Exception("People not found");
            }

            await _peopleRepository.DeletePeopleAsync(request.Id);
            
            return people;
        }
    }
    
}