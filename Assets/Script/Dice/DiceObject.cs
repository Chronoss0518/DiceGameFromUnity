using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject
{
    public const int DICE_SIDED_COUNT = 6;

    abstract public class DiceEffectObject
    {
        abstract public void Update(Character _user,Character _target);
    }

    public DiceEffectObject RunDiceRoll()
    {
        return diceEffectList[Random.Range(0, DICE_SIDED_COUNT)];
    }


    DiceEffectObject[] diceEffectList = new DiceEffectObject[DICE_SIDED_COUNT];
}
