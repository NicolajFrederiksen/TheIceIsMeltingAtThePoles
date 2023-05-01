using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPositionScript : MonoBehaviour
{
   
        private float initialZPosition;
        private Quaternion initialRotation;

        private void Start()
        {
            initialZPosition = transform.position.z;
            initialRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            Vector3 newPosition = transform.position;
            newPosition.z = initialZPosition;
            transform.position = newPosition;
            transform.rotation = initialRotation;
        }
    
}
