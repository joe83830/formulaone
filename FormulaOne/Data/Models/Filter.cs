namespace FormulaOne.Data.Models
{
    public static class FilterType
    {
        public static readonly string Text = "text";
        public static readonly string Number = "number";
        public static readonly string Date = "date";
    }

    public static class ComparatorTypeString
    {
        public static readonly string Contains = "contains";
        public static readonly string NotContains = "notContains";
        public static readonly string GreaterThan = "greaterThan";
        public static readonly string Equal = "equals";
        public static readonly string NotEqual = "notEqual";
        public static readonly string StartsWith = "startsWith";
        public static readonly string EndsWith = "endsWith";
        public static readonly string Blank = "blank";
        public static readonly string NotBlank = "notBlank";
    }

    public static class ComparatorTypeNumber
    {
        public static readonly string GreaterThan = "greaterThan";
        public static readonly string GreaterThanOrEqual = "greaterThanOrEqual";
        public static readonly string LessThan = "lessThan";
        public static readonly string LessThanOrEqual = "lessThanOrEqual";
        public static readonly string Equal = "equals";
        public static readonly string NotEqual = "notEqual";
        public static readonly string InRange = "inRange";
        public static readonly string Blank = "blank";
        public static readonly string NotBlank = "notBlank";
    }

    public static class ComparatorTypeDate
    {
        public static readonly string GreaterThan = "greaterThan";
        public static readonly string LessThan = "lessThan";
        public static readonly string Equal = "equals";
        public static readonly string NotEqual = "notEqual";
        public static readonly string InRange = "inRange";
        public static readonly string Blank = "blank";
        public static readonly string NotBlank = "notBlank";
    }

    public static class OperatorType
    {
        public static readonly string And = "AND";
        public static readonly string Or = "OR";
        public static readonly string NONE = "NONE";
    }


    public class DobFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string FilterType { get; set; }
        public string Type { get; set; }
    }

    public class NationalityFilter
    {
        public string FilterType { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
    }

    public class FilterCondition
    {
        public string FilterType { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
    }

    public class Filter
    {
        public string FilterType { get; set; }
        public string Operator { get; set; }
        public List<FilterCondition> Conditions { get; set; }
    }
}
