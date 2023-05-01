using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float degreesPerSecond;
    public float MaxDegreesRotationAroundMC = 0.55f;
    public float scaleSpeed, maxMovement, MaxYScale, MinScale, DestroyTimeDelay;
    private Vector3 objectAngles;
    private bool Retract, Throwing, RopeThrown, positive = true;
    private float currentScaleY, currentPositionY;
    MainCharacter ParentMainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        objectAngles = new Vector3(0, 0, 1);
        ParentMainCharacter = GetComponentInParent<MainCharacter>();
        currentScaleY = transform.localScale.y;
        currentPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (RopeThrown)
        {
            ThrowRope();
        }
        if (!Throwing && !Retract)
        {
            RopeRotateAroundMC();
        }


        if (Input.GetMouseButtonDown(0))
        {
            Throwing = true;
            Retract = false;
            RopeThrown = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Throwing = false;
            Retract = true;
            RopeThrown = true;
        }

    }

    public void RopeRotateAroundMC()
    {
        if (transform.rotation.z >= MaxDegreesRotationAroundMC)
        {
            if (positive)
            {
                degreesPerSecond *= -1;
                positive = false;
            }
        }
        else if (transform.rotation.z <= -MaxDegreesRotationAroundMC)
        {
            if (!positive)
            {
                degreesPerSecond *= -1;
                positive = true;
            }

        }
        transform.RotateAround(transform.parent.position, objectAngles, degreesPerSecond * Time.deltaTime);

    }

    public void ThrowRope()
    {
        currentScaleY = transform.localScale.y;
        currentPositionY = transform.position.y;
        if (transform.localScale.y >= MaxYScale || Input.GetKeyDown(KeyCode.Return))
        {
            Retract = true;
            Throwing = false;


        }
        if (transform.localScale.y <= MinScale)
        {
            Retract = false;
        }

        if (Retract)
        {

            // Decrease the scale of the object in the Y direction
            float newScaleYD = currentScaleY - (scaleSpeed * Time.deltaTime);

            // Clamp the Y scale to the minimum value and only allow positive scale values
            newScaleYD = Mathf.Clamp(newScaleYD, MinScale, MaxYScale);

            // Calculate the difference between the new and current Y scale
            float scaleDelta = newScaleYD - currentScaleY;
            // Move the object downward by a distance proportional to the scale delta
            float downwardMovement = Mathf.Lerp(0f, maxMovement, -scaleDelta / MaxYScale);
            this.transform.position -= transform.up * downwardMovement;

            // Set the new local scale of the object, only affecting the Y component   
            transform.localScale += new Vector3(0f, scaleDelta, 0f);

            // Clamp the object's downward movement to the maximum value
            float TargetPositionYD = transform.position.y;
            TargetPositionYD = Mathf.Clamp(TargetPositionYD, currentPositionY - maxMovement, currentPositionY);
            transform.position = new Vector3(transform.position.x, TargetPositionYD, transform.position.z);
        }
        if (Throwing)
        {
            {   print("something");
                // Increase the scale of the object in the Y direction
                float newScaleY = currentScaleY + (scaleSpeed * Time.deltaTime);

                // Clamp the Y scale to the maximum value and only allow positive scale values
                newScaleY = Mathf.Clamp(newScaleY, MinScale, MaxYScale);

                // Calculate the difference between the new and current Y scale
                float scaleDelta = newScaleY - currentScaleY;

                // Move the object upward by a distance proportional to the scale delta
                float upwardMovement = Mathf.Lerp(0f, maxMovement, scaleDelta / MaxYScale);
                this.transform.position += transform.up * upwardMovement;

                // Set the new local scale of the object, only affecting the Y component
                transform.localScale += new Vector3(0f, scaleDelta, 0f);

                // Clamp the object's upward movement to the maximum value
                float TargetPositionY = transform.position.y;
                TargetPositionY = Mathf.Clamp(TargetPositionY, currentPositionY, currentPositionY + maxMovement);
                transform.position = new Vector3(transform.position.x, TargetPositionY, transform.position.z);
            }
        }
        if (!Retract && !Throwing)
        {
            RopeThrown = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        // Check the tag of the colliding object

        if (collision.gameObject.CompareTag("ToHit"))
        {
            NoRigid();
            collision.gameObject.GetComponent<ToHitObject>().destroyIt(DestroyTimeDelay);
            Vector3 TargetPosition = collision.gameObject.transform.position;
            ParentMainCharacter.MovingToObject(TargetPosition);
        }
        else if (collision.gameObject.CompareTag("NotToHit"))
        {
            NoRigid();
            StartCoroutine(HitWrongTarget(collision.gameObject.GetComponent<NotToHitObject>().DelayTime));
            collision.gameObject.GetComponent<NotToHitObject>().HitWrong();
        }
    }

    public IEnumerator HitWrongTarget(float TimeDelay)
    {
        RopeThrown = false;
        yield return new WaitForSeconds(TimeDelay);
        RopeThrown = true;
        Throwing = false;
        Retract = true;
        Rigid();


    }
    public void NoRigid()
    {
        this.GetComponent<Collider>().isTrigger = true;
    }
    public void Rigid()
    {
        this.GetComponent<Collider>().isTrigger = false;
    }
}
