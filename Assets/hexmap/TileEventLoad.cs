using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class TileEventLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public JsonData myjson;
    /// <summary>
    ///所有事件列表，根节点
    /// </summary>
    public List<Node> node;
    public string a;
    public Node secondNode;
    void search(Node root, int num)
    {
        if (root.num.Equals(num))
        {

            secondNode = root; return;

        }

        if (root.NodeChilds != null)
        {
            foreach (Node x in root.NodeChilds)
            {
                search(x, num);
            }
        }
    }
    void insert(Node root)
    {
        if (root != null)
        {
    
            root.msg = (string)myjson["message"][root.num];
            root.output = (string)myjson["showup"][root.num];

        }

        if (root.NodeChilds != null)
        {

            foreach (Node x in root.NodeChilds)
            {
                insert(x);
            }
        }
    }

    [System.Serializable]

    public class Node
    {
        public int num;//序号
        public string msg;//内容
        public string output;//输出内容
        public string script_name;//脚本名称
        public List<Node> NodeChilds;


    }

    //StreamReader sr = new StreamReader("Assets/Sample.txt");

    public string number;
    string[] letters;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        node = new List<Node>();
        var fileAddress = System.IO.Path.Combine(Application.streamingAssetsPath, "event/txt");

        string path = "Assets/event/txt";
        //FileInfo[] files = new DirectoryInfo(path).GetFiles("*.txt");
        FileInfo[] files = new DirectoryInfo(fileAddress).GetFiles("*.txt");

        foreach (FileInfo file in files)
        {
            Node newnode = new Node();

            //StreamReader sr = new StreamReader("Assets/event/txt/"+ file.Name);
            StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/event/txt/" + file.Name);
            print(file.Name);

            // StreamReader jsr = new StreamReader("Assets/myjsontest.json");

            //StreamReader jsr = new StreamReader("Assets/event/json/"+file.Name.Split('.')[0] + ".json");
            StreamReader jsr = new StreamReader(Application.streamingAssetsPath + "/event/json/" + file.Name.Split('.')[0] + ".json");
            string jsondata = jsr.ReadToEnd();
            myjson = JsonMapper.ToObject(jsondata);

            newnode.num = 0;
            newnode.script_name = (string)myjson["script"]["script_name"];


            string xxx = (string)myjson["script"]["script_name"];
            Debug.Log("wdasd:" + xxx);
            while ((number = sr.ReadLine()) != null)
            {
                Debug.Log(number);
                letters = number.Split(' ');

                search(newnode, int.Parse(letters[0]));//搜索父节点
                List<string> letterss = new List<string>(letters);
                letterss.RemoveAt(0);//保留需要插入的节点
                secondNode.NodeChilds = new List<Node>();
                foreach (string letter in letterss)
                {

                    Node a = new Node();
                    a.num = int.Parse(letter);
                    secondNode.NodeChilds.Add(a);
                }

            }
            insert(newnode);//根据json插入内容
            node.Add(newnode);

        }
    }
}
