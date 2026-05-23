using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideText : MonoBehaviour
{
    [SerializeField]
    Text text = null;

    [SerializeField]
    Animation anim = null;

    public bool IsStop
    {
        get
        {
            if (anim == null) return true;
            return !anim.isPlaying;
        }
    }

    public void SetText(string _text)
    {
        if (text == null) return;
        text.text = _text;
        anim.Play();
    }

    void Start()
    {
        if (anim == null) return;
        anim.Stop();
    }
}
