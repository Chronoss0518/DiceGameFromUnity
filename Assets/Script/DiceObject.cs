using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceObject
{
    public const int DICE_SIDED_COUNT = 6;

    private struct DiceValueObject
    {
        public DiceEffectBase diceEffect;
        public Texture2D diceValueImage;
    }

    public string GetDiceName() { return diceName; }

    public void SetDiceName(string _name) { diceName = _name; }

    public Texture2D GetDiceImage(int _no)
    {
        if (_no < 0) return null;
        if (_no >= DICE_SIDED_COUNT) return null;
        return diceEffectList[_no].diceValueImage;
    }

    public DiceEffectBase GetDiceEffectObject(int _num)
    {
        if (_num < 0) return null;
        if (_num >= DICE_SIDED_COUNT) return null;
        return diceEffectList[_num].diceEffect;
    }

    string diceName = "";

    DiceValueObject[] diceEffectList = new DiceValueObject[DICE_SIDED_COUNT];
}
