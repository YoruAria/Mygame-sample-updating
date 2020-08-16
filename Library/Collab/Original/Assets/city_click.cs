using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class city_click : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    
    public void OnPointerDown(PointerEventData eventData)
    {
        for(int i=0; i<transform.parent.childCount;i++)
        {
            transform.parent.GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
            transform.parent.GetChild(i).GetComponent<city_click>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        //Debug.Log(gameObject.GetComponent<cityconnect>().selfinfo.connection_point.Count);
        foreach (int i in gameObject.GetComponent<cityconnect>().selfinfo.connection_point)
        {
            transform.parent.GetChild(i).GetComponent<SpriteRenderer>().color = Color.blue;
            transform.parent.GetChild(i).GetComponent<city_click>().enabled = true;
        }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
