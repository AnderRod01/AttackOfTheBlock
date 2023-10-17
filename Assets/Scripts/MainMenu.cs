using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI top5;

    void Start()
    {
        GetTop5();
    }

    private void GetTop5()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == ScoreController.ranking.Count)
            {
                return;
            }
            int score = ScoreController.ranking.ElementAt(i);
            top5.text = top5.text + "\n - " + score;
        }
    }
}
