using System;


public class LilCeaser : Character
{
    public LilCeaser()
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
        superAttackREF
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
    public void doLightAttack()
    {
        isAttacking = true;
    }
    public void doHeavyAttack()
    {
        isAttacking = true;
    }
    public void doKickAttack()
    {
        isAttacking = true;
    }
    public void doCrouchingLightAttack()
    {
        isAttacking = true;
    }
    public void doCrouchingHeavyAttack()
    {
        isAttacking = true;
    }
    public void doCrouchingKickAttack()
    {
        isAttacking = true;
    }
    public void doSuperAttack()
    {
        isAttacking = true;
        isSupering = true;
    }
    //## ABSTRACT ATTACK ANIMATION METHODS ##
    public void doLightAttackAnim()
    {

    }
    public void doHeavyAttackAnim()
    {

    }
    public void doKickAttackAnim()
    {

    }
    public void doCrouchingLightAttackAnim()
    {

    }
    public void doCrouchingHeavyAttackAnim()
    {

    }
    public void doCrouchingKickAttackAnim()
    {

    }
    public void doSuperAttackAnim()
    {

    }
    //## ABSTRACT MOVEMENT ANIMATION METHODS ##
    public void doJumpAnim()
    {

    }
    public void doWalkAnim()
    {

    }
    public void doBlockAnim()
    {

    }
    public void doCrouchAnim()
    {

    }
}