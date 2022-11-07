using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character
{
    [SerializeField]
    public uint maxHealth { get; set; }
    public uint health { get; set; }
    public bool isAlive { get; set; }
    [SerializeField]
    public float charSpeed { get; set; }
    [SerializeField]
    public int jumpHeight { get; set; }
    [SerializeField]
    public Sprite characterPNG { get; set; }

    public bool isAnimatable { get; set; } = false;

    public bool isStunned { get; set; }
    public bool isBlocking { get; set; }
    public bool isCrouching { get; set; }
    public bool isJumping { get; set; }
    public bool isAttacking { get; set; }
    public bool isSupering { get; set; }
    public bool isSuperInvicibleSU { get; set; }

    //## LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    public int lightAttackSUF { get; set; }
    [SerializeField]
    public int lightAttackACF { get;  set; }
    [SerializeField]
    public int lightAttackREF { get; set; }
    //## HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    public int heavyAttackSUF { get;  set; }
    [SerializeField]
    public int heavyAttackACF { get; set; }
    [SerializeField]
    public int heavyAttackREF { get; set; }
    //## KICK FRAME DATA ##
    [SerializeField]
    public int kickSUF { get;  set; }
    [SerializeField]
    public int kickACF { get;  set; }
    [SerializeField]
    public int kickREF { get;  set; }
    //## JUMP FRAME DATA ##
    [SerializeField]
    public int jumpSUF { get;  set; }
    [SerializeField]
    public int jumpACF { get;  set; }
    [SerializeField]
    public int jumpREF { get;  set; }
    //## SUPER ATTACK FRAME DATA ##
    [SerializeField]
    public int superAttackSUF { get;  set; }
    [SerializeField]
    public int superAttackACF { get;  set; }
    [SerializeField]
    public int superAttackREF { get;  set; }
    //## CROUCHING LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    public int crouchLightAttackSUF { get;  set; }
    [SerializeField]
    public int crouchLightAttackACF { get;  set; }
    [SerializeField]
    public int crouchLightAttackREF { get;  set; }
    //## CROUCHING HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    public int crouchHeavyAttackSUF { get;  set; }
    [SerializeField]
    public int crouchHeavyAttackACF { get;  set; }
    [SerializeField]
    public int crouchHeavyAttackREF { get;  set; }
    //## CROUCHING KICK FRAME DATA ##
    [SerializeField]
    public int crouchKickSUF { get;  set; }
    [SerializeField]
    public int crouchKickACF { get;  set; }
    [SerializeField]
    public int crouchKickREF { get;  set; }
    //## ATTACK DAMAGE NUMBERS ##
    public int lightAttackDamage;
    public int heavyAttackDamage;
    public int kickAttackDamage;
    public int cLightAttackDamage;
    public int cHeavyAttackDamage;
    public int cKickAttackDamage;
    public int superAttackDamage;
    //## ABSTRACT ATTACK METHODS ##
    public abstract void doLightAttack();
    public abstract void doHeavyAttack();
    public abstract void doKickAttack();
    public abstract void doCrouchingLightAttack();
    public abstract void doCrouchingHeavyAttack();
    public abstract void doCrouchingKickAttack();
    public abstract void doSuperAttack();
    //## ABSTRACT ATTACK ANIMATION METHODS ##
    public abstract void doLightAttackAnim();
    public abstract void doHeavyAttackAnim();
    public abstract void doKickAttackAnim();
    public abstract void doCrouchingLightAttackAnim();
    public abstract void doCrouchingHeavyAttackAnim();
    public abstract void doCrouchingKickAttackAnim();
    public abstract void doSuperAttackAnim();
    //## ABSTRACT MOVEMENT ANIMATION METHODS ##
    public abstract void doJumpAnim();
    public abstract void doWalkAnim();
    public abstract void doBlockAnim();
    public abstract void doCrouchAnim();

    public bool isHighHittable()
    {
        return (isSupering ? !isSuperInvicibleSU : (isBlocking ? isCrouching : true));
    }
    public bool isLowHittable()
    {
        return (isSupering ? !isSuperInvicibleSU : (isBlocking ? !isCrouching : true));
    }
    public bool isHittable()
    {
        return (isSupering ? !isSuperInvicibleSU : !isBlocking);

        //return (!isBlocking);
    }
}