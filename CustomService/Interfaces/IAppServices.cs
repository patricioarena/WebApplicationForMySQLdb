using System;
using System.Collections;

namespace AppService.Interfaces
{
    public interface IAppServices
    {
        Queue ConfigToQueue(string str);
        //Queue GetRoles(Queue myQ);
    }
}