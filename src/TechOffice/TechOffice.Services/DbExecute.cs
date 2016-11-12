using System;
using System.Threading.Tasks;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.Services
{
    public class DbExecute
    {
        /// <summary>
        ///     The _log service
        /// </summary>
        protected readonly ILogService _logService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChuVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public DbExecute(ILogService logService)
        {
            _logService = logService;
        }

        protected TResult ExecuteDbWithHandle<TResult>(ILogService logService, Func<TResult> func)
        {
            var result = default(TResult);
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                logService.Error(ex.Message, ex);
            }

            return result;
        }

        protected async Task<TResult> ExecuteDbWithHandleAsync<TResult>(ILogService logService, Func<Task<TResult>> func)
        {
            var result = default(TResult);
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                logService.Error(ex.Message, ex);
            }

            return result;
        }
    }
}