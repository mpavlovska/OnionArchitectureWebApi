using Microsoft.AspNetCore.Mvc;
using OnionArchitecturedWebApi.Application.MyApp.Application.Services;
using OnionArchitecturedWebApi.Core.MyApp.Core.Entities;

namespace OnionArchitecturedWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public ActionResult<string> GetCustomer(int customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            if (customer == null)
            {
                return NotFound("No customer found.");
            }
            return Ok($"Customer Name: {customer.Name}");
        }

        [HttpPost]
        public ActionResult<string> AddCustomer([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok("Customer added.");
        }
    }
}
