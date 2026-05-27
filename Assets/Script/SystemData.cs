using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SystemData
{
    private SystemData() { }

    public static SystemData ins { get; private set; } = new SystemData();

    [SerializeField, ChUnity.ReadOnly]
    public int playCharacters = 2;

    [SerializeField, ChUnity.ReadOnly]
    public int useDeckNo = -1;
}
