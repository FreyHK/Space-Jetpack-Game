using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Entity {
    
	void Start () {
		
	}

    public LayerMask playerMask;
    public float Radius = 3f;

    int Damage = 1;


    float cooldown;

	public override void UpdatePhysics () {
        if (cooldown <= 0f) {
            if (CheckForPlayer())
                cooldown = 2.5f;
        }else {
            cooldown -= Time.deltaTime;
        }
    }

    bool CheckForPlayer () {
        //Check if touching player
        Collider2D[] cols = Physics2D.OverlapCircleAll((Vector2)transform.position, Radius + .5f, playerMask);

        for (int i = 0; i < cols.Length; i++) {
            if (cols[i].tag != "Player")
                continue;

            PlayerBase p = cols[i].GetComponent<PlayerBase>();
            if (!p.IsDead) {
                p.TakeDamage(Damage);
                return true;
            }
        }
        return false;
    }
}
