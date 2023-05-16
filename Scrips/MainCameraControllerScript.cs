using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControllerScript : MonoBehaviour
{
    [SerializeField] private Transform charactor;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(charactor.position.x, charactor.position.y, transform.position.z);
    }
}
