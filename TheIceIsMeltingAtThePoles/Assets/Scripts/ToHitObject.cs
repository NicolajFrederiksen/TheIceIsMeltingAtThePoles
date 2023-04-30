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
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);

    }

}