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

    float JetpackPower = 15f;

    float JumpPower = 6f;
    float AirJumpPower = 6f;

    float MoveSpeed = 3f;

    private void Awake() {
        Fuel = MaxFuel;
    }

    bool canAirJump = false;

    public void UpdatePhysics (float inpMove, bool jump, bool airJump) {
        IsThrusting = false;

        UpdateGrounded();

        if (IsGrounded && jump) {
            body.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);
            canAirJump = true;
        }else if (jump && canAirJump) {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0f, AirJumpPower), ForceMode2D.Impulse);
            canAirJump = false;
        }

        /*
        if (thruster && Fuel > 0f) {
            //Move upwards
            //body.AddForce(new Vector2(0f, JetpackPower));

            body.velocity = new Vector2(body.velocity.x, JetpackPower/5f);

            //Use fuel
            Fuel -= Time.deltaTime * fuelUseSpeed;
            //Set flag
            IsThrusting = true;
        }
        Regeneratefuel(IsThrusting);
        */

        //Moving horizontally
        body.velocity = new Vector2(inpMove * MoveSpeed, body.velocity.y);
    }
    
    float fuelRegenSpeed = .5f;

    float cooldown = 3f;

    /*
    void Regeneratefuel(bool thrusting) {

        if (thrusting) {
            cooldown = 3f;
            return;
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f && Fuel < MaxFuel) {
            //Regenerate fuel over time
            Fuel = Mathf.Clamp(Fuel + Time.deltaTime * fuelRegenSpeed, 0, MaxFuel);
        }
    }
    */

    public Transform groundCheck;
    public LayerMask groundMask;

    void UpdateGrounded () {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, .1f, groundMask);
    }
}
