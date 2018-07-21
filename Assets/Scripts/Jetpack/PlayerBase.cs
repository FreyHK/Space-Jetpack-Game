using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : Entity {

    public JetpackMotor motor;
    public JetpackInput input;
    public JetpackEffects effects;
    public JetpackAnimator animator;
    public JetpackUI UI;


    float inp = 0f;
    bool thrustInp = false;
    bool jumpInp = false;

    public override void DoUpdate() {

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
        motor.UpdatePhysics(inp, thrustInp, jumpInp);

        //Reset input
        if (thrustInp)
            thrustInp = false;

        if (jumpInp)
            jumpInp = false;
    }
}
