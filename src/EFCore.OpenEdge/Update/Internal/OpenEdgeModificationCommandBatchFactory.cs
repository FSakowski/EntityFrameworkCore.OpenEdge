using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Update;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkCore.OpenEdge.Update.Internal
{
    public class OpenEdgeModificationCommandBatchFactory : IModificationCommandBatchFactory
    {
        private readonly ModificationCommandBatchFactoryDependencies _dependencies;
        private readonly IDbContextOptions _options;

        public OpenEdgeModificationCommandBatchFactory([NotNull] ModificationCommandBatchFactoryDependencies dependencies, IDbContextOptions options)
        {
            _dependencies = dependencies;
            _options = options;
        }

        public virtual ModificationCommandBatch Create()
            => new OpenEdgeSingularModificationCommandBatch(_dependencies);
    }
}