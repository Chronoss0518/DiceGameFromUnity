using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPrefabTweCharacter : AnimationPrefabBase
{
    public override void Init(GameManager _gm, Character _user, Character _target)
    {
        base.Init(_gm, _user, _target);
        if (_gm == null) return;
        user = _user;
        target = _target;
    }

    Character user = null;
    Character target = null;
}
