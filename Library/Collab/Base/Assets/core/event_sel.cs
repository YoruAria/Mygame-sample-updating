using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class event_sel : MonoBehaviour,IPointerDownHandler
{
    // Start is called before the first frame update
    public NewBehaviourScript1.Node node;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DOWN!!!!!");
        GameObject.Find("Canvas").GetComponent<event_reader>().current_node = node;
        GameObject.Find("GameObject").GetComponent<event_control>().response(node.num);
        GameObject.Find("Canvas").GetComponent<event_reader>().click_back();
        
        
    }
    public void showtext()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = node.msg;
    }
    public void flash()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = " ";
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    // Update is called once per frame

}
