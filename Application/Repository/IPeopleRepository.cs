using Domain;

namespace Application.Repository;

public interface IPeopleRepository
{
    Task<IReadOnlyList<People>> GetAllAsync();
    Task<People> GetByIdAsync(string id);
    Task CreateNewPeopleAsync(People newPeople);
    Task UpdatePeopleAsync(People peopleToUpdate);
    Task DeletePeopleAsync(string id);
}