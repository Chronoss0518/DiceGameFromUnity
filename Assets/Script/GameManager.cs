using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum TurnType
    {
        TurnStart,
        FutureAttackCheck,
        IceCheck,
        StanCheck,
        GuardEndCheck,
        PandoraDiceCheck,
        SelectAction,//Playerのアクション//
        DiceRollAction,//Playerのアクション//
        DiceEffect,
        PandoraDiceStartCheck,
        PandoraDiceCharaSelectAction,//Playerのアクション//
        PandoraDiceRollAction,//Playerのアクション//
        DoubleEndCheck,
        TurnEnd,
    }

    const int TURN_TYPE_COUNT = (int)TurnType.TurnEnd + 1;

    [System.Serializable]
    abstract public class TurnObjectBase
    {
        public void SetGameManager(GameManager _manager) { if(_manager != null) gameManager = _manager; }

        abstract public void Update();

        virtual public void Init() { }

        protected GameManager gameManager { get; private set; } = null;

        [SerializeField, ChUnity.ReadOnly]
        protected TurnType thisType = TurnType.TurnStart;
    }

    public int CreateDiceRollResult()
    {
        return DiceObject.GetDiceRollResult();
    }

    public void SetNextNowPlayer()
    {
        if (characterList.Count <= 0) return;
        nowPlayer = (nowPlayer + 1) % characterList.Count;
    }

    public void SetSlideText(string _text)
    {
        if (slideObject == null) return;
        if (!slideObject.isStop) return;
        slideObject.SetText(_text);
    }

    public void SetSlideImage(Texture2D _image)
    {
        if (slideObject == null) return;
        if (!slideObject.isStop) return;
        slideObject.SetImage(_image);
    }

    public void SetSelectDiceAction(int _no)
    {
        var turn = (SelectActionObject)turnObject[(int)TurnType.SelectAction];
        turn.SetSelectDice(_no);
    }

    public void SetSelectCharacterAction(int _no)
    {
        var turn = (SelectActionObject)turnObject[(int)TurnType.SelectAction];
        turn.SetSelectDice(_no);
    }

    public void SetMessage(string _message)
    {
        if (messageBox == null) return;
        messageBox.SetText(_message);
    }

    public void SetMessageBoxVisible(bool _flg)
    {
        if (messageBox == null) return;
        messageBox.SetVisible(_flg);
    }

    public Character GetNowCharacter()
    {
        if (characterList.Count <= nowPlayer) return null;
        return characterList[nowPlayer];
    }

    public int GetNowCharacterNo() { return nowPlayer; }

    public Character GetSelectCharacter()
    {
        var turn = (SelectActionObject)turnObject[(int)TurnType.SelectAction];
        if (characterList.Count <= turn.GetSelectCharacterNo()) return null;
        return characterList[turn.GetSelectCharacterNo()];
    }

    public int GetSelectDice()
    {
        var turn = (SelectActionObject)turnObject[(int)TurnType.SelectAction];
        return turn.GetSelectDiceNo();
    }

    public DiceRoll GetDiceRollPrefab()
    {
        return diceRollPrefab;
    }

    public int GetAnimationEndFrame() { return animationEndFrame; }

    public int GetNormalDiceRollResult()
    {
        var turn = (DiceRollActionObject)turnObject[(int)TurnType.DiceRollAction];
        return turn.diceRollResult;
    }

    public void AddFutureAttackObject(FutureAttackObject _obj)
    {
        var turn = (FutureAttackCheckObject)turnObject[(int)TurnType.FutureAttackCheck];
        turn.AddFutureAttackObject(_obj);
    }

    public bool IsPandoraDice() { return pandoraDiceFlg; }

    public bool IsSlideTextStop() 
    {
        if (slideObject == null) return true;
        return slideObject.isStop;
    }

    public void ChangeTurn() { changeTurnFlg = true; }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < TURN_TYPE_COUNT; i++)
        {
            turnObject[i].SetGameManager(this);
        }
        turnObject[(int)nowTurnType].Init();
    }

    // Update is called once per frame
    void Update()
    {
        turnObject[(int)nowTurnType].Update();

        if (!changeTurnFlg) return;

        nowTurnType = nextTurn;
        turnObject[(int)nowTurnType].Init();

        nextTurn = (TurnType)(((int)nextTurn + 1) % TURN_TYPE_COUNT);
        changeTurnFlg = false;
    }

    [SerializeReference]
    TurnObjectBase[] turnObject = new TurnObjectBase[]{
        new TurnStartObject(),
        new FutureAttackCheckObject(),
        new IceCheckObject(),
        new StanCheckObject(),
        new GuardEndCheckObject(),
        new PandoraDiceCheckObject(),
        new SelectActionObject(),
        new DiceRollActionObject(),
        new DiceEffectObject(),
        new PandoraDiceStartCheckObject(),
        new PandoraDiceCharaSelectActionObject(),
        new PandoraDiceRollActionObject(),
        new DoubleEndCheckObject(),
        new TurnEndObject(),
    };

    [SerializeField]
    DiceRoll diceRollPrefab = null;

    [SerializeField]
    SlideObject slideObject = null;

    [SerializeField]
    MessageBox messageBox = null;

    [SerializeField, ChUnity.ReadOnly]
    TurnType nowTurnType = TurnType.TurnStart;

    [SerializeField]
    TurnType nextTurn = TurnType.FutureAttackCheck;

    [SerializeField]
    bool changeTurnFlg = false;

    [SerializeField]
    int animationEndFrame = 600;

    int nowPlayer = 0;
    bool pandoraDiceFlg = false;
    List<Character>characterList = new List<Character>();
}
