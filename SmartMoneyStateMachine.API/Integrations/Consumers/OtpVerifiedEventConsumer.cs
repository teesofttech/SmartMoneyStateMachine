using MassTransit;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class OtpVerifiedEventConsumer : IConsumer<OtpVerifiedEvent>
    {
        private readonly StateMachineContext _context;
        public OtpVerifiedEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<OtpVerifiedEvent> context)
        {
            //TODO:
        }
    }
}
