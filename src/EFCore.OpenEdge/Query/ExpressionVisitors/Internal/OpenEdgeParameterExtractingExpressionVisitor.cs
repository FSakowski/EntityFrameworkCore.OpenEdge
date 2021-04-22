﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EntityFrameworkCore.OpenEdge.Query.ExpressionVisitors.Internal
{
    /*public class OpenEdgeParameterExtractingExpressionVisitor : ParameterExtractingExpressionVisitor
    {
        public OpenEdgeParameterExtractingExpressionVisitor(IEvaluatableExpressionFilter evaluatableExpressionFilter,
            IParameterValues parameterValues,
            IDiagnosticsLogger<DbLoggerCategory.Query> logger,
            Type contextType,
            IModel model,
            bool parameterize, bool
                generateContextAccessors = false)
            : base(evaluatableExpressionFilter, parameterValues, contextType, model, logger, parameterize, generateContextAccessors)
        {
        }

        protected Expression VisitNewMember(MemberExpression memberExpression)
        {
            if (memberExpression.Expression is ConstantExpression constant
                && constant.Value != null)
            {
                switch (memberExpression.Member.MemberType)
                {
                    case MemberTypes.Field:
                        return Expression.Constant(constant.Value.GetType().GetField(memberExpression.Member.Name).GetValue(constant.Value));

                    case MemberTypes.Property:
                        var propertyInfo = constant.Value.GetType().GetProperty(memberExpression.Member.Name);
                        if (propertyInfo == null)
                        {
                            break;
                        }

                        return Expression.Constant(propertyInfo.GetValue(constant.Value));
                }
            }

            return base.VisitMember(memberExpression);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            var memberArguments = node.Arguments
                .Select(m => m is MemberExpression mem ? VisitNewMember(mem) : Visit(m))
                .ToList();

            var newNode = node.Update(memberArguments);

            return newNode;
        }

        protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.Name == "Take")
            {
                return methodCallExpression;
            }

            if (methodCallExpression.Method.Name == "Skip")
            {
                return methodCallExpression;
            }

            return base.VisitMethodCall(methodCallExpression);
        }
    }*/
}