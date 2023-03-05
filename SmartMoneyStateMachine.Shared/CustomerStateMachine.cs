using Automatonymous;
using SmartMoneyStateMachine.Contract.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Shared
{
    public class CustomerStateMachine : MassTransitStateMachine<CustomerForgotPasswordState>
    {
        public CustomerStateMachine()
        {
            this.InstanceState(x => x.CurrentState);
            this.ConfigureCorrelationIds();

            Initially(
                When(UserSubmittedEvent)
                .Then(x => x.Instance.CPR = x.Data.CPR)
                .TransitionTo(Submitted));

            During(Submitted,
                When(OtpVerifiedEvent)
                .TransitionTo(OtpVerified));

            During(OtpVerified,
                When(DobVerifiedEvent)
                .TransitionTo(DobVerified));

            DuringAny(
                 When(RejectedEvent)
                .TransitionTo(Submitted)
                 .Finalize());

            During(DobVerified,
                When(WaitingLinkEvent)
                .TransitionTo(WaitingLinkReceived));

            During(WaitingLinkReceived,
                When(PasswordResetEvent)
                .TransitionTo(Completed)
                .Finalize());

            SetCompletedWhenFinalized();
        }

        private void ConfigureCorrelationIds()
        {
            Event(() => UserSubmittedEvent, x => x.CorrelateById(x => x.Message.CorrelationId).SelectId(x => x.Message.CorrelationId));
            Event(() => OtpVerifiedEvent, x => x.CorrelateById(x => x.Message.CorrelationId));
            Event(() => DobVerifiedEvent, x => x.CorrelateById(x => x.Message.CorrelationId));
            Event(() => WaitingLinkEvent, x => x.CorrelateById(x => x.Message.CorrelationId));
            Event(() => PasswordResetEvent, x => x.CorrelateById(x => x.Message.CorrelationId));
        }


        public State Submitted { get; private set; }
        public State OtpVerified { get; private set; }
        public State DobVerified { get; private set; }
        public State WaitingLinkReceived { get; private set; }
        public State Completed { get; private set; }
        public State Rejected { get; private set; }

        public Event<UserSubmittedEvent> UserSubmittedEvent { get; private set; }
        public Event<OtpVerifiedEvent> OtpVerifiedEvent { get; private set; }
        public Event<DobVerifiedEvent> DobVerifiedEvent { get; private set; }
        public Event<WaitingLinkEvent> WaitingLinkEvent { get; private set; }
        public Event<PasswordResetEvent> PasswordResetEvent { get; private set; }
        public Event<RejectedEvent> RejectedEvent { get; private set; }

    }
}
