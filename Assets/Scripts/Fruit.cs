using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    float originalY;

    public float floatStrength = 1;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0)
        {
            Destroy(gameObject);
          
        }
 
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
            transform.position.z);
    }
}
