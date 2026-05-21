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

    abstract public class TurnObjectBase
    {
        public void SetGameManager(GameManager _manager) { gameManager = _manager; }

        protected void SetNextNowPlayer() { gameManager.SetNextNowPlayer(); }

        protected Character GetNowCharacter() { return gameManager.GetNowCharacter(); }

        protected void SetSelectCharacter(int _no) { gameManager.SetSelectCharacter(_no); }

        protected Character GetSelectCharacter() { return gameManager.GetSelectCharacter(); }

        protected bool IsPandoraDice() { return gameManager.IsPandoraDice(); }

        protected void ChangeTurn() { gameManager.ChangeTurn(); }

        abstract public void Update();

        virtual public void Init() { }

        GameManager gameManager = null;
    }

    public void SetNextNowPlayer()
    {
        nowPlayer = (nowPlayer + 1) % characterList.Count;
    }

    public void SetSelectCharacter(int _no)
    {
        if (_no < 0) return;
        if (characterList.Count <= _no) return;
        selectPlayer = _no;
    }

    public Character GetNowCharacter()
    {
        if (characterList.Count <= nowPlayer) return null;
        return characterList[nowPlayer];
    }

    public Character GetSelectCharacter()
    {
        if (characterList.Count <= selectPlayer) return null;
        return characterList[selectPlayer];
    }

    public void AddFutureAttackObject(FutureAttackObject _obj)
    {
        var turn = (FutureAttackCheckObject)turnObject[(int)TurnType.FutureAttackCheck];
        turn.AddFutureAttackObject(_obj);
    }

    public bool IsPandoraDice() { return pandoraDiceFlg; }

    public void ChangeTurn() { changeTurnFlg = true; }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < TURN_TYPE_COUNT; i++)
        {
            turnObject[i].SetGameManager(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        turnObject[(int)nowTurnType].Update();

        if (!changeTurnFlg) return;

        nowTurnType = nextTurn;
        turnObject[(int)nowTurnType].Init();

        nextTurn = (TurnType)((int)(nextTurn) + 1 % TURN_TYPE_COUNT);
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

    TurnType nowTurnType = TurnType.TurnStart;
    TurnType nextTurn = TurnType.FutureAttackCheck;
    bool changeTurnFlg = false;

    int nowPlayer = 0;
    int selectPlayer = 0;
    bool pandoraDiceFlg = false;
    List<Character>characterList = new List<Character>();
}
