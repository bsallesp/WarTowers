using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseDragReallocateHero : MonoBehaviour
{
    void OnMouseDown()
    {
        //Debug.Log("OnMouseDown");

        FindObjectOfType<MouseDragHero>().ObjectDragged = gameObject;
        FindObjectOfType<MouseDragHero>().targetObjectDragged = gameObject;
        FindObjectOfType<MouseDragHero>().IsObjSelected = true;
    }

    void OnMouseUp()
    {
        //Debug.Log("OnMouseUp");
        //Debug.Log(FindObjectOfType<MouseDragHero>().transform.GetChild(1).position);

        if (FindObjectOfType<HeroesInGameAdm>().IsBusy(FindObjectOfType<MouseDragHero>().transform.GetChild(1).position))
        {
            // do nothing
        }
        else
        {
            gameObject.transform.position = FindObjectOfType<MouseDragHero>().transform.GetChild(1).position;
            FindObjectOfType<MouseDragHero>().IsObjSelected = false;
        }
    }
}