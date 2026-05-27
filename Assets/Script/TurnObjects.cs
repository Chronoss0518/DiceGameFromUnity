using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurnStartObject : GameManager.TurnObjectBase
{
    const string INIT_GAME_TEXT = "GAME START!!";
    const string TURN_CHANGE_TEXT = "TURN CHANGE!";

    public TurnStartObject()
    {
        thisType = GameManager.TurnType.TurnStart;
    }

    public override void Init()
    {
        base.Init();
        gameManager.SetMessageBoxVisible(false);
        gameManager.SetSlideText(initFlg ? TURN_CHANGE_TEXT : INIT_GAME_TEXT);
    }

    public override void Update()
    {
        if (!gameManager.IsSlideTextStop()) return;

        gameManager.ChangeTurn();
        initFlg = true;
        
    }

    [SerializeField]
    bool initFlg = false;
}

[System.Serializable]
public class FutureAttackCheckObject : GameManager.TurnObjectBase
{
    public FutureAttackCheckObject()
    {
        thisType = GameManager.TurnType.FutureAttackCheck;
    }

    public void AddFutureAttackObject(FutureAttackObject _obj)
    {
        if (_obj == null) return;
        futureAttackObjectList.Add(_obj);
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        if(futureAttackObjectList.Count <= 0)
        {
            gameManager.ChangeTurn();
            return;
        }
    }

    List<FutureAttackObject>futureAttackObjectList = new List<FutureAttackObject>();
}

[System.Serializable]
public class IceCheckObject : GameManager.TurnObjectBase
{
    public IceCheckObject()
    {
        thisType = GameManager.TurnType.IceCheck;
    }

    public override void Init()
    {
        base.Init();

        var player = gameManager.GetNowCharacter();
        if(player == null)
        {
            isIce = false;
            return;
        }
        isIce = player.IsIceTurn();

    }

    public override void Update()
    {
        if (!isIce)
        {
            gameManager.ChangeTurn();
            return;
        }
    }

    bool isIce = false;
}

[System.Serializable]
public class StanCheckObject : GameManager.TurnObjectBase
{
    public StanCheckObject()
    {
        thisType = GameManager.TurnType.StanCheck;
    }

    public override void Init()
    {
        base.Init();

        var player = gameManager.GetNowCharacter();
        if (player == null)
        {
            isStan = false;
            return;
        }
        isStan = player.IsStan();

    }

    public override void Update()
    {
        if (!isStan)
        {
            gameManager.ChangeTurn();
            return;
        }
    }

    bool isStan = false;
}

[System.Serializable]
public class GuardEndCheckObject : GameManager.TurnObjectBase
{
    public GuardEndCheckObject()
    {
        thisType = GameManager.TurnType.GuardEndCheck;
    }

    public override void Update()
    {
        var player = gameManager.GetNowCharacter();
        if (player == null)
        {
            gameManager.ChangeTurn();
            return;
        }
        player.SetGuardFlg(false);
        gameManager.ChangeTurn();
    }
}

[System.Serializable]
public class PandoraDiceCheckObject : GameManager.TurnObjectBase
{
    public PandoraDiceCheckObject()
    {
        thisType = GameManager.TurnType.PandoraDiceCheck;
    }

    public override void Init()
    {
        base.Init();

        var player = gameManager.GetNowCharacter();
        if (player == null)
        {
            isPandora = false;
            return;
        }
        isPandora = player.IsPandoraDiceCount();
    }

    public override void Update()
    {
        if(!isPandora)
        {
            gameManager.ChangeTurn();
            return;
        }
    }

    bool isPandora = false;
}

[System.Serializable]
public class SelectActionObject : GameManager.TurnObjectBase
{
    public SelectActionObject()
    {
        thisType = GameManager.TurnType.SelectAction;
    }

    public void SetSelectDice(int _no)
    {
        if (_no < 0) return;
        selectDice = _no;
    }

    public void SetSelectCharacter(int _no)
    {
        if (_no < 0) return;
        selectCharacter = _no;
    }

