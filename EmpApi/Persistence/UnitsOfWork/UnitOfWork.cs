
using EmpApi.Persistence.Contexts;
using EmpApi.Persistence.Repositories;

namespace EmpApi.Persistence.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public IPersonRepository Persons { get; private set; }
        public IAddressRepository Address { get; private set; }

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            Persons = new PersonRepository(_db);
            Address = new AddressRepository(_db);
        }
        public void Complete()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}