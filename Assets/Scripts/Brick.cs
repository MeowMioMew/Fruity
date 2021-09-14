using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 3;
    public int points = 10;
    public Material hitMaterial;

    Material _orgMat;
    Renderer _renderer;
    public AudioSource _break;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _orgMat = _renderer.sharedMaterial;
        _break = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0)
        {
            StartCoroutine(Break(.5f));
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
        _break.Play();
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
