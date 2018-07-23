using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackUI : MonoBehaviour {

    public Image fuelReserveImage;

	void Start () {
		
	}

    public void DoUpdate(float fuel, float maxFuel) {

        UpdateHideCooldown(fuel);

        fuelReserveImage.fillAmount = fuel / maxFuel;
    }
    
    //Cooldown for how long the fuel amount stayed the same
    float idleCD = 0;

    float lastFuel;

    void UpdateHideCooldown (float fuel) {
        if (Mathf.Abs(fuel - lastFuel) < .1f)
            idleCD += Time.deltaTime;
        else {
            idleCD = 0f;
            if (!fuelReserveImage.enabled)
                fuelReserveImage.enabled = true;

            lastFuel = fuel;
        }

        if (idleCD > 3f && fuelReserveImage.enabled || fuel < .1f) {
            fuelReserveImage.enabled = false;
        }
    }
}
