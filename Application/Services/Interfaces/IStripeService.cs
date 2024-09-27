using Domain.Generic;
using Domain.Stripe;

namespace Application.Services.Interfaces
{
    public interface IStripeService
    {
        Task<GenericResponse<ResponseCreate>> Create();
        Task<GenericResponse<ResponseStatus>> GetStatus(string sessionId);
    }
}
