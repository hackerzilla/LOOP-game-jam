using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public bool shouldFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFollow) {
            Vector3 new_pos = target.transform.position; 
            new_pos.z = transform.position.z;
            transform.position = new_pos;
        }
    }
}
