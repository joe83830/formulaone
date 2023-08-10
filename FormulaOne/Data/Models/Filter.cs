using System.Runtime.Serialization;

namespace FormulaOne.Data.Models
{
    public enum FilterType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "date")]
        Date
    }


    public enum ComparatorTypeString
    {
        [EnumMember(Value = "contains")]
        Contains,
        [EnumMember(Value = "notContains")]
        NotContains,
        [EnumMember(Value = "greaterThan")]
        GreaterThan,
        [EnumMember(Value = "equals")]
        Equals,
        [EnumMember(Value = "notEqual")]
        NotEqual,
        [EnumMember(Value = "startsWith")]
        StartsWith,
        [EnumMember(Value = "endsWith")]
        EndsWith,
        [EnumMember(Value = "blank")]
        Blank,
        [EnumMember(Value = "notBlank")]
        NotBlank
    }

    public enum ComparatorTypeNumber
    {
        [EnumMember(Value = "greaterThan")]
        GreaterThan,
        [EnumMember(Value = "greaterThanOrEqual")]
        GreaterThanOrEqual,
        [EnumMember(Value = "lessThan")]
        LessThan,
        [EnumMember(Value = "lessThanOrEqual")]
        LessThanOrEqual,
        [EnumMember(Value = "equals")]
        Equals,
        [EnumMember(Value = "notEqual")]
        NotEqual,
        [EnumMember(Value = "inRange")]
        InRange,
        [EnumMember(Value = "blank")]
        Blank,
        [EnumMember(Value = "notBlank")]
        NotBlank
    }

    public enum ComparatorTypeDate
    {
        [EnumMember(Value = "greaterThan")]
        GreaterThan,
        [EnumMember(Value = "lessThan")]
        LessThan,
        [EnumMember(Value = "equals")]
        Equals,
        [EnumMember(Value = "notEqual")]
        NotEqual,
        [EnumMember(Value = "inRange")]
        InRange,
        [EnumMember(Value = "blank")]
        Blank,
        [EnumMember(Value = "notBlank")]
        NotBlank
    }

    public enum OperatorType
    {
        [EnumMember(Value = "AND")]
        And,
        [EnumMember(Value = "OR")]
        Or,
        [EnumMember(Value = "NONE")]
        None
    }


    //public interface ITextFilter
    //{
    //    FilterType FilterType { get; }
    //    ComparatorTypeString Type { get; }
    //    string Filter { get; }
    //}

    public class DobFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public FilterType FilterType { get; set; }
        public ComparatorTypeDate Type { get; set; }
    }

    public class TextFilter
    {
        public FilterType FilterType { get; set; }
        public ComparatorTypeString Type { get; set; }
        public string Filter { get; set; }
    }

    public class Filter<T>
    {
        public FilterType FilterType { get; set; }
        public OperatorType Operator { get; set; }
        public List<T> Conditions { get; set; }
    }

    public class ConsolidatedFilter
    {
        public Filter<TextFilter>? Nationality { get; set; }
        public Filter<DobFilter>? Dob { get; set; }
    }
}
