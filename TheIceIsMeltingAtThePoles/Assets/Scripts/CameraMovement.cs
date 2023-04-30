using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject mainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FollowMainCharacter()
    {
        //Mathf.Clamp();

        yield return new WaitForSeconds(2);
    }

}
