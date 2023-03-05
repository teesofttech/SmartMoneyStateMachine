using MassTransit;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class PasswordResetEventConsumer : IConsumer<PasswordResetEvent>
    {
        private readonly StateMachineContext _context;
        public PasswordResetEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<PasswordResetEvent> context)
        {
            //TODO:
        }
    }
}
