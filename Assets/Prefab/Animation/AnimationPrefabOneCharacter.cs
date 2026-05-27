using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AnimationPrefabOneCharacter : AnimationPrefabBase
{
    public override void Init(GameManager _gm, Character _user, Character _target)
    {
        base.Init(_gm, _user, _target);
        if (_gm == null) return;
        user = _user;
    }

    Character user = null;
}
