using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] public float heroAttackRate;
    [SerializeField] public GameObject startAttackPos;
    [SerializeField] public GameObject bullet;

    public bool IsShootAllowed;
    
    float heroAttackRateCountDown;

    // Update is called once per frame
    void Update()
    {
        string FirstParentName = transform.parent.parent.parent.name;

        if (FirstParentName == "MouseDragHero")
        {
            IsShootAllowed = false;
        }
        else if (FirstParentName == "HeroesInGame")
        {
            IsShootAllowed = true;
        }

        heroAttackRateCountDown += (-1 * Time.deltaTime);

        if (heroAttackRateCountDown < 0)
        {
            Attack();
            heroAttackRateCountDown = heroAttackRate;
        }
        
    }

    public void Attack()
    {
        if (IsShootAllowed)
        {
            var bullet_ = Instantiate(bullet, startAttackPos.transform.position, Quaternion.identity, transform);
        }
    }
}
