using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class tilemap_eventcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public father script;
   public GameObject EventCanvas_prefab;
   public GameObject answerbutton_prefab;
    public GameObject quest_con;
  [SerializeField]  TileEventLoad.Node node;
    public hexmap_create mapcreat;
    // Start is called before the first frame update
    void Start()
    {

        
       // GameObject.Find("map_test_empty").SetActive(false);
    }
    public void call(string stype)
    {
        //根据字符串传入相应事件脚本
        gameObject.AddComponent(System.Type.GetType(stype));//反射
        script = gameObject.GetComponent(System.Type.GetType(stype)) as father;
        
    }
    public void response(string num)
    {
        script.execute(num);
    }
    GameObject EventCanvas;//整个事件窗口
    Transform im;//回答框父物体
    Transform show;//展示框
    father event_script;
    public void showevent(TileEventLoad.Node node)//第一次显示
    {
        quest_con.AddComponent(System.Type.GetType(node.script_name));
        event_script= gameObject.GetComponent(System.Type.GetType(node.script_name)) as father;
        mapcreat.iseventon = true;
        this.node = node;
        EventCanvas=  Instantiate(EventCanvas_prefab,mapcreat.mapfobj.transform);
        int answercount = node.NodeChilds.Count;
        im = EventCanvas.transform.Find("Answer/Image");
        show = EventCanvas.transform.Find("Show/Text");
        for(int i=0; i < answercount; i++)
        {
            GameObject an= Instantiate(answerbutton_prefab, im);
            an.transform.Find("Text").GetComponent<Text>().text = node.NodeChilds[i].msg;

        }
        show.GetComponent<Text>().text = node.output;
    }

    //点击回答后的响应
   
    public void answer_select(int index)
    {
        //index为第几个选项/第几个子节点
        node = node.NodeChilds[index];
        event_script.execute(node.num.ToString());
        int num = node.num;

        if (node.msg == "结束")
        {
            Destroy(EventCanvas);
            Destroy(event_script);
            mapcreat.iseventon = false;
        }

        if (node.NodeChilds == null)
        {
            TileEventLoad.Node endnode = new TileEventLoad.Node();
            endnode.msg = "结束";
            node.NodeChilds = new List<TileEventLoad.Node>();
            node.NodeChilds.Add(endnode);
        }


        int childCount = im.transform.childCount;
        show = EventCanvas.transform.Find("Show/Text");
        show.GetComponent<Text>().text = node.output;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(im.transform.GetChild(i).gameObject);
        }


        for (int i = 0; i < node.NodeChilds.Count; i++)
        {
            GameObject an = Instantiate(answerbutton_prefab, im);
            an.transform.Find("Text").GetComponent<Text>().text = node.NodeChilds[i].msg;
        }
    }
     
  
}

