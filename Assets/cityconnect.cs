using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityconnect : MonoBehaviour
{


    public List<Transform> countryspos = new List<Transform>();

    
    public citys_create.countrys selfinfo = new citys_create.countrys();
    
    //public struct countrys
    //{
    //    public int selfnum;//城市编号
    //    public float[] far;
    //    public int[] farnum;
    //    public int othernum;
    //    public Transform otherpos;
    //    public List<int> connection_point; //连接点
    //}
    void Start()
    {

        
        //connect();

    }
    public void connect()
    {
        float min=500;
        int min_distance_p=0;
        
            for (int i = 0; i < selfinfo.far.Length; i++)
            {
                if (selfinfo.far[i] < min)
                {
                    citys_create.countrys c = this.transform.parent.GetComponent<citys_create>().countryspos[i].GetComponent<cityconnect>().selfinfo;
                    if (c.connection_point.Count != 0 && c.selfnum != selfinfo.selfnum)
                    {
                        foreach (int k in c.connection_point)
                        {
                            if (k == selfinfo.selfnum) { goto A; break; }
                        }
                        min = selfinfo.far[i];
                        min_distance_p = i;
                        A:;
                    }
                    else if (c.connection_point.Count == 0 && c.selfnum != selfinfo.selfnum)
                    {
                        min = selfinfo.far[i];
                        min_distance_p = i;
                    }
                }
            }

        selfinfo.connection_point.Add(selfinfo.farnum[min_distance_p]);
        min = 500;
        min_distance_p = 0;
        float secmin = 500;
        int secp = 0;
        for (int i = 0; i < selfinfo.far.Length; i++)
        {
            if (selfinfo.far[i] < min)
            {
                citys_create.countrys c = this.transform.parent.GetComponent<citys_create>().countryspos[i].GetComponent<cityconnect>().selfinfo;
                if (c.connection_point.Count != 0 && c.selfnum != selfinfo.selfnum)
                {
                    foreach (int k in c.connection_point)
                    {
                        if (k == selfinfo.selfnum) { goto A; break; }
                    }
                    secmin = min;
                    secp = min_distance_p;
                    min = selfinfo.far[i];
                    min_distance_p = i;
                    A:;
                }
                else if (c.connection_point.Count == 0 && c.selfnum != selfinfo.selfnum)
                {
                    secmin = min;
                    secp = min_distance_p;
                    min = selfinfo.far[i];
                    min_distance_p = i;
                }
            }
        }

        selfinfo.connection_point.Add(selfinfo.farnum[secp]);
        //画线
        /*
        GameObject line;
        line = Instantiate(GameObject.Find("line"));
        line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, transform.parent.GetChild(selfinfo.connection_point[0]).transform.position);
        line = Instantiate(GameObject.Find("line"));
        line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, transform.parent.GetChild(selfinfo.connection_point[1]).transform.position);

        print(selfinfo.connection_point[0]);
        */
    }
    public void give_num(int a)
    {
        selfinfo.selfnum = a;
    }
    public void inputinfo()
    {
        selfinfo.far = new float[ this.transform.parent.childCount];
        selfinfo.farnum = new int[ this.transform.parent.childCount];
        List<Transform> t = this.transform.parent.GetComponent<citys_create>().countryspos;
        
        for (int i = 0; i < transform.parent.childCount; i++)
        {
                selfinfo.far[i] = (t[i].position - this.transform.position).magnitude;
                selfinfo.farnum[i] = t[i].gameObject.GetComponent<cityconnect>().selfinfo.selfnum;            
        }
    }

    void Update()
    {
        
      
        //Debug.DrawLine(transform.position,transform.parent.GetChild(selfinfo.connection_point[0]).transform.position,Color.blue);
    }
}

    

