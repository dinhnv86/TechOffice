using System.Collections.Generic;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface IUsersRepository : IRepository<UserResult>
    {
        /// <summary>
        ///     Logins the specified userName.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserResult Login(string userName, string password);

        /// <summary>
        ///     Logins the asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<UserResult> LoginAsync(string userName, string password);

        /// <summary>
        ///     Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult Unlocked(int id);

        /// <summary>
        ///     Lockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult Locked(int id);

        /// <summary>
        ///     Unlockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> UnlockedAsync(int id);

        /// <summary>
        ///     Lockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> LockedAsync(int id);

        /// <summary>
        ///     Gets all unlocked.
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserResult> FindAllUnlocked();

        /// <summary>
        ///     Gets all unlocked asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserResult>> FindAllUnlockedAsync();

        /// <summary>
        ///     Gets all locked.
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserResult> FindAllLocked();

        /// <summary>
        ///     Gets all locked asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserResult>> FindAllLockedAsync();

        /// <summary>
        ///     Checks the exist userName.
        /// </summary>
        /// <param name="email">The userName.</param>
        /// <returns></returns>
        UserResult CheckUserName(string email);

        /// <summary>
        ///     Checks the exist userName asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        Task<UserResult> CheckUserNameAsync(string userName);

        /// <summary>
        ///     Resets the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        SaveResult ResetPassword(int id, string newPassword);

        /// <summary>
        ///     Resets the password asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        Task<SaveResult> ResetPasswordAsync(int id, string newPassword);
    }
}