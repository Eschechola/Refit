using Refit;
using RefitProject.Entities;
using System.Threading.Tasks;
using RefitProject.Interfaces;
using System.Collections.Generic;

namespace RefitProject.Services
{
    public class CustomerService
    {
        private readonly ICustomerService _customerService;
        private readonly string _apiUrl;

        public CustomerService()
        {
            _apiUrl = "https://refitapi.herokuapp.com/api/v1";
            _customerService = RestService.For<ICustomerService>(_apiUrl);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerService.DeleteAsync(id);
        }

        public async Task<IList<Customer>> GetAsync()
        {
            return await _customerService.GetAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _customerService.GetAsync(id);
        }

        public async Task<Customer> InsertAsync(Customer customer)
        {
            return await _customerService.InsertAsync(customer);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            return await _customerService.UpdateAsync(customer);
        }
    }
}
