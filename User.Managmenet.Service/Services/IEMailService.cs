using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Managmenet.Service.Models;

namespace User.Managmenet.Service.Services
{
    public interface IEMailService
    {
        void SendEmail(Message message);
    }
}
