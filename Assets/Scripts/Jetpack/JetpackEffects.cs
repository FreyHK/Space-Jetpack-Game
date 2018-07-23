using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackEffects : MonoBehaviour {

    public ParticleSystem System;

    public void UpdateEffects (bool thrust) {
        if (thrust && !System.isEmitting)
            System.Play();

        if (!thrust && System.isEmitting)
            System.Stop();
    }
}
