using API.Extensions;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureBuilder();

var app = builder.Build();

app.ConfigureMiddlewares();

StripeConfiguration.ApiKey = "sk_test_51PxtfhRsXPDOTlRN4prIKYWVkhQBdS9tYlf8mWkVsAMY3lcdEBos83Uuf1RJrLeNACxhypSbfZGXcpSp24q91obG00Fwq5NHCT";

app.Run();