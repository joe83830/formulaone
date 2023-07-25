using FormulaOne.Data.Models;
using LinqKit;

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
                    var filterText = condition.Filter.Trim();
                    Console.WriteLine(filterText);
                    Console.WriteLine(condition.Type);
                    switch (condition.Type)
                    {
                        case ComparatorTypeString.Contains:
                            Console.WriteLine("HIT CONDITION");
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
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => string.IsNullOrEmpty(driver.Nationality)) : predicate.And(driver => string.IsNullOrEmpty(driver.Nationality));
                            break;
                        case ComparatorTypeString.NotBlank:
                            predicate = joinOperator == OperatorType.Or ? predicate.Or(driver => string.IsNullOrEmpty(driver.Nationality)) : predicate.And(driver => string.IsNullOrEmpty(driver.Nationality));
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
