namespace EmpApi.Core.IRepositories
{
    public interface IPersonRepository : IRepository<PersonModel>
    {
        Task<List<PersonDto>> GetAllPersons();
    }
}
