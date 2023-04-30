using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool movement = true;
    public float moveSpeed = 1.0f;
    public Vector3 moveVector;
    public GameObject Player;
    void Start()
    {
        moveVector = new Vector3(0, 1, 0);
        Player = GameObject.FindGameObjectWithTag("MainCharacter");
    }


    void Update()
    {
        if (movement)
        {
          
            transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "MainCharacter")
        {
            movement = false;
            collision.gameObject.GetComponentInParent<MainCharacter>().Death();
        }
        if(collision.collider.tag == "Rope")
        {
            return;
        }
    }
}
