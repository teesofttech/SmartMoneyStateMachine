using MassTransit;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class WaitingLinkEventConsumer : IConsumer<WaitingLinkEvent>
    {
        private readonly StateMachineContext _context;
        public WaitingLinkEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<WaitingLinkEvent> context)
        {
            //TODO:
        }
    }
}
