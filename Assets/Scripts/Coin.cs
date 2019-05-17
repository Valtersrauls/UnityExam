using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public AudioSource collectSound;

    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        GameManager.coinsLeft -= 1;
        Destroy(gameObject);

    }
}
