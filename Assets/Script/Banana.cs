using UnityEngine;

public class Banana : MonoBehaviour
{
    public GameObject SlicedFruit;
    public void CreateSlicedFruit()
    {
        var slicedBanana = Instantiate(SlicedFruit, transform.position, transform.rotation);
        var Slicedrb = slicedBanana.GetComponentsInChildren<Rigidbody>();

        foreach (var r in Slicedrb)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(100, 500), transform.position, 2f);
        }

        FindObjectOfType<GameManager>().IncreaseScore(3);
        Destroy(gameObject);
        Destroy(slicedBanana, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateSlicedFruit();
    }
}
