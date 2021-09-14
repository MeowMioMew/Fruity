using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public int hits = 1;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material _orgMat;
    Renderer _renderer;
    AudioSource _crack;

    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        _renderer = GetComponent<Renderer>();
        _orgMat = _renderer.sharedMaterial;
        _crack = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0)
        {
            StartCoroutine(Break(.7f)); 


        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMat;
    }

    public IEnumerator Break(float t)
    {
        _crack.Play();
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
