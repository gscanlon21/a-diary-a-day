
namespace Core.Attributes;

/// <summary>
/// Range atrribute with an ideal range.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class IdealRangeAttribute : Attribute
{
    public IdealRangeAttribute(int min, int max, RiskType riskType)
    {
        Min = min;
        Max = max;
        RiskType = riskType;
    }

    public int Min { get; }
    public int Max { get; }
    public RiskType RiskType { get; }

    public bool IsInRange(int? value) => value.HasValue && value >= Min && value < Max;
    public bool IsInRange(double? value) => value.HasValue && value >= Min && value < Max;
}

public enum RiskType
{
    LowRisk,
    ModerateRisk,
    HighRisk,
}