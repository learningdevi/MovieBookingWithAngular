/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.DAO;
using Microsoft.Core.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This class provides API to handle customer services.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private ILogger<CustomerService> logger;
        private readonly ICustomerRepository customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="repository">Represents <see cref="CustomerRepository"/>object.</param>
        public CustomerService(ICustomerRepository repository, ILogger<CustomerService> logger )
        {
            this.customerRepository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Get customer details.
        /// </summary>
        /// <param name="id">Represents customer id.</param>
        /// <returns>Returns <see cref="Customer"/> object.</returns>
        public Customer GetCustomer(int id)
        {
            try
            {
                return this.customerRepository.GetCustomer(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading customer details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get all customer details.
        /// </summary>
        /// <returns>Returns customer collections.</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return this.customerRepository.GetCustomers();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading customer details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Register customer details to DB.
        /// </summary>
        /// <param name="customer">Represents <see cref="Customer" object/>.</param>
        /// <returns>Returns <see cref="Customer"/>object.</returns>
        public Customer RegisterCustomer(Customer customer)
        {
            try
            {
                return this.customerRepository.SaveCustomer(customer);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving customer details : {ex.Message}");
                return null;
            }

        }
    }
}
