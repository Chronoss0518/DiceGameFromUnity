using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChUnity.Common
{
    public class ApplicationEnd : MonoBehaviour
    {
        public void ShutDownApplication(int _num)
        {
            ShutDown(_num);
        }

        public static void ShutDown(int _num)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(_num);
#endif
        }
    }
}
