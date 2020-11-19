using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Totalview.Services.Interfaces
{
    public interface IAuth
    {
        Task<string> LoginWithEmailAndPassword(string username, string password);
    }
}
