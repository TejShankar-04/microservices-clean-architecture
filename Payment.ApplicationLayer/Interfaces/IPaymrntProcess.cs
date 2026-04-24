using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.ApplicationLayer.Interfaces
{
    public interface IPaymrntProcess
    {
        Task ExcuteAsync(string topic, string messag);
    }
}
