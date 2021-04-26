using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.OpenEdge.Query.ExpressionTranslators.Internal
{
    public class OpenEdgeMemberTranslatorProvider : RelationalMemberTranslatorProvider
    {
        private static readonly List<Type> _translatorsMethods
            = OpenEdgeMethodCallTranslatorProvider.GetTranslatorMethods<IMemberTranslator>().ToList();

        public OpenEdgeMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies)
            : base(dependencies)
            => AddTranslators(_translatorsMethods.Select(type => (IMemberTranslator)Activator.CreateInstance(type)));
    }
}