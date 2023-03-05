using MassTransit;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class RejectedEventConsumer : IConsumer<RejectedEvent>
    {
        private readonly StateMachineContext _context;
        public RejectedEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<RejectedEvent> context)
        {
            //TODO:
        }
    }
}
