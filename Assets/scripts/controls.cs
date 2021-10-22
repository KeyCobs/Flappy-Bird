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

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            g_Moving.y = g_Speed;
            //print("Jump bird Jump: " + g_Speed);
        }
        g_Moving.y -= g_Gravity * Time.deltaTime;
        character.Move(g_Moving * Time.deltaTime);
    }
}
