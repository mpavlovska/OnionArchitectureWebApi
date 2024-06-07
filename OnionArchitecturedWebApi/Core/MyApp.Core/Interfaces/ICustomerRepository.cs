using OnionArchitecturedWebApi.Core.MyApp.Core.Entities;

namespace OnionArchitecturedWebApi.Core.MyApp.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);
    }
}
