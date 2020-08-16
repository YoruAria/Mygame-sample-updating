using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magician : father
{
    // Start is called before the first frame update
    Value propert;
    void Start()
    {
        propert = GameObject.Find("property").GetComponent<Value>();
    }
    public override void execute(string num)
    {
        if (num == "1")
            Debug.Log("1");
        if (num == "2")
            Debug.Log("2");
        if (num == "3")
            Debug.Log("3");
        if (num == "4")
            Debug.Log("4");
        if (num == "5")
            Debug.Log("5");
        if (num == "6")
            Debug.Log("6");
        if (num == "7")
            Debug.Log("7");
        if (num == "8")
            Debug.Log("8");
        if (num == "9")
            Debug.Log("9");
        if (num == "10")
            Debug.Log("10");
        if (num == "11")
            Debug.Log("11");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

