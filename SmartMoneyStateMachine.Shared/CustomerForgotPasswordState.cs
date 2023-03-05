using Automatonymous;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Shared
{
    public class CustomerForgotPasswordState : SagaStateMachineInstance
    {
        [Key]
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string CPR { get; set; } //this needs to be unique
       
    }
}
