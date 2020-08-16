using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class event_control : MonoBehaviour
{
    public father script;
    // Start is called before the first frame update
    void Start()
    {
        
        
        GameObject.Find("map_test_empty").SetActive(false);
    }
    public void call(string stype)
    {
        //根据字符串传入相应事件脚本
        gameObject.AddComponent(System.Type.GetType(stype));
        script = gameObject.GetComponent(System.Type.GetType(stype))as father;
        /*
        switch (stype)
        {
            case "bar":  gameObject.AddComponent<bar>();
                script = gameObject.GetComponent<bar>();
                break;

            case "woman": gameObject.AddComponent<woman>();
                script = gameObject.GetComponent<woman>();
                break;
            case "magician":
                gameObject.AddComponent<magician>();
                script = gameObject.GetComponent<magician>();
                break;
            case "riverobject":
                gameObject.AddComponent<riverobject>();
                script = gameObject.GetComponent<riverobject>();
                break;


        }
        */
    }
    public void response(string num)
    {
        script.execute(num);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
