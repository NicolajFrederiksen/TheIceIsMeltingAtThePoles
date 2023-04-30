using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject mainCharacter;
    Vector3 CameraPosition;
    public Action McMoved;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter");
        CameraPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void followMC(Vector3 targetPosition, float transitionStartTime, float transitionDuration)
    {
        StartCoroutine(FollowMainCharacter(targetPosition, transitionStartTime, transitionDuration));

    }
    public IEnumerator FollowMainCharacter(Vector3 targetPosition, float transitionStartTime, float transitionDuration)
    {
        yield return new WaitForSeconds(0.05f);

        Vector3 startPosition = transform.position;
        float elapsedTransitionTime = Time.time - transitionStartTime;

        // Calculate the interpolation factor based on the elapsed time and duration
        float t = Mathf.Clamp01(elapsedTransitionTime / transitionDuration);

        // Gradually move the parent object towards the target position
        while (t < 1.0f)
        {
            // Calculate the new position of the parent object using SmoothStep
            Vector3 newPosition = new Vector3(
                Mathf.SmoothStep(startPosition.x, targetPosition.x + CameraPosition.x, t),
                Mathf.SmoothStep(startPosition.y, targetPosition.y + CameraPosition.y, t),
                Mathf.SmoothStep(startPosition.z, targetPosition.z + CameraPosition.z, t)
            );

            // Set the position of the parent object
            transform.position = newPosition;

            // Update the elapsed time and interpolation factor
            elapsedTransitionTime = Time.time - transitionStartTime;
            t = Mathf.Clamp01(elapsedTransitionTime / transitionDuration);

            // Wait for the next frame
            yield return null;
        }

        // Set the final position of the parent object to ensure accuracy
        transform.position = new Vector3(targetPosition.x + CameraPosition.x, targetPosition.y + CameraPosition.y, targetPosition.z + CameraPosition.z);
    }

}
