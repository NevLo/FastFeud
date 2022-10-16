using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character
{
    [SerializeField]
    private uint maxHealth { get; set; }
    private uint health { get; set; };
    private bool isAlive { get; set; };
    [SerializeField]
    private float charSpeed { get; };
    [SerializeField]
    private int jumpHeight { get; };
    [SerializeField]
    private Sprite characterPNG { get; set; }


    private bool isStunned { get; set; }
    private bool isBlocking { get; set; }
    private bool isCrouching { get; set; }
    private bool isJumping { get; set; }
    private bool isAttacking { get; set; }
    private bool isSupering { get; set; }
    private bool isSuperInvicibleSU { get; }

    //## LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    private int lightAttackSUF { get; }
    [SerializeField]
    private int lightAttackACF { get; }
    [SerializeField]
    private int lightAttackREF { get; }
    //## HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    private int heavyAttackSUF { get; }
    [SerializeField]
    private int heavyAttackACF { get; }
    [SerializeField]
    private int heavyAttackREF { get; }
    //## KICK FRAME DATA ##
    [SerializeField]
    private int kickSUF { get; }
    [SerializeField]
    private int kickACF { get; }
    [SerializeField]
    private int kickREF { get; }
    //## JUMP FRAME DATA ##
    [SerializeField]
    private int jumpSUF { get; }
    [SerializeField]
    private int jumpACF { get; }
    [SerializeField]
    private int jumpREF { get; }
    //## SUPER ATTACK FRAME DATA ##
    [SerializeField]
    private int superAttackSUF { get; }
    [SerializeField]
    private int superAttackACF { get; }
    [SerializeField]
    private int superAttackREF { get; }
    //## CROUCHING LIGHT ATTACK FRAME DATA ##
    [SerializeField]
    private int crouchLightAttackSUF { get; }
    [SerializeField]
    private int crouchLightAttackACF { get; }
    [SerializeField]
    private int crouchLightAttackREF { get; }
    //## CROUCHING HEAVY ATTACK FRAME DATA ##
    [SerializeField]
    private int crouchHeavyAttackSUF { get; }
    [SerializeField]
    private int crouchHeavyAttackACF { get; }
    [SerializeField]
    private int crouchHeavyAttackREF { get; }
    //## CROUCHING KICK FRAME DATA ##
    [SerializeField]
    private int crouchKickSUF { get; }
    [SerializeField]
    private int crouchKickACF { get; }
    [SerializeField]
    private int crouchKickREF { get; }
    //## ATTACK DAMAGE NUMBERS ##
    private int lightAttackDamage;
    private int heavyAttackDamage;
    private int kickAttackDamage;
    private int cLightAttackDamage;
    private int cHeavyAttackDamage;
    private int cKickAttackDamage;
    private int superAttackDamage;
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
        return (isSupering ? !isSuperInvicibleSU : (isBlocking ? isCrouching : true);
    }
    public bool isLowHittable()
    {
        return (isSupering ? !isSuperInvicibleSU : (isBlocking ? !isCrouching : true);
    }
    public bool isHittable()
    {
        return (isSupering ? !isSuperInvicibleSU : !isBlocking);

        //return (!isBlocking);
    }
}