    public int GetSelectDiceNo()
    {
        return selectDice;
    }

    public int GetSelectCharacterNo()
    {
        return selectCharacter;
    }

    public override void Init()
    {
        base.Init();
        selectCharacter = gameManager.GetNowCharacterNo();
        selectDice = 0;
    }

    public override void Update()
    {

    }

    int selectDice = 0;
    int selectCharacter = 0;
}

[System.Serializable]
public class DiceRollActionObject : GameManager.TurnObjectBase
{
    public DiceRollActionObject()
    {
        thisType = GameManager.TurnType.DiceRollAction;
    }

    const string DICE_ROLL_MESSAGE = "ダイスロール!!\n";
    const string DICE_RESULT_MESSAGE = "ダイスの結果は";

    public int diceRollResult { get; private set; } = 0;

    public override void Init()
    {
        base.Init();
        gameManager.SetMessageBoxVisible(true);
        gameManager.SetMessage(DICE_ROLL_MESSAGE);
        nowEndFrame = 0;
        resultString = "";
        var prefab = gameManager.GetDiceRollPrefab();

        var obj = Object.Instantiate(prefab.gameObject);

        diceRollObject =  obj.GetComponent<DiceRoll>();

        diceRollResult = gameManager.CreateDiceRollResult();

        var character = gameManager.GetNowCharacter();

        if (character == null) return;

        var dice = character.GetDiceObject(gameManager.GetSelectDice());

        dice.GetDiceImage(diceRollResult);


    }

    public override void Update()
    {
        if(diceRollObject == null)
        {
            gameManager.ChangeTurn();
            return;
        }

        if (!diceRollObject.IsDiceAnimationEndFlg) return;

        if(resultString == "")
        {
            resultString = DICE_ROLL_MESSAGE + DICE_RESULT_MESSAGE + "[" + (diceRollResult + 1).ToString() + "]";
            gameManager.SetMessage(resultString);
        }

        nowEndFrame++;

        if (gameManager.GetAnimationEndFrame() > nowEndFrame) return;

        gameManager.ChangeTurn();

        Object.Destroy(diceRollObject.gameObject);
        diceRollObject = null;
    }

    [SerializeField]
    DiceRoll diceRollObject = null;

    [SerializeField, ChUnity.ReadOnly]
    string resultString = "";

    [SerializeField, ChUnity.ReadOnly]
    int nowEndFrame = 0;

}

[System.Serializable]
public class DiceEffectObject : GameManager.TurnObjectBase
{
    public DiceEffectObject()
    {
        thisType = GameManager.TurnType.DiceEffect;
    }

    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceStartCheckObject : GameManager.TurnObjectBase
{
    public PandoraDiceStartCheckObject()
    {
        thisType = GameManager.TurnType.PandoraDiceStartCheck;
    }

    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceCharaSelectActionObject : GameManager.TurnObjectBase
{
    public PandoraDiceCharaSelectActionObject()
    {
        thisType = GameManager.TurnType.PandoraDiceCharaSelectAction;
    }

    public override void Update()
    {

    }
}

[System.Serializable]
public class PandoraDiceRollActionObject : GameManager.TurnObjectBase
{
    public PandoraDiceRollActionObject()
    {
        thisType = GameManager.TurnType.PandoraDiceRollAction;
    }

    public override void Update()
    {

    }
}

[System.Serializable]
public class DoubleEndCheckObject : GameManager.TurnObjectBase
{
    public DoubleEndCheckObject()
    {
        thisType = GameManager.TurnType.DoubleEndCheck;
    }

    public override void Update()
    {
        var player = gameManager.GetNowCharacter();
        player.SetDoubleFlg(false);
    }
}

[System.Serializable]
public class TurnEndObject : GameManager.TurnObjectBase
{
    public TurnEndObject()
    {
        thisType = GameManager.TurnType.TurnEnd;
    }

    public override void Update()
    {
        gameManager.SetNextNowPlayer();
        gameManager.ChangeTurn();
    }
}