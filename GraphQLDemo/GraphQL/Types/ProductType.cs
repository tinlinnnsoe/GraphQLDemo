using GraphQLDemo.Data.Models;

namespace GraphQLDemo.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(x => x.Id).Type<NonNullType<IntType>>();
            descriptor.Field(x => x.Name).Type<NonNullType<StringType>>();
            descriptor.Field(x => x.Price).Type<NonNullType<FloatType>>();
        }
    }
}
