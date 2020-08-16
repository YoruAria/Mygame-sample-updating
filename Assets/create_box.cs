using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class create_box : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mbk;
    public GameObject canvas;
    public List<NewBehaviourScript1.Node> event_list;

   
    public struct box
    {
        public GameObject bk;
        public int x;
        public int y;
    }
    public box[,] my_box;
    public int mx = 6;
    public int my = 6;
    void Start()
    {
        event_list = new List<NewBehaviourScript1.Node>();
        event_list = GameObject.Find("GameObject").GetComponent<NewBehaviourScript1>().node;

        for (int i = 0; i < my; i++)
        {
            for (int j = 0; j < mx; j++)
            {
                
                //Debug.Log(my_box[i, j]);
                GameObject obj = Instantiate(mbk);
                obj.GetComponent<event_block>().A = canvas;
                obj.transform.parent = this.transform;
                my_box[i, j].bk = obj;
                obj.GetComponent<event_block>().i = i;
                obj.GetComponent<event_block>().j = j;
                obj.GetComponent<event_block>().enabled = false;
                
                obj.transform.localPosition = new Vector3((i-5f)*75, (j-2.5f)*75 , 0);
                NewBehaviourScript1.Node cnode = event_list[Random.Range(0, event_list.Count)];
                obj.GetComponent<event_block>().event_node = cnode;
                my_box[i, j].x = j;
                my_box[i, j].y = i;
                if (i == 5 && j == 0) obj.GetComponent<event_block>().enabled = true;//测试：右下角起始点
            }

        }


    }
    void Awake()
    {
        my_box = new box[mx, my];
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            //Debug.Log("esc");
            Application.Quit();
            
        }
    }
}


