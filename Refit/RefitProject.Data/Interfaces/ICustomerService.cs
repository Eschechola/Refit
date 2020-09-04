using Refit;
using RefitProject.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RefitProject.Interfaces
{
    public interface ICustomerService
    {
        [Post("/customer")]
        Task<Customer> InsertAsync([Body] Customer customer);

        [Put("/customer")]
        Task<Customer> UpdateAsync([Body] Customer customer);
        
        [Get("/customer")]
        Task<IList<Customer>> GetAsync();

        [Get("/customer/{id}")]
        Task<Customer> GetAsync(int id);

        [Delete("/customer/{id}")]
        Task DeleteAsync(int id);

    }
}
