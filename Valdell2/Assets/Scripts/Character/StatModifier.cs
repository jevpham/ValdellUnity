public enum StatModType
{
    // Allows flexibility when altering modifiers
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}

public class StatModifier
{
    // readonly makes member variables constant, but can be calculated at runtime
    // we are making immutable data structures to prevent modification after initiliazation
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source; // can hold any type

    // Constructors
    public StatModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    // Allows flat modifiers to apply before percent 
    public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }

    // Value and type are required while source and order are optional
    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    // Shows where each modifier comes from when added to stats
    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}
