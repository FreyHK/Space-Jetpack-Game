using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFuelCanister : Entity {

    float HitRadius = 1f;

    public override void UpdatePhysics() {
        //Check if touching player
        Collider2D[] cols = Physics2D.OverlapCircleAll((Vector2)transform.position, HitRadius + .5f);

        for (int i = 0; i < cols.Length; i++) {
            if (cols[i].tag != "Player")
                continue;

            EntityJetpack p = cols[i].GetComponent<EntityJetpack>();
            p.RefillFuel();
        }
    }
}
