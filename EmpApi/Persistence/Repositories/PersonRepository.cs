namespace EmpApi.Persistence.Repositories
{
    public class PersonRepository : Repository<PersonModel>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<PersonDto>> GetAllPersons()
        {
            return await _context.Persons.Select(x => new PersonDto
            {
                Id = x.Id,
                PersonName = x.PersonName,
                Age = x.Age,
                AddressId = x.AddressId,
                AddressName = x.Address.AddressName
            }).ToListAsync();
        }
    }
}
