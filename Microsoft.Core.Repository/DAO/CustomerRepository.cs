/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This class provides capablities to read and write customer data
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> logger;
        private readonly IRepository<Customer> customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="repository">Represents <see cref="Customer"/>repository.</param>
        public CustomerRepository(IRepository<Customer> repository, ILogger<CustomerRepository> logger)
        {
            this.customerRepository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Get customer details by id.
        /// </summary>
        /// <param name="id">Represents customer id.</param>
        /// <returns>Returns customer object.</returns>
        public Customer GetCustomer(int id)
        {
            try
            {
                return customerRepository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading customer details from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get all the customer details
        /// </summary>
        /// <returns>Returns collection of customer</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return customerRepository.GetAll(null);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading customer details from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Save customer details in DB
        /// </summary>
        /// <param name="customer">Represents <see cref="Customer"/> object</param>
        /// <returns>Returns customer object</returns>
        public Customer SaveCustomer(Customer customer)
        {
            try
            {
                return customerRepository.Save(customer);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving customer details into DB : {ex.Message}");
                return null;
            }

        }
    }
}
