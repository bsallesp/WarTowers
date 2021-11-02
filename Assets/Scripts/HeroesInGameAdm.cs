using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesInGameAdm : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public bool IsBusy(Vector3 position)
    {
        bool isBusy = false;

        for (int i  = 0; i < transform.childCount; i++)
        {

            //Debug.Log("Heroes!!! " + transform.GetChild(i).transform.position + " / " + position);

            if (transform.GetChild(i).transform.position == position)
            {
                //Debug.Log(transform.GetChild(i).transform.position + " / " + position);
                isBusy = true;
            }
        }
        return isBusy;
    }
}
