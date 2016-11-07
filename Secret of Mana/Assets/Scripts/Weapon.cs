using UnityEngine;
using System.Collections;

public abstract class Weapon : Item
{
    // Default attack bonus
    public int AttackBonus = 50;

    public virtual void Behaviour()
    {
        // empty implementation
    }

    public virtual void Behaviour(VisualCharacter character)
    {
        // empty implementation
    }
}
