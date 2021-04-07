using UnityEngine;

public class Orange : MonoBehaviour
{
    public GameObject SlicedFruit;
    public ParticleSystem[] SlicedSplash;
    public AudioClip SlashSound;

    public void CreateSlicedFruit()
    {
        var insta = Instantiate(SlicedFruit, transform.position, transform.rotation);
        var Slicedrb = insta.GetComponentsInChildren<Rigidbody>();
        foreach (var slice in Slicedrb)
        {
            slice.transform.rotation = Random.rotation;
            slice.AddExplosionForce(Random.Range(100, 500), transform.position, 2f);
        }
        FindObjectOfType<GameManager>().IncreaseScore(4);
        Destroy(gameObject);
        Destroy(insta, 2f);
    }

    public void CreateSplash()
    {
        var splash = SlicedSplash[Random.Range(0, SlicedSplash.Length)];
        Instantiate(splash, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateSplash();
        CreateSlicedFruit();
    }
}
