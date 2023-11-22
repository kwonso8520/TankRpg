using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
