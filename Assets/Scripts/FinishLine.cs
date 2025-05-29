using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //adding Scene Managment to manipulate with scenes

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem FinishEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", 0.6f); //Method for delay, 1 position - method name, 2 - time

        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0); // Load Scene with index 0
    }
}
