using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Contract.Settings
{
    public static class RabbitMQSettings
    {
        public const string StateMachine = "state-machine-queue";
        public const string TncEventQueue = "user-tnc-queue";
    }
}
