using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class city_click : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public  GameObject Window ;
    public bool iscenter;
    public GameObject detail;
    // Start is called before the first frame update
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (citys_create.isopen == true)
        {

            if (iscenter == false)
            {
                Debug.Log("jahaha");

                citys_create.isopen = false;
                openCityMenu();
            }
            else
            {
                GameObject d = Instantiate(detail);
                
                d.transform.Find("Panel/CityName").GetChild(0).GetComponent<Text>().text = GetComponent<cityinfo>().cityname;
                citys_create.isopen = true;
            }
        }
        
        

    }

    // Update is called once per frame
    private void openCityMenu()
    {
        GameObject a;
        
        //Window.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = this.GetComponent<cityinfo>().cityname;
        a = Instantiate(Window,this.transform,true);
        
        a.transform.Find("flowsystem/nameofthecity").GetChild(0).GetComponent<Text>().text = gameObject.GetComponent<cityinfo>().cityname;
        a.transform.position = this.transform.position;
        
    }
    public void controlcontrolclick()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
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
            transform.parent.GetChild(i).GetComponent<city_click>().iscenter = false;
        }
        transform.GetComponent<city_click>().enabled = true;
        transform.GetComponent<city_click>().iscenter = true;

    }
}
