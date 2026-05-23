using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    [SerializeField]
    Text textObject = null;

    public void SetVisible(bool _visible)
    {
        gameObject.SetActive(_visible);
    }

    public void SetText(string _text)
    {
        if (textObject == null) return;
        textObject.text = _text;
    }

    public string GetText()
    {
        if (textObject == null) return "";
        return textObject.text;
    }
}
