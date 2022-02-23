/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This interface provides API to handle customer services.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Register customer details to DB.
        /// </summary>
        /// <param name="customer">Represents <see cref="Customer" object/>.</param>
        /// <returns>Returns <see cref="Customer"/>object.</returns>
        public Customer RegisterCustomer(Customer customer);

        /// <summary>
        /// Get customer details.
        /// </summary>
        /// <param name="id">Represents customer id.</param>
        /// <returns>Returns <see cref="Customer"/> object.</returns>
        public Customer GetCustomer(int id);

        /// <summary>
        /// Get all customer details.
        /// </summary>
        /// <returns>Returns customer collections.</returns>
        public IEnumerable<Customer> GetCustomers();
    }
}
