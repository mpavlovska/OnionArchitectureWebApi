using OnionArchitecturedWebApi.Core.MyApp.Core.Entities;
using OnionArchitecturedWebApi.Core.MyApp.Core.Interfaces;

namespace OnionArchitecturedWebApi.Application.MyApp.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerRepository.GetCustomer(customerId);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }
    }
}
