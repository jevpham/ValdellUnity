using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable] // Allows us to edit from the Unity inspector
public class CharacterStat
{
    public float BaseValue;

    // avoids calling CalculateFinalValue unneccessarily
    public virtual float Value
    {
        get
        {
            if (callFinalValue || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                isValue = CalculateFinalValue();
                callFinalValue = false;
            }
            return isValue;
        }
    }

    protected bool callFinalValue = true;
    protected float isValue;
    protected float lastBaseValue = float.MinValue;
    protected readonly List<StatModifier> statModifiers; // pointer to a list

    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    // Default Constructor
    public CharacterStat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    // Overloaded Constructor
    public CharacterStat(float baseValue) : this()
    {
        BaseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier modify)
    {
        callFinalValue = true;
        statModifiers.Add(modify);
        statModifiers.Sort(CompareModifierOrder);
    }

    // Comparison function
    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0; // if (a.Order == b.Order)
    }

    public virtual bool RemoveModifier(StatModifier modify)
    {
        if (statModifiers.Remove(modify))
        {
            callFinalValue = true;
            return true;
        }

        return false;
    }

    public virtual bool RemoveAllModifiers(object source)
    {
        bool didRemove = false;

        // We traverse backwards for efficiency reasons
        // If you remove a modifier in the beginning of the list
        // You would have to shift all elements left
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                callFinalValue = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }

        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        // Details which stats are assigned in each particular order
        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;

                // If we're at the end of the list OR the next modifer isn't of this type
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd; // Multiply the sum with the "finalValue", like we do for "PercentMult" modifiers
                    sumPercentAdd = 0; // Reset the sum back to 0
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        // rounds to avoid float errors 
        return (float)System.Math.Round(finalValue, 3);
    }
}
