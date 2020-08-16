using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riverobject : father
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public override void execute(string num)
    {
        if(num=="1")
        { Debug.Log("111111111111111111");
            
            int a=Random.Range(0,3);
            if (a <= 1)
                GameObject.Find("event_show").GetComponent<event_reader_new>().current_node.output = "你抓到了那个闪亮的东西";
            else
                GameObject.Find("event_show").GetComponent<event_reader_new>().current_node.output = "它流过的太快，你只免费洗了个澡";
        }
        
        
        if (num == "2")
            Debug.Log("222222222222222");
        if (num == "3")
            Debug.Log("3333333333");
        if (num == "4")
            Debug.Log("4444444444444");
        if (num == "5")
            Debug.Log("55555555555");
        if (num == "6")
            Debug.Log("66666666666");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
