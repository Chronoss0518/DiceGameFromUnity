using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideObject : MonoBehaviour
{
    [SerializeField]
    Text text = null;

    [SerializeField]
    GameObject textObject = null;

    [SerializeField]
    RawImage image = null;

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
        if (image == null) return;
        if (textObject == null) return;

        text.text = _text;
        textObject.SetActive(true);
        image.gameObject.SetActive(false);

        anim.Play();
    }

    public void SetImage(Texture2D _image)
    {
        if (text == null) return;
        if (image == null) return;
        if (textObject == null) return;

        image.texture = _image;
        textObject.SetActive(false);
        image.gameObject.SetActive(true);

        anim.Play();
    }

    void Start()
    {
        if (anim == null) return;
        anim.Stop();
    }
}
