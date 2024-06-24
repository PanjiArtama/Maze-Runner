using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        // Nitrous
        if(Input.GetKeyDown(KeyCode.N))
        {
            speed+=5;
        }

        if(transform.position.z <= 30)
        {
            print("finish");
        }
        // Destroy Objec
        
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate( 0, mouseX * speed, 0);
        // Kontrol Mouse
        

        Movements();
    }

    void Movements()
    {
         // Kanan
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        // Kiri
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime , 0, 0);
        }
        // Depan
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        // Belakang
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-speed * Time.deltaTime);
        }
        // Atas
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0,speed * Time.deltaTime,0);
        }
        // Bawah
        if(Input.GetKey(KeyCode.E))
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
    }
}
