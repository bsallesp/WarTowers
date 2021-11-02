using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpotAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool nearestTurnOn = false;
    public int cCount;

    // Start is called before the first frame update
    void Start()
    {
        cCount = transform.childCount;

        for (int i  = 0; i == cCount; i++)
        {

        }
    }

    void OnMouseOver()
    {
        animator.Play("ReleaseMouseSquareSpot");
    }

    void OnMouseExit()
    {
        animator.Play("Idle");
    }

}
