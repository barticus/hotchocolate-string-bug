using Sample.GraphQL;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sample
{
    public class Startup
    {

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQL(services => SchemaBuilder.New()
                    .AddServices(services)
                    .AddQueryType<Query>()
                    .AddType<CommentType>()
                    .Create()
                )
                .AddMvc();
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseRouting()
                .UseGraphQL(new QueryMiddlewareOptions()
                {
                    Path = "/graphql",
                })
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
