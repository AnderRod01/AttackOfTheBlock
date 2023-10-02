using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FollowCursor : MonoBehaviour
{

    public PlayerScriptableObject playerSO;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        playerSO.health = 3;
        _audioSource = this.gameObject.GetComponent<AudioSource>();   

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
        if (!screenRect.Contains(Input.mousePosition))
            return;
        mousePos.z = 0;
        transform.position = Vector3.Lerp(transform.position, mousePos, 0.15f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //-1 vida al colisionar con enemigo
        if (collision.gameObject.tag == "Enemy")
        {
            if (playerSO.health <= 0)
            {
                Application.Quit();
            }
            
            playerSO.health--;
            Debug.Log(playerSO.health);
        }
        
        //Destruir todos los enemigos al coger powerup
        if (collision.gameObject.tag == "Powerup")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            Destroy(GameObject.FindWithTag("Powerup"));
            Spawner._firstTime = true;
            this._audioSource.Play();
        }
    }
}
