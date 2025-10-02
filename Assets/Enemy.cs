using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float leftBound = 85.0f;
    [SerializeField] public float rightBound = 120.0f;
    [SerializeField] public float topBound = 20.0f;
    [SerializeField] public float bottomBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(leftBound, rightBound), Random.Range(bottomBound, topBound));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Die(1f);
        }
    }

    private void Die(float delay)
    {
        Destroy(this.gameObject, delay);
    }
}
