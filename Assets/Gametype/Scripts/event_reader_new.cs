using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class event_reader_new : MonoBehaviour
{
    // Start is called before the first frame update
    public List<NewBehaviourScript1.Node> root;
    public NewBehaviourScript1.Node current_node;
    public GameObject[] answerlist = new GameObject[5];
    public GameObject says;

    void Start()
    {
        //NewBehaviourScript1.Node a = GameObject.Find("event_list").GetComponent<NewBehaviourScript1>().node[1];
        //get_event(GameObject.Find("eventlist").GetComponent<NewBehaviourScript1>().node[1]);
    }
    public void get_event(NewBehaviourScript1.Node node)
    {

        for (int i = 0; i < 5; i++)
        {
            answerlist[i] = GameObject.Find("answerslist").transform.GetChild(i).gameObject;
        }
        says = GameObject.Find("sayssecondbackground").transform.GetChild(0).gameObject;


        current_node = node;
        GameObject.Find("event_controller").GetComponent<event_control>().call(current_node.script_name);//获取事
        click_back();
    }
    public void click_back()
    {
        int ci = 0;
        foreach (GameObject x in answerlist)
        {
            x.GetComponent<event_sel_new>().node = null;
            x.GetComponent<event_sel_new>().node = new NewBehaviourScript1.Node();
        }

        foreach (GameObject x in answerlist)
        {
            x.GetComponent<event_sel_new>().flash();
        }

        if (current_node.NodeChilds != null)
        {
            foreach (NewBehaviourScript1.Node i in current_node.NodeChilds)
            {

                answerlist[ci].GetComponent<event_sel_new>().node = i;
                ci++;
            }
            foreach (GameObject x in answerlist)
            {
                x.GetComponent<event_sel_new>().showtext();
            }
        }
        //子节点为空时说明为结束选项
        else
        {
            GameObject.Find("answerslist").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "（结束）";
        }



        says.GetComponent<Text>().text = current_node.output;



    }
}
