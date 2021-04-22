using EntityFrameworkCore.OpenEdge.Diagnostics.Internal;
using EntityFrameworkCore.OpenEdge.Scaffolding.Internal;
using EntityFrameworkCore.OpenEdge.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.OpenEdge.Design.Internal
{
    public class OpenEdgeDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<LoggingDefinitions, OpenEdgeLoggingDefinitions>()
                .AddSingleton<IRelationalTypeMappingSource, OpenEdgeTypeMappingSource>()
                .AddSingleton<IDatabaseModelFactory, OpenEdgeDatabaseModelFactory>()
                .AddSingleton<IProviderConfigurationCodeGenerator, OpenEdgeCodeGenerator>()
                .AddSingleton<IAnnotationCodeGenerator, OpenEdgeAnnotationCodeGenerator>()
        ;
    }
}