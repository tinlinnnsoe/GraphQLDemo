using GraphQLDemo.GraphQL.Mutations;
using GraphQLDemo.GraphQL.Queries;
using GraphQLDemo.GraphQL.Subscriptions;
using GraphQLDemo.GraphQL.Types;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register GraphQL types, queries, mutations, and subscriptions
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<ProductType>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();

// Enable GraphQL Playground (use UseGraphQLPlayground in newer versions)
app.UsePlayground();

// Map the GraphQL endpoint
app.MapGraphQL();

app.Run();