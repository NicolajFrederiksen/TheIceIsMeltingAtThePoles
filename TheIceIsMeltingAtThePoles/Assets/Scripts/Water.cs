using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool movement = true;
    public gameManager GameManager;
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }


    void Update()
    {
        if (movement)
        {
            transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "MainCharacter")
        {
            movement= false;
            Destroy(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
