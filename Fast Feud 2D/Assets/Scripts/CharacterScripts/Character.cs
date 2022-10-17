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
    protected float charSpeed { get; protected set; }
    [SerializeField]
    protected int jumpHeight { get; protected set; }
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
    protected int lightAttackSUF { get; protected set; }
    [SerializeField]
    protected int lightAttackACF { get; protected set; }
    [SerializeField]
    protected int lightAttackREF { get; protected set; }
    //## HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    protected int heavyAttackSUF { get; protected set; }
    [SerializeField]
    protected int heavyAttackACF { get; protected set; }
    [SerializeField]
    protected int heavyAttackREF { get; protected set; }
    //## KICK FRAME DATA ##
    [SerializeField]
    protected int kickSUF { get; protected set; }
    [SerializeField]
    protected int kickACF { get; protected set; }
    [SerializeField]
    protected int kickREF { get; protected set; }
    //## JUMP FRAME DATA ##
    [SerializeField]
    protected int jumpSUF { get; protected set; }
    [SerializeField]
    protected int jumpACF { get; protected set; }
    [SerializeField]
    protected int jumpREF { get; protected set; }
    //## SUPER ATTACK FRAME DATA ##
    [SerializeField]
    protected int superAttackSUF { get; protected set; }
    [SerializeField]
    protected int superAttackACF { get; protected set; }
    [SerializeField]
    protected int superAttackREF { get; protected set; }
    //## CROUCHING LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    protected int crouchLightAttackSUF { get; protected set; }
    [SerializeField]
    protected int crouchLightAttackACF { get; protected set; }
    [SerializeField]
    protected int crouchLightAttackREF { get; protected set; }
    //## CROUCHING HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    protected int crouchHeavyAttackSUF { get; protected set; }
    [SerializeField]
    protected int crouchHeavyAttackACF { get; protected set; }
    [SerializeField]
    protected int crouchHeavyAttackREF { get; protected set; }
    //## CROUCHING KICK FRAME DATA ##
    [SerializeField]
    protected int crouchKickSUF { get; protected set; }
    [SerializeField]
    protected int crouchKickACF { get; protected set; }
    [SerializeField]
    protected int crouchKickREF { get; protected set; }
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