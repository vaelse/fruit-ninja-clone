using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public GameObject bomb;
    
    private void Start()
    {
        StartCoroutine(SpawnFruitDelay());
    }

    private IEnumerator SpawnFruitDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            SpawnFruit();
        }
    }

    public void SpawnFruit ()
    {
        var ThurstUp = Random.Range(10f, 15f);
        var ThrustLeft = Random.Range(5f, 8f);
        var ThrustRight = Random.Range(5f, 8f);
        var bombSpawn = Random.Range(0, 100);

        GameObject spawnObject;
        if (bombSpawn < 25)
        {
            spawnObject = bomb;
        }
        else
        {
            spawnObject = ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)];
        }

        var insta = Instantiate(spawnObject, transform.position, transform.rotation);
        var _object = insta.GetComponent<Rigidbody2D>();
        _object.AddForce(transform.up * ThurstUp, ForceMode2D.Impulse);
        _object.AddForce(transform.right * ThrustLeft, ForceMode2D.Impulse);
        _object.AddForce(-transform.right *ThrustRight, ForceMode2D.Impulse);
        _object.transform.rotation = Random.rotation;
        Destroy(insta, 5f);
    }
}