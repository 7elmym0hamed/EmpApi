
namespace EmpApi.Core.IRepositories
{
    public interface IAddressRepository : IRepository<AddressModel>
    {
        Task<List<AddessDto>> GetAllAddress();
    }
}
