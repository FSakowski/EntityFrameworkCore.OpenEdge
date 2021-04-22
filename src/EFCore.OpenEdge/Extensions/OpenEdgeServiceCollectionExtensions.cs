using EntityFrameworkCore.OpenEdge.Diagnostics.Internal;
using EntityFrameworkCore.OpenEdge.Infrastructure.Internal;
using EntityFrameworkCore.OpenEdge.Metadata.Conventions.Internal;
using EntityFrameworkCore.OpenEdge.Query.ExpressionTranslators.Internal;
using EntityFrameworkCore.OpenEdge.Query.Sql.Internal;
using EntityFrameworkCore.OpenEdge.Storage;
using EntityFrameworkCore.OpenEdge.Storage.Internal;
using EntityFrameworkCore.OpenEdge.Storage.Internal.Mapping;
using EntityFrameworkCore.OpenEdge.Update;
using EntityFrameworkCore.OpenEdge.Update.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.OpenEdge.Extensions
{
    public static class OpenEdgeServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkOpenEdge(this IServiceCollection serviceCollection)
        {
            var builder = new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAdd<LoggingDefinitions, OpenEdgeLoggingDefinitions>()
                .TryAdd<IDatabaseProvider, DatabaseProvider<OpenEdgeOptionsExtension>>()
                .TryAdd<IRelationalTypeMappingSource, OpenEdgeTypeMappingSource>()
                .TryAdd<ISqlGenerationHelper, OpenEdgeSqlGenerationHelper>()
                .TryAdd<IProviderConventionSetBuilder, OpenEdgeRelationalConventionSetBuilder>()
                .TryAdd<IUpdateSqlGenerator, OpenEdgeUpdateSqlGenerator>()
                .TryAdd<IUpdateSqlGenerator, OpenEdgeUpdateSqlGenerator>()
                .TryAdd<IModificationCommandBatchFactory, OpenEdgeModificationCommandBatchFactory>()
                .TryAdd<IRelationalConnection>(p => p.GetService<IOpenEdgeRelationalConnection>())
                // .TryAdd<IQueryModelGenerator, OpenEdgeQueryModelGenerator>()

                // .TryAdd<IBatchExecutor, BatchExecutor>()

                .TryAdd<IMemberTranslatorProvider, OpenEdgeMemberTranslatorProvider>()
                .TryAdd<IMethodCallTranslatorProvider, OpenEdgeMethodCallTranslatorProvider>()
                .TryAdd<IQuerySqlGeneratorFactory, OpenEdgeSqlGeneratorFactory>()
                
                .TryAddProviderSpecificServices(b => b
                    .TryAddScoped<IOpenEdgeUpdateSqlGenerator, OpenEdgeUpdateSqlGenerator>()
                    .TryAddScoped<IOpenEdgeRelationalConnection, OpenEdgeRelationalConnection>()); ;

            builder.TryAddCoreServices();
            return serviceCollection;
        }

    }
}