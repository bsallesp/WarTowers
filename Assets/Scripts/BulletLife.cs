using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    [SerializeField] public GameObject spark;
    

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyMe();
            Instantiate(spark, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Wall"))
        {
            DestroyMe();
        }
    }
}
