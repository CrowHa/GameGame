using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationZ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float Speed = 2f;
    private void Update()
    {
        transform.Rotate(0, 0, 360*Speed * Time.deltaTime);
    }
}
