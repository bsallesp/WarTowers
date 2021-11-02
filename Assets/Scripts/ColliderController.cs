using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{
    [SerializeField] Collider myCollider;

    private void Update()
    {
        IsOffSide();
        IsGameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Life>().Damage(other.GetComponent<Bullet>().damagePower);
        }

        if (other.CompareTag("Hero"))
        {
            if (other.transform.parent.name != "MouseDragHero")
            {
                gameObject.GetComponent<Life>().Damage(other.GetComponent<Life>().powerDamage);
                other.GetComponent<Life>().Damage(gameObject.GetComponent<Life>().powerDamage);
            }
        }
    }

    public void IsOffSide()
    {
        if (transform.position.x < -10)
        {
            gameObject.GetComponent<Life>().DestroyMe();
        }
    }

    public void IsGameOver()
    {
        if (transform.position.x > 10)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
