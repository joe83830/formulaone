using FormulaOne.Data.Models;
using LinqKit;
using System.Linq.Expressions;

namespace FormulaOne.Utils.Filtering
{
    public static class FilteringUtils
    {
        private static Expression<Func<Driver, bool>> BuildContainsExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var parameterExp = fieldSelector.Parameters[0];
            var propertyExp = fieldSelector.Body;
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var filterTextExp = Expression.Constant(filterText);

            var containsExp = Expression.Call(propertyExp, containsMethod, filterTextExp);

            return Expression.Lambda<Func<Driver, bool>>(containsExp, parameterExp);
        }

        private static Expression<Func<Driver, bool>> BuildNotContainsExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var containsExp = BuildContainsExpression(fieldSelector, filterText);
            var notContainsExp = Expression.Not(containsExp.Body);
            return Expression.Lambda<Func<Driver, bool>>(notContainsExp, containsExp.Parameters.Single());
        }

        private static Expression<Func<Driver, bool>> BuildEqualsExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var propertyExp = fieldSelector.Body;
            var constantExp = Expression.Constant(filterText);
            return Expression.Lambda<Func<Driver, bool>>(Expression.Equal(propertyExp, constantExp), fieldSelector.Parameters);
        }

        private static Expression<Func<Driver, bool>> BuildNotEqualsExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var propertyExp = fieldSelector.Body;
            var constantExp = Expression.Constant(filterText);
            return Expression.Lambda<Func<Driver, bool>>(Expression.NotEqual(propertyExp, constantExp), fieldSelector.Parameters);
        }

        private static Expression<Func<Driver, bool>> BuildStartsWithExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var propertyExp = fieldSelector.Body;
            var constantExp = Expression.Constant(filterText);
            var startsWithExp = Expression.Call(propertyExp, startsWithMethod, constantExp);
            return Expression.Lambda<Func<Driver, bool>>(startsWithExp, fieldSelector.Parameters);
        }

        private static Expression<Func<Driver, bool>> BuildEndsWithExpression(Expression<Func<Driver, string>> fieldSelector, string filterText)
        {
            var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            var propertyExp = fieldSelector.Body;
            var constantExp = Expression.Constant(filterText);
            var endsWithExp = Expression.Call(propertyExp, endsWithMethod, constantExp);
            return Expression.Lambda<Func<Driver, bool>>(endsWithExp, fieldSelector.Parameters);
        }

        private static Expression<Func<Driver, bool>> BuildIsNullOrEmptyExpression(Expression<Func<Driver, string>> fieldSelector)
        {
            var isNullOrEmptyMethod = typeof(string).GetMethod("IsNullOrEmpty", new[] { typeof(string) });
            var propertyExp = fieldSelector.Body;
            var isNullOrEmptyExp = Expression.Call(isNullOrEmptyMethod, propertyExp);
            return Expression.Lambda<Func<Driver, bool>>(isNullOrEmptyExp, fieldSelector.Parameters);
        }

        private static Expression<Func<Driver, bool>> BuildIsNotNullOrEmptyExpression(Expression<Func<Driver, string>> fieldSelector)
        {
            var isNullOrEmptyExp = BuildIsNullOrEmptyExpression(fieldSelector).Body;
            var notExp = Expression.Not(isNullOrEmptyExp);
            return Expression.Lambda<Func<Driver, bool>>(notExp, fieldSelector.Parameters);
        }


        private static Expression<Func<Driver, bool>> ModifyPredicate(Expression<Func<Driver, bool>> predicate, OperatorType operatorType, Expression<Func<Driver, bool>> newCondition)
        {
            return operatorType == OperatorType.Or ? predicate.Or(newCondition) : predicate.And(newCondition);
        }

        public static IQueryable<Driver> ApplyTextFilters(this IQueryable<Driver> query, Filter<TextFilter> filter, Expression<Func<Driver, string>> fieldSelector)
        {
            if (filter != null)
            {
                var joinOperator = filter.Operator;
                var predicate = joinOperator == OperatorType.Or ? PredicateBuilder.New<Driver>(false) : PredicateBuilder.New<Driver>(true);

                foreach (var condition in filter.Conditions)
                {
                    var filterText = condition.Filter.Trim();
                    Console.WriteLine(filterText);
                    Console.WriteLine(condition.Type);
                    switch (condition.Type)
                    {
                        case ComparatorTypeString.Contains:
                            var containsPredicate = BuildContainsExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, containsPredicate);
                            break;
                        case ComparatorTypeString.NotContains:
                            var notContainsPredicate = BuildNotContainsExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, notContainsPredicate);
                            break;
                        case ComparatorTypeString.Equals:
                            var equalsPredicate = BuildEqualsExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, equalsPredicate);
                            break;
                        case ComparatorTypeString.NotEqual:
                            var notEqualsPredicate = BuildNotEqualsExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, notEqualsPredicate);
                            break;
                        case ComparatorTypeString.StartsWith:
                            var startsWithPredicate = BuildStartsWithExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, startsWithPredicate);
                            break;
                        case ComparatorTypeString.EndsWith:
                            var endsWithPredicate = BuildEndsWithExpression(fieldSelector, filterText);
                            predicate = ModifyPredicate(predicate, joinOperator, endsWithPredicate);
                            break;
                        case ComparatorTypeString.Blank:
                            var isNullOrEmptyPredicate = BuildIsNullOrEmptyExpression(fieldSelector);
                            predicate = ModifyPredicate(predicate, joinOperator, isNullOrEmptyPredicate);
                            break;
                        case ComparatorTypeString.NotBlank:
                            var isNotNullOrEmptyPredicate = BuildIsNotNullOrEmptyExpression(fieldSelector);
                            predicate = ModifyPredicate(predicate, joinOperator, isNotNullOrEmptyPredicate);
                            break;
                        default:
                            throw new Exception($"Unsupported comparator type: {condition.Type}");
                    }
                }
                query = query.AsExpandable().Where(predicate);
            }

            return query;
        }

        public static IQueryable<Driver> ApplyDateFilters(this IQueryable<Driver> query, Filter<DobFilter> filter)
        {
            if (filter != null)
            {
                var joinOperator = filter.Operator;
                var predicate = joinOperator == OperatorType.Or ? PredicateBuilder.New<Driver>(false) : PredicateBuilder.New<Driver>(true);
                foreach (var condition in filter.Conditions)
                {
                    var dateFromUTC = condition.DateFrom.ToUniversalTime();
                    var dateToUTC = condition.DateTo?.ToUniversalTime();
                    switch (condition.Type)
                    {
                        case ComparatorTypeDate.GreaterThan:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Dob > dateFromUTC) : predicate.And(driver => driver.Dob > dateFromUTC);
                            break;
                        case ComparatorTypeDate.LessThan:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Dob < dateFromUTC) : predicate.And(driver => driver.Dob < dateFromUTC);
                            break;
                        case ComparatorTypeDate.Equals:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Dob == dateFromUTC) : predicate.And(driver => driver.Dob == dateFromUTC);
                            break;
                        case ComparatorTypeDate.NotEqual:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Dob != dateFromUTC) : predicate.And(driver => driver.Dob != dateFromUTC);
                            break;
                        case ComparatorTypeDate.Blank:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => false) : predicate.And(driver => false);
                            break;
                        case ComparatorTypeDate.NotBlank:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => true) : predicate.And(driver => true);
                            break;
                        case ComparatorTypeDate.InRange:
                            if (dateToUTC != null)
                            {
                                predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Dob >= dateFromUTC && driver.Dob <= dateToUTC) : predicate.And(driver => driver.Dob >= dateFromUTC && driver.Dob <= dateToUTC);
                            }
                            break;
                        default:
                            throw new Exception($"Unsupported comparator type: {condition.Type}");
                    }
                }
                query = query.AsExpandable().Where(predicate);
            }
            return query;
        }
    }
}
