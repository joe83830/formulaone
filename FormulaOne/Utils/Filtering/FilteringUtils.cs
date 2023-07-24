using FormulaOne.Data.Models;
using LinqKit;
using System;

namespace FormulaOne.Utils.Filtering
{
    public static class FilteringUtils
    {
        public static IQueryable<Driver> ApplyTextFilters(this IQueryable<Driver> query, Filter<NationalityFilter> filter)
        {
            if (filter != null)
            {
                var joinOperator = filter.Operator;
                var predicate = joinOperator == OperatorType.Or ? PredicateBuilder.New<Driver>(false) : PredicateBuilder.New<Driver>(true);

                foreach (NationalityFilter condition in filter.Conditions)
                {
                    var filterText = condition.Filter.Trim().ToLower();

                    switch (condition.Type)
                    {
                        case ComparatorTypeString.Contains:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality.Contains(filterText)) : predicate.And(driver => driver.Nationality.Contains(filterText));
                            break;
                        case ComparatorTypeString.NotContains:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => !driver.Nationality.Contains(filterText)) : predicate.And(driver => !driver.Nationality.Contains(filterText));
                            break;
                        case ComparatorTypeString.Equals:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality == filterText) : predicate.And(driver => driver.Nationality == filterText);
                            break;
                        case ComparatorTypeString.NotEqual:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality != filterText) : predicate.And(driver => driver.Nationality != filterText);
                            break;
                        case ComparatorTypeString.StartsWith:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality.StartsWith(filterText)) : predicate.And(driver => driver.Nationality.StartsWith(filterText));
                            break;
                        case ComparatorTypeString.EndsWith:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality.EndsWith(filterText)) : predicate.And(driver => driver.Nationality.EndsWith(filterText));
                            break;
                        case ComparatorTypeString.Blank:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality == "") : predicate.And(driver => driver.Nationality == "");
                            break;
                        case ComparatorTypeString.NotBlank:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => driver.Nationality != "") : predicate.And(driver => driver.Nationality != "");
                            break;
                        default:
                            throw new Exception($"Unsupported comparator type: {condition.Type}");
                    }
                }
                query = query.AsExpandable().Where(predicate);
            }

            return query;
        }

        //public static IQueryable<Driver> ApplyDateFilters(this IQueryable<Driver> query, Filter<DobFilter> filter)
        //{
        //    if (filter != null)
        //    {
        //        foreach (var condition in filter.Conditions)
        //        {
        //            var joinOperator
        //        }
        //    }
        //}
    }
}
