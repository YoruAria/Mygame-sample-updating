using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class event_load : MonoBehaviour
{
    // Start is called before the first frame update
    static public List<NewBehaviourScript1.Node> event_list;
    
    

    void Start()
    {
        
        
        
    }

    public void CreatLevelEvent()
    {
        event_list = new List<NewBehaviourScript1.Node>();
        event_list = this.GetComponent<NewBehaviourScript1>().node;
        Debug.Log(event_list.Count);
        foreach (Transform item in GameObject.Find("MainMap").transform)
        {
            item.GetComponent<MapInfo>().creat_event();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
