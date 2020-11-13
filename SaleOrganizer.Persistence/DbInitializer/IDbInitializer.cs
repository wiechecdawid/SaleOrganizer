using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaleOrganizer.Persistence.DbInitializer
{
    public interface IDbInitializer
    {
        /// <summary>
        /// Creates new database if none has been created so far
        /// </summary>
        Task Initialize();
        /// <summary>
        /// Populates new database with dummy values
        /// </summary>
        Task Seed();
    }
}
