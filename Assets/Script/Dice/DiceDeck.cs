using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDeck : MonoBehaviour
{
    public const int HAVE_MAX_DICE = 4;

    public void InitDeck()
    {
        if (IsDeckEmpty()) return;



    }

    public void SetDiceObject(int _no, DiceObject _obj)
    {
        if (_no >= HAVE_MAX_DICE) return;
        if (_no < 0) return;

        dices[_no] = _obj;
    }

    public void RemoveDiceObject(int _no)
    {
        if (_no >= HAVE_MAX_DICE) return;
        if (_no < 0) return;

        dices[_no] = null;
    }

    public DiceObject GetDiceObject(int _no)
    {
        if (_no >= HAVE_MAX_DICE) return null;
        if (_no < 0) return null;

        return dices[_no];
    }
    private bool IsDeckEmpty()
    {
        for(int i = 0;i < HAVE_MAX_DICE;i++)
        {
            if (dices[i] != null) return false;
        }

        return true;
    }

    DiceObject[] dices = new DiceObject[HAVE_MAX_DICE];
}
