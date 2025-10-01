using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseMe : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(GetComponent<HingeJoint2D>());
            Camera.main.GetComponent<Follow>().shouldFollow = true;
        }
    }
}
