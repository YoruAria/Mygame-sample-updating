using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public string mapTag;
    public NewBehaviourScript1.Node event_node;
    public bool isFirstOrLast = false;
    
   

    void Awake()
    {
       
        
    }
    public void creat_event()
    {
        event_node = event_load.event_list[Random.Range(0, event_load.event_list.Count)];
        
        
    }
}
