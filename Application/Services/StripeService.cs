using Application.Services.Interfaces;
using Domain.Generic;
using Domain.Stripe;
using Stripe.Checkout;

namespace Application.Services
{
    public class StripeService : IStripeService
    {
        public async Task<GenericResponse<ResponseCreate>> Create()
        {
            var domain = "http://localhost:4000";
            var options = new SessionCreateOptions
            {
                UiMode = "embedded",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = "price_1Q0cWcRsXPDOTlRNlPYfDZG4",
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/return.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/return.html?session_id={CHECKOUT_SESSION_ID}",
                ReturnUrl = domain + "/return.html?session_id={CHECKOUT_SESSION_ID}",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new GenericResponse<ResponseCreate>(new ResponseCreate()
            {
                ClientSecret = session.ClientSecret
            });
        }

        public async Task<GenericResponse<ResponseStatus>> GetStatus(string sessionId)
        {
            var sessionService = new SessionService();
            Session session = sessionService.Get(sessionId);

            return new GenericResponse<ResponseStatus>(new ResponseStatus()
            {
                customer_email = session.CustomerDetails?.Email,
                status = session.Status
            });
        }
    }
}
