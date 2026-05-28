using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FutureAttackObject : ScriptableObject
{
    [SerializeField]
    protected AnimationPrefabBase animationPrefab = null;

    [SerializeField]
    public int turnCount = 0;

    [SerializeField]
    public int damage = 0;

    [SerializeField]
    public string text = "";
}
