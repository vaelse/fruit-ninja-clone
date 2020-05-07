using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public GameObject bomb;
    


    private void Start()
    {
        StartCoroutine(SpawnFruit());
    }
    // Update is called once per frame
   


    private IEnumerator SpawnFruit()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            CreateOrange();
        }
    }

    public void CreateOrange ()
    {
        float ThurstUp = Random.Range(10f, 15f);
        float ThrustLeft = Random.Range(5f, 8f);
        float ThrustRight = Random.Range(5f, 8f);

        GameObject go = null;
        float p = Random.Range(0, 100);
        if(p < 50)
        {
            go = bomb;
        }
        else
        {
            go = ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)];
        }

        GameObject insta = Instantiate(go, transform.position, transform.rotation);
        Rigidbody2D _object = insta.GetComponent<Rigidbody2D>();
        _object.AddForce(transform.up * ThurstUp, ForceMode2D.Impulse);
        _object.AddForce(transform.right * ThrustLeft, ForceMode2D.Impulse);
        _object.AddForce(-transform.right *ThrustRight, ForceMode2D.Impulse);
        Destroy(insta, 5f);
    }

}
