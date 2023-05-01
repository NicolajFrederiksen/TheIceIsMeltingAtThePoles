using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool movement = true;
    public float speed = 1.0f;
    public GameObject Player;
    //[SerializeField] private AudioSource DeathSound;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("MainCharacter");
    }


    void Update()
    {
        if (movement)
        {
            float distance = Player.transform.position.y - transform.position.y;
            float newSpeed = Mathf.Lerp(0, speed, distance / 10f);
            transform.Translate(Vector3.up * newSpeed * Time.deltaTime);
           
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "MainCharacter")
        {
            //DeathSound.Play();
            FindObjectOfType<AudioManager>().Play("DeathSound");
            movement = false;
            collision.gameObject.GetComponent<MainCharacter>().Death();
        }
        if(collision.collider.tag == "Rope")
        {
            return;
        }
    }
}
