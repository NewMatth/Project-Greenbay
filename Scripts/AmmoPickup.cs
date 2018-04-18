using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    public float AmmoHealth = 1f;


    public void DeductHealth(float deductHealth)
    {
        AmmoHealth -= deductHealth;

        if(AmmoHealth <= 0) { AmmoDead(); }
    }
    void AmmoDead()
    {
        Destroy(gameObject);
    }
}
