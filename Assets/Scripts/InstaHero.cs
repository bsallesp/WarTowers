using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstaHero : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Vector3 mouseWorldPosition;

    [SerializeField] GameObject myObj;
    [SerializeField] GameObject heroesInGame;
    [SerializeField] GameObject mouseDragHero;
    [SerializeField] GameObject busy;

    Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Ended");

        if (FindObjectOfType<HeroesInGameAdm>().IsBusy(mouseDragHero.transform.GetChild(1).position))
        {
            //
        }
        else
        {
            var HeroPrice = mouseDragHero.transform.GetChild(0).GetComponent<Life>().price;
            var score = FindObjectOfType<Score>().GetScore();

            if (HeroPrice <= score)
            {
                FindObjectOfType<Score>().SetScore(-HeroPrice);
                mouseDragHero.transform.GetChild(1).SetParent(heroesInGame.transform);
                FindObjectOfType<MouseDragHero>().IsObjSelected = false;
            }
            else
            {
                Destroy(mouseDragHero.transform.GetChild(1));
                Destroy(mouseDragHero.transform.GetChild(0));
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);

        FindObjectOfType<MouseDragHero>().ObjectDragged = myObj;
        FindObjectOfType<MouseDragHero>().targetObjectDragged = myObj;
        FindObjectOfType<MouseDragHero>().IsObjSelected = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Mouse Up");

    }
}
