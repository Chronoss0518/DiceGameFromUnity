using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public const int HP_MAX = 30;
    public const int PANDORA_DICE_COUNT = 6;

    public void SetSampleDeck(DiceDeck _deck)
    {
        if (_deck == null) return;
        useDeck = _deck;
    }

    public bool IsLose() { return hp < 0; }

    public void SetIceTurnCount(int _count) { iceTurnCount = _count; }

    public int GetIceTurnCount() { return iceTurnCount; }

    public bool IsIceTurn()
    {
        bool res = iceTurnCount > 0;
        if (res) iceTurnCount--;
        return res;
    }

    public void SetStanFlg() { stanFlg = true; }

    public bool IsStan()
    {
        bool res = stanFlg;
        stanFlg = false;
        return res;
    }

    public void SetGuardFlg(bool _flg) { guardFlg = _flg; }

    public bool IsGuardFlg() { return guardFlg; }

    public void SetDoubleFlg(bool _flg) { doubleFlg = _flg; }

    public bool IsDoubleFlg() { return doubleFlg; }

    public DiceObject GetDiceObject(int _no)
    {
        return useDeck.GetDiceObject(_no);
    }

    public bool IsPandoraDiceCount() { return pandoraDiceCount <= 0; }

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

    public void SetUserName(string _name)
    {
        userName = _name;
    }

    public string GetUserName()
    {
        return userName;
    }

    [SerializeField,ChUnity.ReadOnly]
    string userName = "";

    [SerializeField, ChUnity.ReadOnly]
    int iceTurnCount = 0;

    [SerializeField, ChUnity.ReadOnly]
    bool stanFlg = false;

    [SerializeField, ChUnity.ReadOnly]
    bool guardFlg = false;

    [SerializeField, ChUnity.ReadOnly]
    bool doubleFlg = false;

    [SerializeField, ChUnity.ReadOnly]
    int hp = HP_MAX;

    [SerializeField, ChUnity.ReadOnly]
    int pandoraDiceCount = PANDORA_DICE_COUNT;

    [SerializeField]
    DiceDeck useDeck = null;
}
