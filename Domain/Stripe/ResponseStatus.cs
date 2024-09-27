using Newtonsoft.Json.Linq;

namespace Domain.Stripe
{
    public class ResponseStatus
    {
        public JToken customer_email { get; set; }
        public JToken status { get; set; }

    }
}
