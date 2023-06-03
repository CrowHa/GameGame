using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollider : MonoBehaviour
{
    private int Cherries = 0;
    private int Bananas = 0;
    [SerializeField] private Text CherriesText;
    [SerializeField] private Text BananasText;
    [SerializeField] private AudioSource BanasAudioSource;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Cherry")) {
            BanasAudioSource.Play();
            Destroy(collision.gameObject);
            Cherries++;
            CherriesText.text = ("Cherries: " + Cherries);
          }

        else if (collision.gameObject.CompareTag("Bananas"))
        {
            BanasAudioSource.Play();
            Destroy(collision.gameObject);
            Bananas++;
            BananasText.text = ("Bananas: " + Bananas);
        }
    }
}
