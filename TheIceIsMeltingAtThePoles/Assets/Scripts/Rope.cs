using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float degreesPerSecond = 10.0f;

    private Vector3 LocalLengthenDirection;
    private Vector3 objectAngles;
    MainCharacter ParentMainCharacter;
    public bool RopeThrown;
    public bool positive = true;
    public float scaleSpeed, maxUpwardMovement;
    public float maxYScale;
    public float moveSpeed;
    public bool collidedWithToHit, collidedWithY;

    // Start is called before the first frame update
    void Start()
    {
        objectAngles = new Vector3(0, 0, 1);
        LocalLengthenDirection = new Vector3(0, 1, 0);
        ParentMainCharacter = GetComponentInParent<MainCharacter>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RopeThrown = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            RopeThrown = false;
        }
        if (RopeThrown)
        {
            ThrowRope();
        }
        if (!RopeThrown)
        {
            RopeRotateAroundMC();
        }
    }

    public void RopeRotateAroundMC()
    {
        if (!RopeThrown)
        {
            if (transform.rotation.z >= 0.55)
            {
                if (positive)
                {
                    degreesPerSecond *= -1;
                    positive = false;
                }
            }
            else if (transform.rotation.z <= -0.55)
            {
                if (!positive)
                {
                    degreesPerSecond *= -1;
                    positive = true;
                }

            }
            transform.RotateAround(transform.parent.position, objectAngles, degreesPerSecond * Time.deltaTime);
        }
    }

    public void ThrowRope(){

        float currentScaleY = transform.localScale.y;
        float currentPositionY = transform.position.y;

        // Increase the scale of the object in the Y direction
        float newScaleY = currentScaleY + (scaleSpeed * Time.deltaTime);

        // Clamp the Y scale to the maximum value and only allow positive scale values
        newScaleY = Mathf.Clamp(newScaleY, 0f, maxYScale);

        // Calculate the difference between the new and current Y scale
        float scaleDelta = newScaleY - currentScaleY;

        // Move the object upward by a distance proportional to the scale delta
        float upwardMovement = Mathf.Lerp(0f, maxUpwardMovement, scaleDelta / maxYScale);
        transform.position += transform.up * upwardMovement;

        // Set the new local scale of the object, only affecting the Y component
        transform.localScale += new Vector3(0f, scaleDelta, 0f);

        // Clamp the object's upward movement to the maximum value
        float TargetPositionY = transform.position.y;
        TargetPositionY = Mathf.Clamp(TargetPositionY, currentPositionY, currentPositionY + maxUpwardMovement);
        transform.position = new Vector3(transform.position.x, TargetPositionY, transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        // Check the tag of the colliding object
        if (collision.gameObject.CompareTag("ToHit"))
        {
            NoRigid();
            collidedWithToHit = true;
            Vector3 TargetPosition = collision.gameObject.transform.position;
            ParentMainCharacter.MovingToObject(TargetPosition);
        }
        else if (collision.gameObject.CompareTag("ObjectY"))
        {
            collidedWithY = true;
        }
    }
    public void NoRigid()
    {
        this.GetComponent<Collider>().isTrigger = true;
    }
}
