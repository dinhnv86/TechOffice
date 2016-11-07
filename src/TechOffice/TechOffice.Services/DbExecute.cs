using System;
using System.Threading.Tasks;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.Services
{
    public class DbExecute
    {
        protected TResult ExecuteDbWithHandle<TResult>(ILogService logService, Func<TResult> func)
        {
            TResult result = default(TResult);
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

        protected async Task<TResult> ExecuteDbWithHandleAsync<TResult>(Func<Task<TResult>> func, ILogService logService)
        {
            TResult result = default(TResult);
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
