﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Hl7.Fhir.Model;

namespace Microsoft.Health.Fhir.Core.Features.Search.Expressions
{
    /// <summary>
    /// Represents an expression.
    /// </summary>
    public abstract class Expression
    {
        /// <summary>
        /// Creates a <see cref="MultiaryExpression"/> that represents logical AND opeation over <paramref name="expressions"/>.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <returns>A <see cref="MultiaryExpression"/> that has <see cref="MultiaryOperator"/> of AND on all <paramref name="expressions"/>.</returns>
        public static MultiaryExpression And(params Expression[] expressions)
        {
            return new MultiaryExpression(MultiaryOperator.And, expressions);
        }

        /// <summary>
        /// Creates a <see cref="ChainedExpression"/> that represents chained operation.
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="paramName">The chained parameter name.</param>
        /// <param name="targetResourceType">The target resource type.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>A <see cref="ChainedExpression"/> that represents chained operation on <paramref name="targetResourceType"/> through <paramref name="paramName"/>.</returns>
        public static ChainedExpression Chained(ResourceType resourceType, string paramName, ResourceType targetResourceType, Expression expression)
        {
            return new ChainedExpression(resourceType, paramName, targetResourceType, expression);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents contains operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents contains operation.</returns>
        public static StringExpression Contains(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.Contains, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents ends with operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents ends with operation.</returns>
        public static StringExpression EndsWith(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.EndsWith, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="BinaryExpression"/> that represents an equality comparison.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="BinaryExpression"/> that represents an equality comparison.</returns>
        public static BinaryExpression Equals(FieldName fieldName, int? componentIndex, object value)
        {
            return new BinaryExpression(BinaryOperator.Equal, fieldName, componentIndex, value);
        }

        public static BinaryExpression GreaterThan(FieldName fieldName, int? componentIndex, object value)
        {
            return new BinaryExpression(BinaryOperator.GreaterThan, fieldName, componentIndex, value);
        }

        public static BinaryExpression GreaterThanOrEqual(FieldName fieldName, int? componentIndex, object value)
        {
            return new BinaryExpression(BinaryOperator.GreaterThanOrEqual, fieldName, componentIndex, value);
        }

        public static BinaryExpression LessThan(FieldName fieldName, int? componentIndex, object value)
        {
            return new BinaryExpression(BinaryOperator.LessThan, fieldName, componentIndex, value);
        }

        public static BinaryExpression LessThanOrEqual(FieldName fieldName, int? componentIndex, object value)
        {
            return new BinaryExpression(BinaryOperator.LessThanOrEqual, fieldName, componentIndex, value);
        }

        /// <summary>
        /// Creates a <see cref="MissingFieldExpression"/> that represents a missing field.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <returns>A <see cref="MissingFieldExpression"/> that represents a missing field.</returns>
        public static MissingFieldExpression Missing(FieldName fieldName, int? componentIndex)
        {
            return new MissingFieldExpression(fieldName, componentIndex);
        }

        /// <summary>
        /// Creates a <see cref="MissingParamExpression"/> that represents a missing parameter.
        /// </summary>
        /// <param name="paramName">The search parameter name.</param>
        /// <param name="isMissing">A flag indicating whether the parameter should be missing or not.</param>
        /// <returns>A <see cref="MissingParamExpression"/> that represents a missing parameter.</returns>
        public static MissingParamExpression Missing(string paramName, bool isMissing)
        {
            return new MissingParamExpression(paramName, isMissing);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents not contains operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents not contains operation.</returns>
        public static StringExpression NotContains(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.NotContains, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents not ends with operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents not ends with operation.</returns>
        public static StringExpression NotEndsWith(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.NotEndsWith, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents not starts with operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents not starts with operation.</returns>
        public static StringExpression NotStartsWith(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.NotStartsWith, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="MultiaryExpression"/> that represents logical OR opeation over <paramref name="expressions"/>.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <returns>A <see cref="MultiaryExpression"/> that has <see cref="MultiaryOperator"/> of OR on all <paramref name="expressions"/>.</returns>
        public static MultiaryExpression Or(params Expression[] expressions)
        {
            return new MultiaryExpression(MultiaryOperator.Or, expressions);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents starts with operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents starts with operation.</returns>
        public static StringExpression StartsWith(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.StartsWith, fieldName, componentIndex, value, ignoreCase);
        }

        /// <summary>
        /// Creates a <see cref="StringExpression"/> that represents string equals operation.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="componentIndex">The component index.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">A flag indicating whether it's case and accent sensitive or not.</param>
        /// <returns>A <see cref="StringExpression"/> that represents string equals operation.</returns>
        public static StringExpression StringEquals(FieldName fieldName, int? componentIndex, string value, bool ignoreCase)
        {
            return new StringExpression(StringOperator.Equals, fieldName, componentIndex, value, ignoreCase);
        }

        protected internal abstract void AcceptVisitor(IExpressionVisitor visitor);
    }
}