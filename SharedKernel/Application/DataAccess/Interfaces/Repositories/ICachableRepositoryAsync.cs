using System;
using System.Threading.Tasks;

namespace PostApplication.DataAccess.Contracts.BaseRepositories
{
    public interface ICachableRepositoryAsync
    {
        Task ResetCache();
    }
}
