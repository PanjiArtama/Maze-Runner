using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGameOver : MonoBehaviour
{
    public float gameOverDistance = 1.0f; // Jarak minimum untuk game over
    private Transform monster; // Transform monster
    private bool gameIsOver = false; // Status game over

    private void Start()
    {
        // Temukan objek monster dengan tag "Monster"
        monster = GameObject.FindWithTag("Monster").transform;
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            // Hitung jarak antara player dan monster
            float distanceToMonster = Vector3.Distance(transform.position, monster.position);

            // Periksa apakah jarak lebih kecil dari jarak game over
            if (distanceToMonster < gameOverDistance)
            {
                // Panggil fungsi game over atau tindakan yang sesuai
                GameOver();
            }
        }

        // Logika lainnya seperti pergerakan player, dll.
    }

    private void GameOver()
    {
        gameIsOver = true;
        Debug.Log("Game Over! Kamu terlalu dekat dengan monster.");
        FindObjectOfType<SceneManagerScript>().LoadGameOverScene();
    }
}
