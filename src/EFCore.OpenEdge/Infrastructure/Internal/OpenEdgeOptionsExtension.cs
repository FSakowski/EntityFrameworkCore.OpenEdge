using EntityFrameworkCore.OpenEdge.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkCore.OpenEdge.Infrastructure.Internal
{
    public class OpenEdgeOptionsExtension : RelationalOptionsExtension
    {
        private DbContextOptionsExtensionInfo _info;

        public override DbContextOptionsExtensionInfo Info
            => _info = _info ?? new ExtensionInfo(this);


        protected override RelationalOptionsExtension Clone()
        {
            return new OpenEdgeOptionsExtension();
        }

        public override void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkOpenEdge();
        }

        private sealed class ExtensionInfo : RelationalExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
                
            }

            public override bool IsDatabaseProvider => true;

            public override void PopulateDebugInfo([NotNull] IDictionary<string, string> debugInfo)
            {
                
            }
        }
    }
}