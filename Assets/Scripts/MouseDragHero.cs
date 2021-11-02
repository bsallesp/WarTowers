using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragHero : MonoBehaviour
{
    public Vector3 mouseWorldPosition;
    public bool IsObjSelected;
    
    Plane plane;
    [SerializeField] public GameObject ObjectDragged; // the hero that come from canvas to worldspace.
    [SerializeField] public GameObject targetObjectDragged; // the same object above, in nearest target position, using alpha 50%.

    float distance;

    private void Start()
    {
        plane = new Plane(Vector3.up, 0);
        IsObjSelected = false;
    }

    private void Update()
    {
        MousePos();
        if (Input.GetMouseButtonUp(0) & IsObjSelected)
        {
            IsObjSelected = false;
        }

        if (transform.childCount > 0 & !IsObjSelected)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void MousePos()
    {
        if (IsObjSelected)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                mouseWorldPosition = ray.GetPoint(distance);

                if (transform.childCount == 0)
                {
                    var nearestSpot = FindObjectOfType<HeroSpawn>().GetNearestSpot(mouseWorldPosition);
                    var instaObjectDragged = Instantiate(ObjectDragged, mouseWorldPosition, Quaternion.identity, transform);
                    var instatargetObjectDragged = Instantiate(targetObjectDragged, nearestSpot, Quaternion.identity, transform);

                    //Setting the name:
                    instatargetObjectDragged.name = (FindObjectOfType<HeroesInGameAdm>().transform.childCount + 1).ToString();

                    Color color = instaObjectDragged.transform.GetChild(0).GetComponent<Renderer>().material.color;
                    color.a = 0.1f;
                    instaObjectDragged.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
                    
                }
                else
                {
                    transform.GetChild(0).position = mouseWorldPosition;
                    transform.GetChild(1).position = FindObjectOfType<HeroSpawn>().GetNearestSpot(mouseWorldPosition);
                }
            }
        }
    }
}
