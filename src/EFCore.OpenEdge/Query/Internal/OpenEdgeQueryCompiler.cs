using System.Linq.Expressions;
using EntityFrameworkCore.OpenEdge.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace EntityFrameworkCore.OpenEdge.Query.Internal
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Ausstehend>")]
    public class OpenEdgeQueryCompiler : QueryCompiler
    {
        private readonly IEvaluatableExpressionFilter _evaluatableExpressionFilter;
        private readonly Type _contextType;
        private readonly IModel _model;

        public OpenEdgeQueryCompiler(IQueryContextFactory queryContextFactory,
            ICompiledQueryCache compiledQueryCache,
            ICompiledQueryCacheKeyGenerator compiledQueryCacheKeyGenerator,
            IDatabase database,
            IDiagnosticsLogger<DbLoggerCategory.Query> logger,
            ICurrentDbContext currentContext,
            IEvaluatableExpressionFilter evaluatableExpressionFilter,
            IModel model) : base(
                queryContextFactory,
                compiledQueryCache,
                compiledQueryCacheKeyGenerator,
                database,
                logger,
                currentContext,
                evaluatableExpressionFilter,
                model)
        {
            _evaluatableExpressionFilter = evaluatableExpressionFilter;
            _contextType = currentContext.Context.GetType();
            _model = model;
        }

        public override Expression ExtractParameters(Expression query, IParameterValues parameterValues, IDiagnosticsLogger<DbLoggerCategory.Query> logger, bool parameterize = true, bool generateContextAccessors = false)
        {
            var visitor = new OpenEdgeParameterExtractingExpressionVisitor(
                _evaluatableExpressionFilter,
                parameterValues,
                _contextType,
                _model,
                logger,
                parameterize,
                generateContextAccessors);

            return visitor.ExtractParameters(query);
        }
    }
}