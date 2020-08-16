using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_creat : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    int max_perlevel = 4;
    int min_perlevel = 2;
    int y = 10;
    int x = 20;
    
    void Start()
    {
        level = y;

        for(int i=0; i < level; i++)
        {
            int n = Random.Range(min_perlevel, max_perlevel );//这一行的点数量
            //List<int> points = new List<int>();
            int perarea = x / n;//每个区的长度
            int nowarea=0;
                for (int l=0; l < n; l++)
                { 
                    
                    int point = Random.Range(nowarea, nowarea+perarea);
                    nowarea += perarea;
                    
                    //foreach(int j in points)
                    //{
                        
                    //    while(point == j)
                    //    point = Random.Range(0, x);
                        
                    //}
                    
                   
                //points.Add(point);
                GameObject p = Resources.Load("element") as GameObject;
                p = Instantiate(p);
                p.transform.parent = this.transform;
                p.transform.position = new Vector3(point*3,  i*10 , 0);
                    
                
                }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
