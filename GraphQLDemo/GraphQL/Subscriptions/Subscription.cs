using GraphQLDemo.Data.Models;

namespace GraphQLDemo.GraphQL.Subscriptions
{
    public partial class Subscription
    {
        [Subscribe]
        [Topic("ProductAdded")]
        public Product OnProductAdded([EventMessage] Product product) => product;
    }
}
