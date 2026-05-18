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

    abstract public class TurnObjectBase
    {
        public void SetGameManager(GameManager _manager) { gameManager = _manager; }

        protected void SetNextNowPlayer() { gameManager.SetNextNowPlayer(); }

        protected Character GetNowPlayer() { return gameManager.characterList[gameManager.nowPlayer]; }

        protected void SetSelectCharacter(int _no) { gameManager.SetSelectCharacter(_no); }

        protected Character GetSelectCharacter() { return gameManager.characterList[gameManager.selectPlayer]; }

        protected bool IsPandoraDice() { return gameManager.pandoraDiceFlg; }
        
        protected void ChangeTurn() { gameManager.changeTurnFlg = true; }

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnObject[(int)nowTurnType].Update();

        if (!changeTurnFlg) return;

        nowTurnType = nextTurn;
        turnObject[(int)nowTurnType].Init();

        nextTurn = (TurnType)((int)(nextTurn) + 1 % (int)(TurnType.TurnEnd + 1));
        changeTurnFlg = false;
    }


    TurnObjectBase[] turnObject = new TurnObjectBase[(int)TurnType.TurnEnd + 1];
    TurnType nowTurnType = TurnType.TurnStart;
    TurnType nextTurn = TurnType.FutureAttackCheck;
    bool changeTurnFlg = false;

    int nowPlayer = 0;
    int selectPlayer = 0;
    bool pandoraDiceFlg = false;
    List<Character>characterList = new List<Character>();
}
