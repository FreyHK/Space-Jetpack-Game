using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMotor : MonoBehaviour {

    public Rigidbody2D body;
	
    public bool IsGrounded { get; private set; }

    public bool IsThrusting { get; private set; }

    [HideInInspector]
    public float MaxFuel = 2f;

    [HideInInspector]
    public float Fuel;
    
    float fuelUseSpeed = 2f;

    float fuelRegenSpeed = .5f;

    float JetpackPower = 15f;

    float JumpPower = 5f;

    float MoveSpeed = 3f;

    private void Awake() {
        Fuel = MaxFuel;
    }

    public void UpdatePhysics (float inpMove, bool thruster, bool jump) {
        IsThrusting = false;

        UpdateGrounded();

        if (jump && IsGrounded) {
            body.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);
        }

        if (thruster && Fuel > 0f) {
            //Move upwards
            body.AddForce(new Vector2(0f, JetpackPower));
            //Use fuel
            Fuel -= Time.deltaTime * fuelUseSpeed;
            //Set flag
            IsThrusting = true;

        } /*
        else if (Fuel < MaxFuel) {
            //Regenerate fuel over time
            Fuel = Mathf.Clamp(Fuel + Time.deltaTime * fuelRegenSpeed, 0, MaxFuel);
        }
        */

        //Moving horizontally
        body.velocity = new Vector2(inpMove * MoveSpeed, body.velocity.y);
    }

    public Transform groundCheck;
    public LayerMask groundMask;

    void UpdateGrounded () {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, .1f, groundMask);
    }
}
