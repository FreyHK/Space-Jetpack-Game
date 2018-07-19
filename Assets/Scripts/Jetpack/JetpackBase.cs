using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBase : MonoBehaviour {

    public JetpackMotor motor;
    public JetpackInput input;
    public JetpackEffects effects;
    public JetpackAnimator animator;
    public JetpackUI UI;

    public void UpdatePlayer () {
        float inp = input.GetHorizontalInput();
        bool thrustInp = input.GetThrusterInput();
        bool jumpInp = input.GetJumpInput();

        motor.UpdatePhysics(inp, thrustInp, jumpInp);

        if (effects != null)
            effects.UpdateEffects(motor.IsThrusting);

        if (animator != null)
            animator.DoUpdate(inp);

        if (UI != null)
            UI.DoUpdate(motor.Fuel, motor.MaxFuel);
    }
}
