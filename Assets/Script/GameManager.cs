using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnList[(int)nowTurnType].Update();

        if (!changeTurnFlg) return;
        nowTurnType = nextTurn;
        nextTurn = (TurnType)((int)(nextTurn) + 1 % (int)(TurnType.TurnEnd + 1));
        changeTurnFlg = false;
    }

    public enum TurnType
    {
        TurnStart,
        FutureAttackCheck,
        IceCheck,
        StanCheck,
        GuardEndCheck,
        DoubleEndCheck,
        PandoraDiceCheck,
        SelectAction,//Playerのアクション//
        DiceRollAction,//Playerのアクション//
        DiceEffect,
        PandoraDiceStartCheck,
        PandoraDiceCharaSelectAction,//Playerのアクション//
        PandoraDiceRollAction,//Playerのアクション//
        TurnEnd,
    }

    public void SetSelectCharacter(int _no)
    {
        if (_no < 0) return;
        if (characterList.Count <= _no) return ;
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

    abstract public class TurnBase
    {
        public void SetGameManager(GameManager _manager) { gameManager = _manager; }

        public TurnType GetNowTurnType() { return gameManager.nowTurnType; }

        public void SetNowTurnType(TurnType _type) { gameManager.nowTurnType = _type; }

        public Character GetNowCharacter() { return gameManager.GetNowCharacter(); }

        public Character GetSelectCharacter() { return gameManager.GetSelectCharacter(); }

        public bool IsPandoraDice() { return gameManager.pandoraDiceFlg; }

        protected void ChangeTurn() { gameManager.changeTurnFlg = true; }

        abstract public void Update();

        GameManager gameManager = null;
    };

    TurnBase[] turnList = new TurnBase[(int)(TurnType.TurnEnd) + 1];
    TurnType nowTurnType = TurnType.TurnStart;
    TurnType nextTurn = TurnType.FutureAttackCheck;
    bool changeTurnFlg = false;

    int nowPlayer = 0;
    int selectPlayer = 0;
    bool pandoraDiceFlg = false;
    List<Character>characterList = new List<Character>();
}
