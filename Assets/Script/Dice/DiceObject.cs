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

    public string GetDiceName() { return diceName; }

    public void SetDiceName(string _name) { diceName = _name; }

    public DiceEffectObject GetDiceEffectObject(int _num)
    {
        if (_num < 0) return null;
        if (_num >= DICE_SIDED_COUNT) return null;
        return diceEffectList[_num];
    }

    string diceName = "";

    DiceEffectObject[] diceEffectList = new DiceEffectObject[DICE_SIDED_COUNT];
}
