using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AnimationPrefabBase : MonoBehaviour
{
    public bool isAnimationEnd { get; private set; } = false;

    public virtual void Init(GameManager _gm,Character _user, Character _target)
    {
        if (_gm == null) return;
        gameManager = _gm;
    }

    public void SetUpdateMessage(string _message)
    {
        updateMessage = _message;
    }

    public void SetAnimationEnd(bool _endFlg) {  isAnimationEnd = _endFlg; }

    public void SetUpdateMessage()
    {
        gameManager.SetMessage(updateMessage);
    }

    GameManager gameManager = null;

    string updateMessage = "";
}
