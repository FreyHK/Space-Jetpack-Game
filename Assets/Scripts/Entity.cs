using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    
    [Header("Entity properties")]
    public bool Invincible = false;
    public int Health = 1;
    [Space(10)]

    [HideInInspector]
    public bool IsDead;

    public void TakeDamage (int dmg) {
        if (Invincible)
            return;

        Health -= dmg;
        print(gameObject.name + " took " + dmg.ToString() + " damage.");

        if (Health <= 0) {
            IsDead = true;
            print(gameObject.name + " died.");
        }
    }

    public virtual void DoUpdate() {}

    public virtual void UpdatePhysics () {}
}
