using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RefitProject.Entities;
using RefitProject.Services;

namespace Refit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program()
                .Execute()
                .GetAwaiter()
                .GetResult();

            Console.ReadKey();
        }

        private CustomerService _customerService;

        public Program()
        {
            _customerService = new CustomerService();
        }

        private async Task Execute()
        {
            var customerInserted = await Post();
            await Put(customerInserted.Id);
            await Get(customerInserted.Id);
            await GetAll();
            await Delete(customerInserted.Id);
        }

        private async Task<Customer> Post()
        {

            var customerInsert = new Customer
            {
                Name = "Lucas",
                Email = "lucas@eu.com",
                Password = "123321"
            };

            var customerInserted = await _customerService.InsertAsync(customerInsert);

            Console.WriteLine("\nCliente inserido!\n" + JsonConvert.SerializeObject(customerInserted, Formatting.Indented));

            return customerInserted;
        }

        private async Task<Customer> Put(int id)
        {
            var customerUpdate = new Customer
            {
                Id = id,
                Name = "Lucas Alterado",
                Email = "email@alterado.com",
                Password = "alterado123"
            };

            var customerUpdated = await _customerService.UpdateAsync(customerUpdate);

            Console.WriteLine("\nCliente atulizado!\n" + JsonConvert.SerializeObject(customerUpdated, Formatting.Indented));

            return customerUpdated;
        }

        public async Task Get(int id)
        {
            var customer = await _customerService.GetAsync(id);

            Console.WriteLine("\nCliente encontrado com suceso!\n" + JsonConvert.SerializeObject(customer, Formatting.Indented));
        }
        
        public async Task GetAll()
        {
            var customers = await _customerService.GetAsync();

            Console.WriteLine("\nClientes encontrados com suceso!\n" + JsonConvert.SerializeObject(customers, Formatting.Indented));
        }

        public async Task Delete(int id)
        {
            await _customerService.DeleteAsync(id);

            Console.WriteLine("\nCliente deletado com sucesso!");
        }
    }
}
