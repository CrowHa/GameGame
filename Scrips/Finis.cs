using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource MusicFis;
    [SerializeField] private Text textfins;
    private bool levelday = false;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charactor" && !levelday)
        {
            MusicFis.Play();
            levelday = true;
            Invoke("CompleteLevel", 2f);
            textfins.enabled = true;
        }


    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
