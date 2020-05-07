using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public GameObject SlicedFruit;
    public ParticleSystem[] SlicedSplash;

    public void CreateSlicedFruit()
    {
       GameObject insta = Instantiate(SlicedFruit, transform.position, transform.rotation);
        Rigidbody[] Slicedrb = insta.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in Slicedrb)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(100,500), transform.position, 2f);
        }

        FindObjectOfType<GameManager>().IncreaseScore(2);
        Destroy(gameObject);
        Destroy(insta, 2f);

    }

    public void CreateSplash()

    {
        ParticleSystem splash = null;
        splash = SlicedSplash[Random.Range(0, SlicedSplash.Length)];
        ParticleSystem Splash = Instantiate(splash, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        blade b = collision.GetComponent<blade>();

        if (!b)
        {
            return;
        }
        CreateSplash();
        CreateSlicedFruit();
    }
}
