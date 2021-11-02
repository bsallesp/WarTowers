using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaEnemy : MonoBehaviour
{
    [SerializeField] public float instaEnemyRate;
    [SerializeField] public float minEnemyRate;
    [SerializeField] public GameObject[] Enemies;
    
    private Vector3[] enemySpotMap = new Vector3[10];
    private float instaEnemyRateCountDown;

    private void Start()
    {
        instaEnemyRateCountDown = instaEnemyRate;;
        MapAllPos();
    }

    // Update is called once per frame
    void Update()
    {
        instaEnemyRateCountDown += (-1 * Time.deltaTime);
        if(instaEnemyRateCountDown <= 0)
        {
            InstaNewEnemy();

            instaEnemyRate -= 1;
            instaEnemyRateCountDown = instaEnemyRate;

            if (instaEnemyRateCountDown < minEnemyRate)
            {
                instaEnemyRateCountDown = minEnemyRate;
                instaEnemyRate = minEnemyRate;
            }
        }
    }

    private void InstaNewEnemy()
    {
        var randomPosition = Random.Range(0, enemySpotMap.Length);
        var randomEnemy = Random.Range(0, Enemies.Length);

        Instantiate(Enemies[randomEnemy], enemySpotMap[randomPosition], Quaternion.identity, transform);
    }

    private void MapAllPos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            enemySpotMap.SetValue(child.position, i);
        }
    }
}
