using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class answer_trigger : MonoBehaviour, IPointerClickHandler
{
    tilemap_eventcontroller con;
    // Start is called before the first frame update
    void Start()
    {
        con = GameObject.Find("quest_con").GetComponent<tilemap_eventcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void OnPointerClick(PointerEventData eventData)
    {
      
       int index= transform.GetSiblingIndex();
        con.answer_select(index);
    }
}
