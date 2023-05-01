using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHitObject : MonoBehaviour
{

    public void destroyIt(float delay)
    {
        StartCoroutine(destroyObject(delay));

    }
    public IEnumerator destroyObject(float delay)
    {
        Destroy(this.gameObject.GetComponent<Rigidbody>());
        Destroy(this.gameObject.GetComponent<BoxCollider>());
        yield return new WaitForSeconds(delay);
        //Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            NoRigid();
        }
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
