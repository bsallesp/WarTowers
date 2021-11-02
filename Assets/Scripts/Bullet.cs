using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float eForce;
    [SerializeField] Rigidbody myRb;
    [SerializeField] public int damagePower;

    // Start is called before the first frame update
    void Start()
    {
        Run();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Run()
    {
        myRb.AddForce(Vector3.right * -eForce);
    }
}
