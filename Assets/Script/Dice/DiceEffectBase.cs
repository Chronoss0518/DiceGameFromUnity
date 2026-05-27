using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DiceEffectBase : ScriptableObject
{

    public const string DAMAGE_TEXT = "%t‚Í%dƒ_ƒ[ƒW‚ğó‚¯‚½!!";
    public const string GUARD_TEXT = "%t‚ÍUŒ‚‚ğƒK[ƒh‚µ‚½!!";
    public const string HEALING_TEXT = "%u‚Í%h‰ñ•œ‚µ‚½";


    abstract public void Run(GameManager _gm, Character _user, Character _target);

    protected void RunDamage(GameManager _gm, Character _user, Character _target, AnimationPrefabBase _guardAnimationPrefab, int _damage)
    {
        string text = "";
        if (_target.IsGuardFlg())
        {
            text = GameManager.GenerateTargetName(GUARD_TEXT, _target);

            _gm.SetMessage(_gm.GetMessage() + "\n" + text);

            if (_guardAnimationPrefab == null) return;
            Instantiate(_guardAnimationPrefab.gameObject);
        }

        text = GameManager.GenerateDamage(DAMAGE_TEXT, _damage);
        text = GameManager.GenerateTargetName(text, _target);

        _target.Damage(_damage);

        _gm.SetMessage(_gm.GetMessage() + "\n" + text);

        if (animationPrefab == null) return;
    }

    [SerializeField]
    protected AnimationPrefabBase animationPrefab = null;

    [SerializeField]
    protected string effectText = "";
}

//’ÊíUŒ‚//
[CreateAssetMenu(fileName = "NormalAttack", menuName = "DiceEffect/NormalAttack")]
public class DE_NormalAttack : DiceEffectBase
{
    
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        string text = GameManager.GenerateUserName(effectText, _user);
        _gm.SetMessage(text);
    }

    [SerializeField]
    protected AnimationPrefabBase guardAnimationPrefab = null;

    [SerializeField]
    protected int damage = 0;
}

//ƒXƒ^ƒ“‚ğ‹N‚±‚·UŒ‚//
[CreateAssetMenu(fileName = "StanAttack", menuName = "DiceEffect/StanAttack")]
public class DE_StanAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab,damage);
    }
}

//•X’Ğ‚¯‚ğ‹N‚±‚·UŒ‚//
[CreateAssetMenu(fileName = "IceAttack", menuName = "DiceEffect/IceAttack")]
public class DE_IceAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

    [SerializeField]
    int iceCount = 0;
}

//—¼ƒvƒŒƒCƒ„[‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚éUŒ‚//
[CreateAssetMenu(fileName = "BothPlayerAttack", menuName = "DiceEffect/BothPlayerAttack")]
public class DE_BothPlayerAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

}

//‘Šè‚ÌHP‚ğ‹zû‚·‚éUŒ‚//
[CreateAssetMenu(fileName = "AbsorptionAttack", menuName = "DiceEffect/AbsorptionAttack")]
public class DE_AbsorptionAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

}

//©g‚ÌHP‚ğ“Á’è‚Ì”’l‚É‚µ‚ÄUŒ‚//
[CreateAssetMenu(fileName = "SacrificeAttack", menuName = "DiceEffect/SacrificeAttack")]
public class DE_SacrificeAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

    [SerializeField]
    int sacrificePoint = 0;
}

//FutureAttackObject‚ğ¶¬‚·‚éUŒ‚//
[CreateAssetMenu(fileName = "FutureAttack", menuName = "DiceEffect/FutureAttack")]
public class DE_FutureAttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

    [SerializeField]
    int sacrificePoint = 0;
}

//‰ñ•œ‚µ‚È‚ª‚çUŒ‚//
[CreateAssetMenu(fileName = "HealingAtttack", menuName = "DiceEffect/HealingAtttack")]
public class DE_HealingAtttack : DE_NormalAttack
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {
        RunDamage(_gm, _user, _target, guardAnimationPrefab, damage);
    }

    [SerializeField]
    int healingPoint = 0;
}

//‰ñ•œ//
[CreateAssetMenu(fileName = "HealingPoint", menuName = "DiceEffect/HealingPoint")]
public class DE_HealingPoint : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

    [SerializeField]
    int healingPoint = 0;
}

//‘ÎÛ‚ÌƒLƒƒƒ‰ƒNƒ^[‚ÆHP‚ğ“ü‚ê‘Ö‚¦‚é//
[CreateAssetMenu(fileName = "ChangeHP", menuName = "DiceEffect/ChangeHP")]
public class DE_ChangeHP : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

    [SerializeField]
    protected AnimationPrefabBase guardAnimationPrefab = null;

}

//ƒ_ƒ[ƒW2”{Œø‰Ê‚Ì•t—^//
[CreateAssetMenu(fileName = "SetDouble", menuName = "DiceEffect/SetDouble")]
public class DE_SetDouble : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

}

//ƒK[ƒhŒø‰Ê‚Ì•t—^//
[CreateAssetMenu(fileName = "SetGuard", menuName = "DiceEffect/SetGuard")]
public class DE_SetGuard : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

}

//‘Šè‚ÉStan‚ğ—^‚¦‚é//
[CreateAssetMenu(fileName = "SetStan", menuName = "DiceEffect/SetStan")]
public class DE_SetStan : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

}

//‘Šè‚ÉStan‚ğ—^‚¦‚é//
[CreateAssetMenu(fileName = "SetIce", menuName = "DiceEffect/SetIce")]
public class DE_SetIce : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

    [SerializeField]
    int iceCount = 0;
}

//‘Šè‚ÉStan‚ğ—^‚¦‚é//
[CreateAssetMenu(fileName = "SetHP", menuName = "DiceEffect/SetHP")]
public class DE_SetHP : DiceEffectBase
{
    public override void Run(GameManager _gm, Character _user, Character _target)
    {

    }

    [SerializeField]
    int hp = 0;
}
