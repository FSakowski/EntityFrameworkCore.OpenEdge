using EntityFrameworkCore.OpenEdge.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkCore.OpenEdge.Infrastructure
{
    public class OpenEdgeDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<OpenEdgeDbContextOptionsBuilder, OpenEdgeOptionsExtension>
    {
        public OpenEdgeDbContextOptionsBuilder([NotNull] DbContextOptionsBuilder optionsBuilder)
            : base(optionsBuilder)
        {
        }
    }
}
