using System;
using System.Threading.Tasks;
using LnuCampaign.Core.Interfaces.Services;

namespace LnuCampaign.Core.Services
{
    public abstract class BaseService : IBaseService
    {

        protected async Task<TResult> ExecuteAsync<TResult>(Func<TResult> executor)
        {
            return await Task.Run(() => executor());
        }

        protected async Task ExecuteAsync(Action executor)
        {
            await Task.Run(() => executor());
        }
    }
}
