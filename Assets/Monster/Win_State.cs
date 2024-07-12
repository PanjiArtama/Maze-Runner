using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_State : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Jika pemain mencapai titik menang, tampilkan scene Win_Scene
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinScene"); // Ganti dengan nama scene yang sesuai
        }
    }
}

