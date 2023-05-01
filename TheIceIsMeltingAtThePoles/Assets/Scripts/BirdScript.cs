using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public float speed = 5.0f;
    private float distance = 30.0f;
    private int direction = 1;
    private Boolean hasRotated = false;

    void Update()
    {
        float newPosition = transform.position.x + (speed * Time.deltaTime * direction);
        if (Mathf.Abs(newPosition) > distance)
        {
            direction *= -1;
            newPosition = transform.position.x + (speed * Time.deltaTime * direction);
        }
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        if (direction == -1 && !hasRotated)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            hasRotated = true;
        }
        if (direction == 1 && hasRotated)
        {
            transform.Rotate(0.0f, -180.0f, 0.0f);
            hasRotated = false;
        }

    }
    
 }
