using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] public int life;
    [SerializeField] public int price;
    [SerializeField] public int powerRecoil;
    [SerializeField] public int powerDamage;
    [SerializeField] public GameObject lifeBar;
    [SerializeField] public GameObject sparkDestroy;

    public void Damage(int damage)
    {
        life -= damage;
        AmIDead();
        InstaLifeBar(life);

        if (gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<EnemyController>().PainMakesMeBreak(damage);
        }
    }

    public void AmIDead()
    {
        if (life <= 0)
        {
            DestroyMe();
        }
    }
    
    public void DestroyMe()
    {
        Destroy(gameObject);
        var sparkDestroy_ = Instantiate(sparkDestroy, transform.position, Quaternion.identity);
        Destroy(sparkDestroy, 5);
        FindObjectOfType<Score>().SetScore(price);
    }

    private void InstaLifeBar(int life_)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("LifeBar"))
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        var lifebar_ = Instantiate(lifeBar, transform);

        var lifeBarScale = new Vector3(life_ / 10, lifebar_.transform.position.y / 10, lifebar_.transform.position.z / 10);
        lifebar_.transform.localScale = lifeBarScale;
        lifebar_.transform.position += new Vector3(0, 2.5f, 0);
        Destroy(lifebar_, 3);
    }
}
