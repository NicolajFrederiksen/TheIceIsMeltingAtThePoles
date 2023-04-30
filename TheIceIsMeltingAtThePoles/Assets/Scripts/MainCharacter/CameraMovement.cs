using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject mainCharacter;
    Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter");
        CameraPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Invoke("followMC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void followMC(float delay)
    {
        StartCoroutine(FollowMainCharacter());

    }
    public IEnumerator FollowMainCharacter()
    {
        //Mathf.Clamp();

        yield return new WaitForSeconds(2);
    }

}
