using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FutureAttackObject
{
    [SerializeField,ChUnity.ReadOnly]
    int turnCount = 0;

    [SerializeField, ChUnity.ReadOnly]
    int damage = 0;
}
