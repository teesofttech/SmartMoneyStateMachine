using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Contract.Events
{
    public interface DobVerifiedEvent
    {
        Guid CorrelationId { get; }
    }
}
