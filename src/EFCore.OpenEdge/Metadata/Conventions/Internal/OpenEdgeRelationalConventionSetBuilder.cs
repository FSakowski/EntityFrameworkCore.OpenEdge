using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace EntityFrameworkCore.OpenEdge.Metadata.Conventions.Internal
{
    public class OpenEdgeRelationalConventionSetBuilder : RelationalConventionSetBuilder
    {
        public OpenEdgeRelationalConventionSetBuilder(ProviderConventionSetBuilderDependencies providerDependencies,
            RelationalConventionSetBuilderDependencies dependencies) : base(providerDependencies, dependencies)
        {
        }
    }
}