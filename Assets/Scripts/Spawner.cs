using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;
    public float spawnTimeEnemy = 3f;
    public float spawnTimePowerup = 7f;
    private bool _firstTime = true;

    private int seed;
    
    // Use this for initialization
    void Start () {
	    InvokeRepeating ("SpawnPowerup", spawnTimePowerup, spawnTimePowerup);
	    InvokeRepeating("SpawnEnemy", spawnTimeEnemy, spawnTimeEnemy);
    }

    private void Update()
    {

    }


    private void SpawnEnemy()
    {
	    seed = Random.Range(0, 2);
	    switch(seed)
	    {
		    case 0:
			    GameObject.Instantiate(enemy, new Vector2(4f, 4f), transform.rotation * Quaternion.Euler (0f, 0f, 15f));
			    break;
		    case 1:
			    GameObject.Instantiate(enemy, new Vector2(-4f, 4f), transform.rotation * Quaternion.Euler (0f, 0f, -15f));
			    break;
	    } 
    	
    }

    private void SpawnPowerup()
    {
	    if (!_firstTime)
	    {
		    GameObject.Instantiate(powerup);
		    Debug.Log("spawn");
	    }
	    else
	    {
		    _firstTime = false;
		    Debug.Log("a");
	    }
    }
}
