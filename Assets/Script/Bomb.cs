using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{

    public ParticleSystem explosion;
  


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string SceneName = FindObjectOfType<GameManager>().GetCurrentScene();

        blade b = collision.GetComponent<blade>();

        if (!b)
        {
            return;
        }

        if(SceneName == "TimeMode")
        {
            FindObjectOfType<GameManager>().OnBombHitTimeMode();
        }
        else if  (SceneName == "SurvivalMode")
        {
            FindObjectOfType<GameManager>().OnBombHitSurvival();
        }

        Instantiate(explosion, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
