using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region GameManager
    private GameManager gm;
    #endregion
    #region SpawnBounds
    [SerializeField] public float leftBound = 85.0f;
    [SerializeField] public float rightBound = 120.0f;
    [SerializeField] public float topBound = 20.0f;
    [SerializeField] public float bottomBound = -15.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
            Die();
        }
    }

    private void Die()
    {
        gm.AddScore();
        Destroy(this.gameObject, 2f);
    }
}
