using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackEffects : MonoBehaviour {

    public ParticleSystem system;
	
    public void UpdateEffects (bool thrust) {
        if (thrust && !system.isEmitting)
            system.Play();

        if (!thrust && system.isEmitting)
            system.Stop();
    }
}
