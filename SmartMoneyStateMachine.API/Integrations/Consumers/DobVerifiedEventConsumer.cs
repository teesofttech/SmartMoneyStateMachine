using MassTransit;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class DobVerifiedEventConsumer : IConsumer<DobVerifiedEvent>
    {
        private readonly StateMachineContext _context;
        public DobVerifiedEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<DobVerifiedEvent> context)
        {
            //TODO:
        }
    }
}
