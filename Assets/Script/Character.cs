using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public const int HP_MAX = 30;
    public const int PANDORA_DICE_COUNT = 6;

    public enum CharacterEffect : int
    {
        Ice,
        Stan,
        Guard,
        Double,
        None,
    }

    public bool IsLose() { return hp < 0; }

    public void SetEffect(CharacterEffect _effect)
    {
        effectFlg.SetBitTrue((int)_effect);
    }

    public bool IsEffect(CharacterEffect _effect)
    {
        return effectFlg.GetBitFlg((int)_effect);
    }

    public DiceObject GetDiceObject(int _no)
    {
        return useDeck.GetDiceObject(_no);
    }

    public bool IsPandoraDiceCount() { return pandoraDiceCount < 0; }

    public void SubPandoraDiceCount() { pandoraDiceCount--; }

    public void SetInitPandoraDiceCount(){ pandoraDiceCount = PANDORA_DICE_COUNT; }

    public void ChangeHP(Character _target)
    {
        if (_target == null) return;

        _target.hp += hp;
        hp = _target.hp - hp;
        _target.hp = _target.hp - hp;
    }

    public void SetHP(int _val)
    {
        hp = _val;
    }

    public void Damage(int _damage)
    {
        hp -= _damage;
    }

    public void Heal(int _heal)
    {
        hp += _heal;
    }
    
    ChStd.BitBool effectFlg = new ChStd.BitBool((int)(CharacterEffect.None) / 8 + 1);
    int hp = HP_MAX;
    int pandoraDiceCount = PANDORA_DICE_COUNT;

    DiceDeck useDeck = null;
}
