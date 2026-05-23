using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField]
    RawImage diceObject = null;

    [SerializeField]
    Animation anim = null;

    [SerializeField]
    int diceAnimationEndFrame = 100;

    [SerializeField, ChUnity.ReadOnly]
    int diceAnimationEndFrameCount = 0;

    public bool IsDiceAnimationEndFlg { get { return diceAnimationEndFrame <= diceAnimationEndFrameCount; } }

    public void SetDiceImage(Texture2D _image)
    {
        if (diceObject == null) return;
        diceObject.texture = _image;
    }

    void Update()
    {
        if (anim != null) return;
        if (anim.isPlaying) return;

        if(diceAnimationEndFrame <= diceAnimationEndFrameCount) return;

        diceAnimationEndFrameCount++;
    }

}
