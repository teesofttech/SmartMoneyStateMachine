using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMoneyStateMachine.API.Dtos;
using SmartMoneyStateMachine.Contract.Events;

namespace SmartMoneyStateMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public AccountController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("initiate-forgot-password")]
        public async Task Initiate(CustomerDto customer)
        {
            await _publishEndpoint.Publish<UserSubmittedEvent>(new
            {
                Email = customer.Email,
                CPR = "1234",
                CorrelationId = Guid.NewGuid().ToString()
            });
        }

        [HttpPatch]
        [Route("otp-verification")]
        public async Task VerifyOtp(Guid CorrelationId)
        {
            await _publishEndpoint.Publish<OtpVerifiedEvent>(new
            {
                CorrelationId = CorrelationId
            });
        }

        [HttpPatch]
        [Route("dob-verification")]
        public async Task DobVerification(Guid CorrelationId)
        {
            await _publishEndpoint.Publish<DobVerifiedEvent>(new
            {
                CorrelationId = CorrelationId
            });
        }

        [HttpPatch]
        [Route("reset-password-link")]
        public async Task ResetPasswordLink(Guid CorrelationId)
        {
            await _publishEndpoint.Publish<WaitingLinkEvent>(new
            {
                CorrelationId = CorrelationId
            });
        }

        [HttpPatch]
        [Route("reset-password-complete")]
        public async Task ResetPasswordComplete(Guid CorrelationId)
        {
            await _publishEndpoint.Publish<PasswordResetEvent>(new
            {
                CorrelationId = CorrelationId
            });
        }
    }
}
