using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,1.5f * Time.deltaTime);

        Vector3 diff = transform.position - Vector3.zero;

        if(diff.magnitude>10)
        {
                Destroy(gameObject);
        }
    }
}
