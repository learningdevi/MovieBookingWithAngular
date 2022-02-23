/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This interface provides API to read and write customer data
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get all the customer details
        /// </summary>
        /// <returns>Returns customer object</returns>
        public IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Get customer details by id
        /// </summary>
        /// <param name="id">Represents customer id</param>
        /// <returns>Returns customer object</returns>
        public Customer GetCustomer(int id);

        /// <summary>
        /// Save customer details in DB
        /// </summary>
        /// <param name="customer">Represents <see cref="Customer"/> object</param>
        /// <returns>Returns customer object</returns>
        public Customer SaveCustomer(Customer customer);
    }
}
