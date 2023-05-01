using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotToHitObject : MonoBehaviour
{
    public float DelayTime;
    GameObject ThisObject;
    // Start is called before the first frame update
    void Start()
    {
        ThisObject = this.gameObject;
    }


    public void HitWrong()
    {
       StartCoroutine(RecalibrateObject(DelayTime));

    }
    public IEnumerator RecalibrateObject(float delay)
    {
        ThisObject.GetComponent<Rigidbody>().Sleep();
        yield return new WaitForSeconds(delay);
        ThisObject.GetComponent<Rigidbody>().WakeUp();


    }
}
