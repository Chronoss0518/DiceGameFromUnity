using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)),ExecuteAlways]
public class AspectController : MonoBehaviour
{

    [SerializeField]
    Vector2 targetSize = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        var cam = GetComponent<Camera>();
        if (cam == null) return;

        float screenAspect = (float)Screen.width / (float)Screen.height;
        float targetAspect = targetSize.x / targetSize.y;

        float scaleHeight = screenAspect / targetAspect;

        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (scaleHeight < 1.0)
        {
            rect.height = scaleHeight;
            rect.y = (1.0f - rect.height) * 0.5f;
        }
        else
        {
            rect.width = 1.0f / scaleHeight;
            rect.x = (1.0f - rect.width) * 0.5f;

        }

        cam.rect = rect;
    }
}
