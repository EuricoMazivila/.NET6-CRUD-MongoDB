using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Peoples;

public class GetPeopleById
{
    public class GetPeopleByIdQuery : IRequest<People>
    {
        public string Id { get; set; }    
    }
    
    public class GetPeopleByIdHandler : IRequestHandler<GetPeopleByIdQuery, People>
    {
        private readonly IPeopleRepository _peopleRepository;

        public GetPeopleByIdHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public async Task<People> Handle(GetPeopleByIdQuery request, CancellationToken cancellationToken)
        {
            var people = await _peopleRepository.GetByIdAsync(request.Id);
            
            if (people is null)
            {
                throw new Exception("People not found");
            }

            return people;
        }
    }
    
}