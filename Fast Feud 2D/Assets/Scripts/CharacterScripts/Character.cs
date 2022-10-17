using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character
{
    [SerializeField]
    protected uint maxHealth { get; set; }
    protected uint health { get; set; }
    protected bool isAlive { get; set; }
    [SerializeField]
    protected float charSpeed { get; }
    [SerializeField]
    protected int jumpHeight { get; }
    [SerializeField]
    protected Sprite characterPNG { get; set; }


    protected bool isStunned { get; set; }
    protected bool isBlocking { get; set; }
    protected bool isCrouching { get; set; }
    protected bool isJumping { get; set; }
    protected bool isAttacking { get; set; }
    protected bool isSupering { get; set; }
    protected bool isSuperInvicibleSU { get; }

    //## LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    protected int lightAttackSUF { get; }
    [SerializeField]
    protected int lightAttackACF { get; }
    [SerializeField]
    protected int lightAttackREF { get; }
    //## HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    protected int heavyAttackSUF { get; }
    [SerializeField]
    protected int heavyAttackACF { get; }
    [SerializeField]
    protected int heavyAttackREF { get; }
    //## KICK FRAME DATA ##
    [SerializeField]
    protected int kickSUF { get; }
    [SerializeField]
    protected int kickACF { get; }
    [SerializeField]
    protected int kickREF { get; }
    //## JUMP FRAME DATA ##
    [SerializeField]
    protected int jumpSUF { get; }
    [SerializeField]
    protected int jumpACF { get; }
    [SerializeField]
    protected int jumpREF { get; }
    //## SUPER ATTACK FRAME DATA ##
    [SerializeField]
    protected int superAttackSUF { get; }
    [SerializeField]
    protected int superAttackACF { get; }
    [SerializeField]
    protected int superAttackREF { get; }
    //## CROUCHING LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    protected int crouchLightAttackSUF { get; }
    [SerializeField]
    protected int crouchLightAttackACF { get; }
    [SerializeField]
    protected int crouchLightAttackREF { get; }
    //## CROUCHING HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    protected int crouchHeavyAttackSUF { get; }
    [SerializeField]
    protected int crouchHeavyAttackACF { get; }
    [SerializeField]
    protected int crouchHeavyAttackREF { get; }
    //## CROUCHING KICK FRAME DATA ##
    [SerializeField]
    protected int crouchKickSUF { get; }
    [SerializeField]
    protected int crouchKickACF { get; }
    [SerializeField]
    protected int crouchKickREF { get; }
    //## ATTACK DAMAGE NUMBERS ##
    protected int lightAttackDamage;
    protected int heavyAttackDamage;
    protected int kickAttackDamage;
    protected int cLightAttackDamage;
    protected int cHeavyAttackDamage;
    protected int cKickAttackDamage;
    protected int superAttackDamage;
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