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
    bool thrustInp = false;
    bool jumpInp = false;

    public override void DoUpdate() {
        if (IsDead)
            return;

        inp = input.GetHorizontalInput();

        //Only set if we havent already
        thrustInp = thrustInp ? true : input.GetThrusterInput();
        jumpInp = jumpInp ? true : input.GetJumpInput();

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

        motor.UpdatePhysics(inp, thrustInp, jumpInp);

        //Reset input
        if (thrustInp)
            thrustInp = false;

        if (jumpInp)
            jumpInp = false;
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
