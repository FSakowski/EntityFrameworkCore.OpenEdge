using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.OpenEdge.Query.ExpressionTranslators.Internal
{
    public class OpenEdgeMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
    {
        private static readonly List<Type> _translatorsMethods
            = GetTranslatorMethods<IMethodCallTranslator>().ToList();

        public OpenEdgeMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
            : base(dependencies)
            => AddTranslators(_translatorsMethods.Select(type => (IMethodCallTranslator)Activator.CreateInstance(type)));

        public static IEnumerable<Type> GetTranslatorMethods<TInteface>()
            => Assembly
                .GetExecutingAssembly()
                .GetTypes().Where(t =>
                    t.GetInterfaces().Any(i => i == typeof(TInteface))
                    && t.GetConstructors().Any(c => c.GetParameters().Length == 0));
    }
}