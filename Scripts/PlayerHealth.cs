using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float CurrentHealth;
    public float MaxHealth = 100f;

    // Use this for initialization
    private void Awake()
    {
        singleton = this;
    }
    void Start ()
    {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayerDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
