using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class event_sel_new : MonoBehaviour,IPointerDownHandler
{
    // Start is called before the first frame update
    public NewBehaviourScript1.Node node;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DOWN!!!!!");
        if (transform.GetChild(0).GetComponent<Text>().text == "（结束）")
        {
            GameObject.Find("event_show").SetActive(false);
            return;
        }

        GameObject.Find("event_show").GetComponent<event_reader_new>().current_node = node;

        GameObject.Find("event_controller").GetComponent<event_control>().response(node.num);

        GameObject.Find("event_show").GetComponent<event_reader_new>().click_back();






    }
    public void showtext()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = node.msg;
    }
    public void flash()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = " ";
    }
}
