using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score;
    private static int playerHealth;
    public static int Score { get => score; set => score = value; }
    public static int PlayerHealth { get => playerHealth; set => score = playerHealth; }

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            score = 0;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
}
