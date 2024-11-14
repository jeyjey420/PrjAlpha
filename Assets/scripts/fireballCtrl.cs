using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCtrl : MonoBehaviour
{
    private Rigidbody rb;
    public float shootForce = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}




