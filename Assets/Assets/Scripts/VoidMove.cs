using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMove : MonoBehaviour
{
    // adds constant movement to the void
    public Vector3 moveDirection;
    private Transform transf;

    void Start()
    {
        transf = gameObject.transform;
    }

    void Update()
    {
        Vector3 position = transf.position;
        position += moveDirection * Time.deltaTime;
        transf.position = position;
    }
}
