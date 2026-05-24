using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DiceEffectBase : ScriptableObject
{
    public virtual void Init() { }

    abstract public void Update(Character _user, Character _target);

    [SerializeField]
    protected string effectText = "";
}

//’ÊíUŒ‚//
[CreateAssetMenu(fileName = "NormalAttack", menuName = "DiceEffect/NormalAttack")]
public class DE_NormalAttack : DiceEffectBase
{
    public override void Update(Character _user, Character _target)
    {
        
    }

    [SerializeField]
    protected int damage = 0;
}

//ƒXƒ^ƒ“‚ğ‹N‚±‚·UŒ‚//
[CreateAssetMenu(fileName = "StanAttack", menuName = "DiceEffect/StanAttack")]
public class DE_StanAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }
}

//•X’Ğ‚¯‚ğ‹N‚±‚·UŒ‚//
[CreateAssetMenu(fileName = "IceAttack", menuName = "DiceEffect/IceAttack")]
public class DE_IceAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }

    [SerializeField]
    int iceCount = 0;
}

//—¼ƒvƒŒƒCƒ„[‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚éUŒ‚//
[CreateAssetMenu(fileName = "BothPlayerAttack", menuName = "DiceEffect/BothPlayerAttack")]
public class DE_BothPlayerAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }

}

//‘Šè‚ÌHP‚ğ‹zû‚·‚éUŒ‚//
[CreateAssetMenu(fileName = "AbsorptionAttack", menuName = "DiceEffect/AbsorptionAttack")]
public class DE_AbsorptionAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }

}

//©g‚ÌHP‚ğ“Á’è‚Ì”’l‚É‚µ‚ÄUŒ‚//
[CreateAssetMenu(fileName = "SacrificeAttack", menuName = "DiceEffect/SacrificeAttack")]
public class DE_SacrificeAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }

    [SerializeField]
    int sacrificePoint = 0;
}

//FutureAttackObject‚ğ¶¬‚·‚éUŒ‚//
[CreateAssetMenu(fileName = "FutureAttack", menuName = "DiceEffect/FutureAttack")]
public class DE_FutureAttack : DE_NormalAttack
{
    public override void Update(Character _user, Character _target)
    {

    }

    [SerializeField]
    int sacrificePoint = 0;
}

//‰ñ•œ//
[CreateAssetMenu(fileName = "HealingPoint", menuName = "DiceEffect/HealingPoint")]
public class DE_HealingPoint : DiceEffectBase
{
    public override void Update(Character _user, Character _target)
    {

    }

    [SerializeField]
    int healingPoint = 0;
}

//‘ÎÛ‚ÌƒLƒƒƒ‰ƒNƒ^[‚ÆHP‚ğ“ü‚ê‘Ö‚¦‚é//
[CreateAssetMenu(fileName = "ChangeHP", menuName = "DiceEffect/ChangeHP")]
public class DE_ChangeHP : DiceEffectBase
{
    public override void Update(Character _user, Character _target)
    {

    }

}

//ƒ_ƒ[ƒW2”{Œø‰Ê‚Ì•t—^//
[CreateAssetMenu(fileName = "SetDouble", menuName = "DiceEffect/SetDouble")]
public class DE_SetDouble : DiceEffectBase
{
    public override void Update(Character _user, Character _target)
    {

    }

}

//ƒK[ƒhŒø‰Ê‚Ì•t—^//
[CreateAssetMenu(fileName = "SetGuard", menuName = "DiceEffect/SetGuard")]
public class DE_SetGuard : DiceEffectBase
{
    public override void Update(Character _user, Character _target)
    {

    }

}