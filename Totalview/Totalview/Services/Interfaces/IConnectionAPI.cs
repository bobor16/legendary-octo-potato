using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Totalview.Services.Interfaces
{
    interface IConnectionAPI
    {
        [Get("/")]
        Task<string> LoginUser([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    }
}
