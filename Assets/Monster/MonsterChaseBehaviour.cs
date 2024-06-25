using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChaseBehaviour : MonoBehaviour
{
    public float speed = 1.0f; // Kecepatan gerakan monster
    public float avoidStrength = 0.5f; // Kekuatan penghindaran
    public float avoidDistance = 1.0f; // Jarak penghindaran

    private Transform player; // Transform pemain

    private void Start()
    {
        // Temukan objek pemain dengan tag "Player"
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Hitung arah menuju pemain
        Vector3 directionToPlayer = player.position - transform.position;

        // Hitung gaya penghindaran dari objek lain
        Vector3 avoidanceForce = Vector3.zero;
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, avoidDistance);
        foreach (var collider in nearbyColliders)
        {
            if (collider != this && collider.CompareTag("Obstacle"))
            {
                Vector3 avoidDirection = transform.position - collider.transform.position;
                avoidanceForce += avoidDirection.normalized * avoidStrength;
            }
        }

        // Gabungkan arah menuju pemain dan gaya penghindaran
        Vector3 finalDirection = directionToPlayer + avoidanceForce;

        // Gerakkan monster
        transform.Translate(finalDirection.normalized * speed * Time.deltaTime);
    }
}
