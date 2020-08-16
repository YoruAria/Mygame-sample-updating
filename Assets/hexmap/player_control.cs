using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading;
using DG.Tweening;
public class player_control : MonoBehaviour
{
    // Start is called before the first frame update
    public tilemap_eventcontroller eventcontroller;
    public Transform player;
    public Tilemap map;
    public Tween pathmove;//路径动画

    private void Start()
    {

    }
    public void moveto(Vector3Int target)
    {
        GetComponent<hexmap_create>().ismoved = true;
        //StartCoroutine(Move(target));
        NewMove(target);
    }
    IEnumerator Move(Vector3Int target)
    {
        GetComponent<hexmap_create>().ismoved = true;
        player = GetComponent<hexmap_create>().player.transform;
        List<Vector3Int> path;
        Vector3Int curpos = map.WorldToCell(player.position);
        curpos = new Vector3Int(curpos.x, curpos.y, 0);
        path = path_find.BFS(curpos, target, hexmap_create.mapinfo);
        for (int i = 0; i < path.Count; i++)
        {
            print(path[i]);
            Vector3 p = map.CellToLocal(path[i]) + new Vector3(0, 0, -5);
            player.position = p;
            //如果到事件区块，触发事件

            yield return new WaitForSeconds(1);
        }
        GetComponent<hexmap_create>().ismoved = false;
    }
    public void movetotest(List<Vector3Int> path)
    {
        GetComponent<hexmap_create>().ismoved = true;
        //StartCoroutine(Move(target));
        MoveTest(path);
    }
    public void MoveTest(List<Vector3Int> path)
    {
        player = GetComponent<hexmap_create>().player.transform;
        List<Vector3> localpath = new List<Vector3>();
        for (int i = 0; i < path.Count; i++)
        {
            print(path[i]);
            Vector3 p = map.CellToLocal(path[i]) + new Vector3(0, 0, -5);


            localpath.Add(p);
            //如果到事件区块，停止

            if (hexmap_create.mapinfo[path[i]].tile_event != null)
            {
                break;
            }
        }
        float t = localpath.Count * 0.5f;
        //player.transform.DOLocalPath(localpath.ToArray(), t);
        pathmove = player.transform.DOLocalPath(localpath.ToArray(), t);
        pathmove.Play();


        if (hexmap_create.mapinfo[path[localpath.Count - 1]].tile_event != null)
        {
            TileEventLoad.Node d = hexmap_create.mapinfo[path[localpath.Count - 1]].tile_event;
            //地图触发事件
            //eventcontroller.showevent(d);
            //pathmove.OnComplete(()=>eventcontroller.showevent(d));//动画播放结束后触发
            pathmove.OnComplete(() => moveendevent(d));//动画播放结束后触发
            hexmap_create.mapinfo[path[localpath.Count - 1]].tile_event = null;
            map.SetTile(path[localpath.Count - 1], GetComponent<hexmap_create>().tile);

        }
        else
        {
            pathmove.OnComplete(() => GetComponent<hexmap_create>().ismoved = false);
        }
        void moveendevent(TileEventLoad.Node d)
        {
            eventcontroller.showevent(d);
            GetComponent<hexmap_create>().ismoved = false;

        }

        // pathmove.Pause();
    }


    public void  NewMove(Vector3Int target)
    {
        //GetComponent<hexmap_create>().ismoved = true;
        player = GetComponent<hexmap_create>().player.transform;
        List<Vector3Int> path;
        Vector3Int curpos = map.WorldToCell(player.position);
        curpos = new Vector3Int(curpos.x, curpos.y, 0);
        path = path_find.BFS(curpos, target, hexmap_create.mapinfo);
        List<Vector3> localpath = new List<Vector3>();
        for (int i = 0; i < path.Count; i++)
        {
            print(path[i]);
            Vector3 p = map.CellToLocal(path[i]) + new Vector3(0, 0, -5);

            
            localpath.Add(p);
            //如果到事件区块，停止

            if (hexmap_create.mapinfo[path[i]].tile_event != null)
            {
                break;
            }
            
            
        }
        float t = localpath.Count*0.5f;
        //player.transform.DOLocalPath(localpath.ToArray(), t);
       pathmove = player.transform.DOLocalPath(localpath.ToArray(), t);
        pathmove.Play();
        
        
        if(hexmap_create.mapinfo[path[localpath.Count-1]].tile_event!=null)
        {
            TileEventLoad.Node d= hexmap_create.mapinfo[path[localpath.Count - 1]].tile_event;
            //地图触发事件
            //eventcontroller.showevent(d);
            //pathmove.OnComplete(()=>eventcontroller.showevent(d));//动画播放结束后触发
            pathmove.OnComplete(()=>moveendevent(d));//动画播放结束后触发
            hexmap_create.mapinfo[path[localpath.Count - 1]].tile_event = null;
            map.SetTile(path[localpath.Count - 1], GetComponent<hexmap_create>().tile);
            
        }
        else
        {
            pathmove.OnComplete(() => GetComponent<hexmap_create>().ismoved = false);
        }
         void moveendevent(TileEventLoad.Node d)
        {
            eventcontroller.showevent(d);
            GetComponent<hexmap_create>().ismoved = false;
            
        }
        
        // pathmove.Pause();
    }
   
  
}
