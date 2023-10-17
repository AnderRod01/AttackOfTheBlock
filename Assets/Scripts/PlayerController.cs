using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController: MonoBehaviour
{
    private bool _isInvincible;
    [SerializeField] private float invincibilitySeconds; 
    public PlayerScriptableObject playerSO;
    private AudioSource _audioSource;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI healthUI;
    [SerializeField] private TextMeshProUGUI scoreUI;
    
    private float timer;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSO.health = 3;
        healthUI.text = "Health: <color=green>"+playerSO.health +"</color>";
        _audioSource = this.gameObject.GetComponent<AudioSource>();   

    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneController.isPaused)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
            if (!screenRect.Contains(Input.mousePosition))
                return;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.15f);
        }
        
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            score += 10;
            timer = 0;
            scoreUI.text = "Score: " + score;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //-1 vida al colisionar con enemigo
        if (collision.gameObject.tag == "Enemy")
        {
            if (_isInvincible)
            {
                return;
            }
            playerSO.health--;
           
            updateHealthUI();
            if (playerSO.health == 0)
            {
                ScoreController.SaveScore(score);
                gameOverMenu.SetActive(true);
                SceneController.isPaused = true;
                Time.timeScale = 0f;
            }

            StartCoroutine(BecomeTemporarilyInvincible());
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
        
        if (collision.gameObject.tag == "HealthUp")
        {
            if (playerSO.health < 3)
            {
                playerSO.health++;
            }
            updateHealthUI();
            Destroy(GameObject.FindWithTag("HealthUp"));
            this._audioSource.Play();
        }
    }
    
    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;

        yield return new WaitForSeconds(invincibilitySeconds);

        _isInvincible = false;
    }

    private void updateHealthUI()
    {
        switch (playerSO.health)
        {
            case 3:
                healthUI.text = "Health: <color=green>" + playerSO.health + "</color>";
                break;
            case 2:
                healthUI.text = "Health: <color=yellow>" + playerSO.health + "</color>";
                break;
            case 1:
                healthUI.text = "Health: <color=red>" + playerSO.health + "</color>";
                break;
            case 0:
                healthUI.text = "";
                break;
        }
    }
}
