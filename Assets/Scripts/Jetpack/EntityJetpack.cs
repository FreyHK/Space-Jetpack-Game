using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityJetpack : Entity {

    public JetpackMotor motor;
    public JetpackInput input;
    public JetpackEffects effects;
    public JetpackAnimator animator;
    public JetpackUI UI;

    float inp = 0f;
    //bool thrustInp = false;
    bool jumpInp = false;
    bool airJumpInp = false;

    public override void DoUpdate() {
        if (IsDead)
            return;

        inp = input.GetHorizontalInput();
        
        //We NEED to do this in update since that's when input strikes
        jumpInp = input.GetJump();
        airJumpInp = input.GetAirJump();

        if (effects != null)
            effects.UpdateEffects(motor.IsThrusting);

        if (animator != null)
            animator.DoUpdate(inp);

        if (UI != null)
            UI.DoUpdate(motor.Fuel, motor.MaxFuel);
    }

    public override void UpdatePhysics() {
        if (IsDead)
            return;

        motor.UpdatePhysics(inp, jumpInp, airJumpInp);

        //Reset input
        jumpInp = false;
        airJumpInp = false;
    }

    protected override void OnTakeDamage(int dmg) {
        StartCoroutine(ActivateGracePeriod());
    }

    float GracePeriodDuration = 3f;

    IEnumerator ActivateGracePeriod () {
        //Can't be damaged by enemies
        Invincible = true;

        yield return new WaitForSeconds(GracePeriodDuration);

        //Can be damaged again
        Invincible = false;
    }

    protected override void OnDeath() {

    }

    public void RefillFuel () {
        motor.Fuel = motor.MaxFuel;
    }
}
