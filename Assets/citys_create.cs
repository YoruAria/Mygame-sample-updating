using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citys_create : MonoBehaviour
{
    public static bool isopen = true;
    
    int h = 1;
    public int citysnum = 15;
    public float point_distance = 1.5f;
    public bool isdone = false;
    //public int smallcitysnum;
    //public float howfarawaytocountry;
    //public float smallpoint_distance;
    public List<Transform> countryspos = new List<Transform>();//所有生成的点
    List<string> names = new List<string>{ "齐齐哈尔", "哈尔滨", "杭州", "青岛", "上海", "北京", "天津", "南京", "西安", "新疆" };
    [System.Serializable]
    public struct countrys
    {
        public int selfnum;//城市编号
        public float[] far;
        public int[] farnum;
        public int othernum;
        public Transform otherpos;
        public List<int> connection_point;
    }
    public void connect_back(List<Transform> x) {
        foreach(Transform t in x)
        {
            int i= t.GetComponent<cityconnect>().selfinfo.connection_point[0];
            transform.GetChild(i).GetComponent<cityconnect>().selfinfo.connection_point.Add(t.GetComponent<cityconnect>().selfinfo.selfnum);
            i = t.GetComponent<cityconnect>().selfinfo.connection_point[1];
            transform.GetChild(i).GetComponent<cityconnect>().selfinfo.connection_point.Add(t.GetComponent<cityconnect>().selfinfo.selfnum);
        }
        foreach (Transform t in x)
        {
            //去除重复元素
            for (int i = 0; i < t.GetComponent<cityconnect>().selfinfo.connection_point.Count; i++)  //外循环是循环的次数
            {
                for (int j = t.GetComponent<cityconnect>().selfinfo.connection_point.Count - 1; j > i; j--)  //内循环是 外循环一次比较的次数
                {

                    if (t.GetComponent<cityconnect>().selfinfo.connection_point[i] == t.GetComponent<cityconnect>().selfinfo.connection_point[j])
                    {
                        t.GetComponent<cityconnect>().selfinfo.connection_point.RemoveAt(j);
                    }

                }
            }
        }
        //日志
        foreach (Transform t in x)
        {
            Debug.Log(t.GetComponent<cityconnect>().selfinfo.selfnum + ":" + t.GetComponent<cityconnect>().selfinfo.connection_point.Count);
            if(t.GetComponent<cityconnect>().selfinfo.selfnum==0)
            {
                foreach(int a in t.GetComponent<cityconnect>().selfinfo.connection_point)
                {
                    Debug.Log(a);
                }
                
            }
        }

        }
    // Start is called before the first frame update
    private void Awake()
    
          
    {
        
        List<Transform> trans = new List<Transform>();
        
        for (int i = 0; i < citysnum; i++)
        {

            bool judge = false ;
            Vector3 cposition= new Vector3(Random.Range(-90f, 90f), Random.Range(-78f, 78f), -5);
            List<RaycastHit2D> hits = new List<RaycastHit2D>(Physics2D.RaycastAll(cposition, new Vector2(0, 0)));
            GameObject p;


            while (true)
            {
                cposition = new Vector3(Random.Range(-90f, 90f), Random.Range(-78f, 78f), -5);
                hits = new List<RaycastHit2D>(Physics2D.RaycastAll(cposition, new Vector2(0, 0)));
                
                while (hits.Count == 1 && hits[0].collider.CompareTag("background"))
                {
                    if (trans.Count != 0)
                    {
                        int k;         
                        //判断点之间的距离
                        for(k=0;k<trans.Count ;k++)
                        {
                            if ((cposition - trans[k].position).magnitude >= point_distance)
                            {                                }
                            else
                            {
                                break;
                            }
                        }
                        if (k == trans.Count)
                        {
                            p = Resources.Load("Country") as GameObject;
                            p = Instantiate(p);
                            p.transform.parent = this.transform;
                            p.transform.position = cposition;
                            giveCityInfo(p);
                            trans.Add(p.transform);
                            judge = true;
                            break;
                        }
                        break;     
                    }
                    else//如果当前生成的点是第一个点
                    {
                        p = Resources.Load("Country") as GameObject;
                        p = Instantiate(p);
                        p.transform.parent = this.transform;
                        p.transform.position = cposition;
                        giveCityInfo(p);
                        trans.Add(p.transform);
                        judge = true;
                        break;
                    }

                }
                //如果成功生成则跳出循环
                if (judge) break;
            }
        }
        
        
        for (int i = 0; i < transform.childCount; i++)
        {
            countryspos.Add(transform.GetChild(i));
        }

        int a = 0;

        //设置每个点的序号
        foreach (Transform x in countryspos)
        {

            x.GetComponent<cityconnect>().give_num(a);
            a++;
        }
        foreach (Transform x in countryspos)
        {

            x.GetComponent<cityconnect>().inputinfo();
           
        }
        foreach (Transform x in countryspos)
        {

            x.GetComponent<cityconnect>().connect();

        }
        connect_back(countryspos);








    }

    void giveCityInfo(GameObject targetCity)
    {
        int a = Random.Range(0, names.Count);
        targetCity.GetComponent<cityinfo>().name = names[a];
        targetCity.GetComponent<cityinfo>().cityname = names[a];
        names.RemoveAt(a);
    }
 

}
//if (hits.Count == 1)
//            {
//                foreach (RaycastHit2D hit in hits)
//                {

//                    if (hit.collider.CompareTag("background"))
//                    {
//                        trans.Add(p.transform);
//                        foreach (Transform x in trans)
//                        {
//                            if (((p.transform.position - x.position).magnitude<point_distance) && ((p.transform.position - x.position).magnitude > 0))
//                            {
//                                citysnum++;
//                                trans.RemoveAt(trans.Count - 1);
//                                p.transform.parent = null;
//                                Destroy(p);
//judge = false;
//                                break;
//                            }
//                        }
//                        break;
//                    }
//                    else
//                    {
//                        citysnum++;
//                        p.transform.parent = null;
//                        Destroy(p);
//judge = false;
//                        break;
//                    }
//                }
 
//            }

//            else
//            {
//                citysnum++;
//                p.transform.parent = null;
//                Destroy(p);
//judge = false;
                
//            }