using System;


public class Annie : Character
{
    public Annie()
    {
        maxHealth = 10;
        health = maxHealth;
        isAlive = (health > 0) ? true : false;

        charSpeed = 10;
        jumpHeight = 10;

        characterPNG = null;

        isStunned = false;
        isBlocking = false;
        isCrouching = false;
        isJumping = false;
        isAttacking = false;
        isSupering = false;
        isSuperInvicibleSU = true;

        //## LIGHT ATTACK FRAME DATA ##
        lightAttackSUF = 0;
        lightAttackACF = 0;
        lightAttackREF = 0;
        //## HEAVY ATTACK FRAME DATA ##
        heavyAttackSUF = 0;
        heavyAttackACF = 0;
        heavyAttackREF = 0;
        //## KICK FRAME DATA ##
        kickSUF = 0;
        kickACF = 0;
        kickREF = 0;
        //## JUMP FRAME DATA ##
        jumpSUF = 0;
        jumpACF = 0;
        jumpREF = 0;
        //## SUPER ATTACK FRAME DATA ##
        superAttackSUF = 0;
        superAttackACF = 0;
        superAttackREF = 0;
        //## CROUCHING LIGHT ATTACK FRAME DATA ##
        crouchLightAttackSUF = 0;
        crouchLightAttackACF = 0;
        crouchLightAttackREF = 0;
        //## CROUCHING HEAVY ATTACK FRAME DATA ##
        crouchHeavyAttackSUF = 0;
        crouchHeavyAttackACF = 0;
        crouchHeavyAttackREF = 0;
        //## CROUCHING KICK FRAME DATA ##
        crouchKickSUF = 0;
        crouchKickACF = 0;
        crouchKickREF = 0;
        //## ATTACK DAMAGE NUMBERS ##
        lightAttackDamage = 0;
        heavyAttackDamage = 0;
        kickAttackDamage = 0;
        cLightAttackDamage = 0;
        cHeavyAttackDamage = 0;
        cKickAttackDamage = 0;
        superAttackDamage = 0;

    }

    //## ABSTRACT ATTACK METHODS ##
    public override void doLightAttack()
    {
        isAttacking = true;
    }
    public override void doHeavyAttack()
    {
        isAttacking = true;
    }
    public override void doKickAttack()
    {
        isAttacking = true;
    }
    public override void doCrouchingLightAttack()
    {
        isAttacking = true;
    }
    public override void doCrouchingHeavyAttack()
    {
        isAttacking = true;
    }
    public override void doCrouchingKickAttack()
    {
        isAttacking = true;
    }
    public override void doSuperAttack()
    {
        isAttacking = true;
        isSupering = true;
    }
    //## ABSTRACT ATTACK ANIMATION METHODS ##
    public override void doLightAttackAnim()
    {

    }
    public override void doHeavyAttackAnim()
    {

    }
    public override void doKickAttackAnim()
    {

    }
    public override void doCrouchingLightAttackAnim()
    {

    }
    public override void doCrouchingHeavyAttackAnim()
    {

    }
    public override void doCrouchingKickAttackAnim()
    {

    }
    public override void doSuperAttackAnim()
    {

    }
    //## ABSTRACT MOVEMENT ANIMATION METHODS ##
    public override void doJumpAnim()
    {

    }
    public override void doWalkAnim()
    {

    }
    public override void doBlockAnim()
    {

    }
    public override void doCrouchAnim()
    {

    }
}