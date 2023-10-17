using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static List<int> ranking = new List<int>();
    

    public static void SaveScore(int score)
    {
        ranking.Add(score);
        ranking.Sort();
        ranking.Reverse();
    }
    
}
