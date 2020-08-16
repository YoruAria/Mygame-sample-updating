using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class path_find 
{

    //单数行相邻
   static Vector3Int[] vec_six_single = {new Vector3Int(0,1,0) , new Vector3Int(1, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0) };
    //双数行相邻
    static Vector3Int[] vec_six_double = {new Vector3Int(-1,1,0) , new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) };

    public static List<Vector3Int> BFS(Vector3Int startpos,Vector3Int endpos,TileinfoDictionary mytileinfo)//广度优先
    {
        
        HashSet<Vector3Int> isjudged=new HashSet<Vector3Int>();
        List<Vector3Int> result=new List<Vector3Int>();
        Queue<Vector3Int> judgeque=new Queue<Vector3Int>();
        judgeque.Enqueue(startpos);
        isjudged.Add(startpos);
        Vector3Int curpos=new Vector3Int();
        while (judgeque.Count!=0&&(curpos=judgeque.Dequeue())!=endpos)
        {
           // Debug.Log(curpos);
            isjudged.Add(curpos);
            Vector3Int[] vec = { };
            if (curpos.y % 2 == 0)//单数行or双数行
                vec = vec_six_double;
            else
                vec = vec_six_single;
            
            for(int i=0; i < 6; i++)
            {
                if (mytileinfo.ContainsKey(curpos + vec[i])&&!isjudged.Contains(curpos + vec[i])&&mytileinfo[curpos + vec[i]].type!=tileinfo.TileType.BLOCK)//判断条件
                {
                    isjudged.Add(curpos + vec[i]);
                    judgeque.Enqueue(curpos + vec[i]);
                    mytileinfo[curpos + vec[i]].posbefore = curpos;
                   // Debug.Log(curpos + vec[i]);
              
                }
            }
     
        }
        if (judgeque.Count == 0) return null;
        while (mytileinfo[curpos].posbefore != startpos)
        {
        //Debug.Log(curpos);
            result.Add(curpos);
            curpos = mytileinfo[curpos].posbefore;
            
        }
        result.Add(curpos);
        result.Add(mytileinfo[curpos].posbefore);
        result.Reverse();
        return result;
    }

}
