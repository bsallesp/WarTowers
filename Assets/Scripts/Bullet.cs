using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float eForce;
    [SerializeField] Rigidbody myRb;
    [SerializeField] public int damagePower;

    void Start()
    {
        Run();
        Destroy(gameObject, 1);
    }

    private void Run()
    {
        myRb.AddForce(Vector3.right * -eForce);
    }
}
