using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointSystemScript : MonoBehaviour
{
    public TMP_Text pointText;
    private float points = 0;
    public float pointsManipulator = 10.0f;
    public GameObject character;

    private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = character.transform.position;
    }

    private void Update()
    {
        if (character != null)
        {
            if (previousPosition != character.transform.position)
            {
                float deltaYPosition = character.transform.position.y - previousPosition.y;
                AddPoints(deltaYPosition*pointsManipulator);
                previousPosition = character.transform.position;
            }
        }
    }

    public void AddPoints(float amount)
    {

        points += amount;
        pointText.text = ((int)points).ToString();
    }
    
    public void GetResult()
    {
        PlayerPrefs.SetString("points", ((int)points).ToString());
    }


}