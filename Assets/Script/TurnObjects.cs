using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurnStartObject : GameManager.TurnObjectBase
{
    public override void Update()
    {
        ChangeTurn();
    }
}

[System.Serializable]
public class FutureAttackCheckObject : GameManager.TurnObjectBase
{
    public void AddFuruteAttackObject(FutureAttackObject _obj)
    {
        if (_obj == null) return;
        futureAttackObjectList.Add(_obj);
    }

    public override void Update()
    {

    }

    List<FutureAttackObject>futureAttackObjectList = new List<FutureAttackObject>();
}

[System.Serializable]
public class IceCheckObject : GameManager.TurnObjectBase
{
    public override void Init()
    {
        base.Init();

        var player = GetNowPlayer();
        isIce = player.IsIceTurn();

    }

    public override void Update()
    {
        if (!isIce)
        {
            ChangeTurn();
            return;
        }
    }

    bool isIce = false;
}

[System.Serializable]
public class StanCheckObject : GameManager.TurnObjectBase
{
    public override void Init()
    {
        base.Init();

        var player = GetNowPlayer();
        isStan = player.IsStan();

    }

    public override void Update()
    {
        if (!isStan)
        {
            ChangeTurn();
            return;
        }
    }

    bool isStan = false;
}

[System.Serializable]
public class GuardEndCheckObject : GameManager.TurnObjectBase
{
    public override void Update()
    {
        var player = GetNowPlayer();
        player.SetGuardFlg(false);
    }
}

[System.Serializable]
public class PandoraDiceCheckObject : GameManager.TurnObjectBase
{
    public override void Init()
    {
        base.Init();

        var player = GetNowPlayer();
        isPandora = player.IsPandoraDiceCount();
    }

    public override void Update()
    {
        if(!isPandora)
        {
            ChangeTurn();
            return;
        }
    }

    bool isPandora = false;
}

[System.Serializable]
public class SelectActionObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }

    int selectDice = 0;
    int selectCharacter = 0;
}

[System.Serializable]
public class DiceRollActionObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }

    [SerializeField]
    GameObject diceObject = null;

}

[System.Serializable]
public class DiceEffectObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceStartCheckObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceCharaSelectActionObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceRollActionObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}

[System.Serializable]
public class DoubleEndCheckObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}

[System.Serializable]
public class TurnEndObject : GameManager.TurnObjectBase
{
    public override void Update()
    {

    }
}