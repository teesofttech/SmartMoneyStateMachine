using MassTransit;
using Microsoft.EntityFrameworkCore;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Integrations.Consumers
{
    public class UserSubmittedEventConsumer : IConsumer<UserSubmittedEvent>
    {
        private readonly StateMachineContext _context;
        public UserSubmittedEventConsumer(StateMachineContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<UserSubmittedEvent> context)
        {
            //TODO:
        }
    }
}
