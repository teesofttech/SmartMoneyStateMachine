using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Contract.Events
{
    public interface UserSubmittedEvent
    {
        public Guid CorrelationId { get; set; }
        public string Email { get; set; }
        public string CPR { get; set; }
    }
}
