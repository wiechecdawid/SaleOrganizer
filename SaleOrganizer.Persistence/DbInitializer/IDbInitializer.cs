using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SaleOrganizer.Domain;

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
        Task Seed(UserManager<AppUser> manager);
    }
}
