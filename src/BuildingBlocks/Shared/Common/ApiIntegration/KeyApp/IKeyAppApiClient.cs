using Shared.DTOs;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.ApiIntegration.KeyApp
{
    public interface IKeyAppApiClient
    {
        Task<ApiResult<IList<KeyConfigDto>>> GetServiceAsync(string value);
    }
}
