using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : father
{
    // Start is called before the first frame update
    Value property ;
    void Start()
    {
        property = GameObject.Find("property").GetComponent<Value>();
    }
    public override void execute(string num)
    {
        if(num=="1")
        { Debug.Log("111111111111111111");
            property.money--;

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
