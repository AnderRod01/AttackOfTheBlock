using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;
    public GameObject healthUp;
    private float spawnTimeEnemy = 3f;
    private float spawnTimePowerup = 10f;
    public static bool _firstTime = true;

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
	    if (_firstTime)
	    {
		    GameObject.Instantiate(enemy, new Vector2(4f, 4f), transform.rotation * Quaternion.Euler (0f, 0f, 15f));
		    GameObject.Instantiate(enemy, new Vector2(-4f, 4f), transform.rotation * Quaternion.Euler (0f, 0f, -15f));
		    _firstTime = false;
		    return;
	    }
	    
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
	    
	    
	    
	    float spawnY = Random.Range
		    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
	    float spawnX = Random.Range
		    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
	   
	    seed = Random.Range(0, 2);
	    Vector2 spawnPosition = new Vector2(spawnX, spawnY);
	    switch(seed)
	    {
		    case 0:
			    Instantiate(powerup, spawnPosition, Quaternion.identity);
			    break;
		    case 1:
			    Instantiate(healthUp, spawnPosition, Quaternion.identity);
			    break;
	    } 
    }
}
