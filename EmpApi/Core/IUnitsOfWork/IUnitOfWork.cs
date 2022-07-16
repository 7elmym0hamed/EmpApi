using EmpApi.Core.IRepositories;

namespace EmpApi.Core.IUnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonRepository Persons { get; }
        public IAddressRepository Address { get; }


        public new void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Complete() { }
    }
}
