using System.Threading.Tasks;

namespace Woof.WindowsEx {

    /// <summary>
    /// Class implementing this interface must have GetAsync method and IsLoaded property.
    /// </summary>
    public interface IGetAsync {

        /// <summary>
        /// Gets the value indicating the data for the view model has been loaded.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        /// Gets the data for the view model asynchronously.
        /// </summary>
        /// <returns>Task.</returns>
        Task GetAsync();

    }

}