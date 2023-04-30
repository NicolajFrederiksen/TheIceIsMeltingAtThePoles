using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    public float OffsetY, OffSetZ, transitionDuration;
    GameObject newRope;
    GameObject Camera;
    GameObject water;
    PointSystemScript points;
    public void Start()
    {
        newRope = Instantiate(ropePrefab, transform);
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        water = GameObject.Find("Water");
        points = GameObject.Find("PointImage").GetComponent<PointSystemScript>();
    }
    // this
    public GameObject ropePrefab;

    public void MovingToObject(Vector3 Targetposition)
    {
        float TransitionStartTime = Time.time;
        StartCoroutine(MoveParentObject(Targetposition, TransitionStartTime));
        Camera.GetComponent<CameraMovement>().followMC(Targetposition, TransitionStartTime, transitionDuration);
       // water.GetComponent<Water>().setTimer();

    }


    IEnumerator MoveParentObject(Vector3 targetPosition, float transitionStartTime)
    {
        // Get the initial position of the parent object
        Vector3 startPosition = transform.position;
        // Calculate the elapsed time since the start of the transition
        float elapsedTransitionTime = Time.time - transitionStartTime;

        // Calculate the interpolation factor based on the elapsed time and duration
        float t = Mathf.Clamp01(elapsedTransitionTime / transitionDuration);

        Destroy(newRope);
        // Gradually move the parent object towards the target position
        while (t < 1.0f)
        {
            // Calculate the new position of the parent object using SmoothStep
            Vector3 newPosition = new Vector3(
                Mathf.SmoothStep(startPosition.x, targetPosition.x, t),
                Mathf.SmoothStep(startPosition.y, targetPosition.y + OffsetY, t),
                Mathf.SmoothStep(startPosition.z, targetPosition.z + OffSetZ, t)
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
        transform.position = new Vector3(targetPosition.x, targetPosition.y + OffsetY, targetPosition.z + OffSetZ);
        // this
        newRope = Instantiate(ropePrefab, transform);
    }
    public void Death()
    {
        points.GetResult();
        Destroy(this.gameObject);
        SceneManager.LoadScene("EndScene");
    }
}
