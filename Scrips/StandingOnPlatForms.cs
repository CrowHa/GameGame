using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingOnPlatForms : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charactor")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charactor")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
