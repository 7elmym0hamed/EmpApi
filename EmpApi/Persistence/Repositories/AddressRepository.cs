
namespace EmpApi.Persistence.Repositories
{
    public class AddressRepository : Repository<AddressModel>, IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async  Task<List<AddessDto>> GetAllAddress()
        {
            return await _context.Address.Select(x => new AddessDto
            {
                Id = x.Id,
                AddressName = x.AddressName,
                IsEdit = false
            }).ToListAsync();

        }
    }
}