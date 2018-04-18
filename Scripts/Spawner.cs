using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Spawnee;
    public bool StopSpawning = false;
    public float spawntime;
    public float spawndelay;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", spawntime, spawndelay);
	}
	
	// Update is called once per frame
	public void SpawnObject()
    {
        Instantiate(Spawnee, transform.position, transform.rotation);
        if (StopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
