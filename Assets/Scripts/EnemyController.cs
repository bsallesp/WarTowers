using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float initSpeed;
    [SerializeField] public float maxSpeed;

    private void Start()
    {
        speed = initSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        speed += 0.02f;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void PainMakesMeBreak(int damageRecoil)
    {
        speed -= damageRecoil;
    }
}
