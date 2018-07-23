using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    
    [Header("Entity properties")]
    public int Health = 1;

    public bool Invincible { get; protected set; }
    public bool IsDead { get; protected set; }

    public void TakeDamage (int dmg) {
        if (Invincible)
            return;

        Health -= dmg;
        print(gameObject.name + " took " + dmg.ToString() + " damage.");
        //Call event
        OnTakeDamage(dmg);

        if (Health <= 0) {
            IsDead = true;
            print(gameObject.name + " died.");
            //Call event
            OnDeath();
        }
    }

    public virtual void DoUpdate() {}

    public virtual void UpdatePhysics () {}

    protected virtual void OnTakeDamage(int dmg) { }

    protected virtual void OnDeath() { }
}
