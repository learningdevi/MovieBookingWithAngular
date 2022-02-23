/*
 * Copyright - Microsoft
 */

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This interface defines capabilities to access DB.
    /// </summary>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Get the data from DB.
        /// </summary>
        /// <param name="includes">Represents include list.</param>
        /// <returns>Returns list of object.</returns>
        public IEnumerable<T> GetAll(string[] includes);

        /// <summary>
        /// Get the data by Id
        /// </summary>
        /// <param name="id">Represents Id</param>
        /// <returns>Returns list of object</returns>
        public T Get(int id);

        /// <summary>
        /// Save the data into DB
        /// </summary>
        /// <param name="entity">Represents entity</param>
        /// <returns>Returns entity which is saved to DB</returns>
        public T Save(T entity);
    }
}
