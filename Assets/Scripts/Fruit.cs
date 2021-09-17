using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    float originalY;

    public float floatStrength = 1;
    AudioSource _source;

    void Start()
    {
        this.originalY = this.transform.position.y;
        _source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0)
        {
            StartCoroutine(Break(.4f));

        }
 
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
            transform.position.z);
    }

    public IEnumerator Break(float t)
    {
        _source.Play();
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
