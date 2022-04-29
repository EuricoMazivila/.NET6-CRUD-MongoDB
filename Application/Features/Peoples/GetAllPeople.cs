using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Peoples;

public class GetAllPeople 
{
    public class GetAllPeopleQuery : IRequest<IReadOnlyList<People>>
    {
        
    }

    public class GetAllPeopleHandler : IRequestHandler<GetAllPeopleQuery, IReadOnlyList<People>>
    {
        private readonly IPeopleRepository _peopleRepository;

        public GetAllPeopleHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        
        public async Task<IReadOnlyList<People>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            return await _peopleRepository.GetAllAsync();
        }
    }
}