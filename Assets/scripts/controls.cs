using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    CharacterController character;
    [SerializeField]
    float g_Speed;
    float g_Gravity = 9.8f;
    Vector3 g_Moving = Vector3.zero;   
    // Start is called before the first frame update
    void Start()
    {
        character  = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (isGameOver())
        {
            Vector3 reset = new Vector3(-4.0f,1.0f, 0.0f);
            transform.position = reset;
            
        }

    }

    void MovePlayer()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            g_Moving.y = g_Speed;
            //print("Jump bird Jump: " + g_Speed);
        }
        g_Moving.y -= g_Gravity * Time.deltaTime;
        character.Move(g_Moving * Time.deltaTime);
    }
    bool isGameOver()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            return true;
        }
        else if (/*Pipe Colission*/ false)
        {
            return true;
        }

        return false;
    }
}
