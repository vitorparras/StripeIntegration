﻿using Application.Services.Interfaces;
using Domain.Generic;
using Domain.Stripe;
using Stripe.Checkout;

namespace Application.Services
{
    public class StripeService : IStripeService
    {
        public async Task<GenericResponse<ResponseCreate>> Create()
        {
            var domain = "http://localhost:4200";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    Price = "price_1Q0cWcRsXPDOTlRNlPYfDZG4",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/sys/stripe/success?TESTE={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/sys/stripe/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new GenericResponse<ResponseCreate>(new ResponseCreate()
            {
                Url = session.Url
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
