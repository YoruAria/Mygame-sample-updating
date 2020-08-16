using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public class hexmap_create : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera camera;
    public Tile shadowtile;
    public Tile transparenttile;
    public Tile mountaintile;
    public Tile questtile;
    public Tilemap Specialtilemap;
    public Tilemap mountaintilemap;
    public static TileinfoDictionary mapinfo;//自定义序列化字典  插件
    public TileinfoDictionary showmapinfo;//自定义序列化字典  插件           
    public TileEventLoad tileEventLoad;
    public Tile endtile;
    //public Dictionary<Vector3Int,tileinfo> mapinfo;
    public Tilemap tilemap;
    public GameObject player;
    public Tile tile;
    public int mapW = 10;
    public int mapH = 10;
    public int nmountain;
    public bool ismoved = false;
    public GameObject mapfobj;
   
    public bool iseventon_origin;
    public bool iseventon
    {
        get
        {
            return this.iseventon_origin;
        }
        set
        {
            if (value == true)
            {
                foreach(KeyValuePair<Vector3Int,tileinfo> a in mapinfo)
                {
                    tilemap.SetColor(a.Key, Color.white);
                }
            }
           this.iseventon_origin = value;
        }
    }


    void Start()
    {
        iseventon = false;
        mapinfo = new TileinfoDictionary();
        create();
        player= Instantiate(player,mapfobj.transform);
        player.transform.position = tilemap.CellToLocal(new Vector3Int(0, 0, 0))+new Vector3(0,0,-2);
        
  
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //showmapinfo = mapinfo;
    //    //Vector3 pos = Input.mousePosition;
    //    //pos = Camera.main.ScreenToWorldPoint(pos);
    //    //Vector3Int cellpos = tilemap.WorldToCell(pos);
    //    //cellpos = new Vector3Int(cellpos.x, cellpos.y, 0);
    //    //if (mapinfo.ContainsKey(cellpos)&&mapinfo[cellpos].type==tileinfo.TileType.NORMAL)
    //    //    updatesearch();

    //}
    void Update()
    {
        showmapinfo = mapinfo;
        camera.transform.position = player.transform.position + new Vector3(3, 3, -10);
        if (iseventon_origin == false&&ismoved==false)
        {
         
             updatesearch(); 
        }

    }
    public void create()
    {
        for(int i=0; i<mapW;i++)
        {
            for(int j=0; j<mapH;j++)
            {
                TileEventLoad.Node e=new TileEventLoad.Node();
                e = tileEventLoad.node[Random.Range(0,tileEventLoad.node.Count)];
                Vector3Int pos = new Vector3Int(i, j, 0);
                tileinfo info = new tileinfo(pos, tileinfo.TileType.NORMAL);
                info.tile_event=e;
                tilemap.SetTile(pos, tile);
                mapinfo.Add(pos, info);
            }
        }
        HashSet<int[]> mountainpos=new HashSet<int[]>();

        mapinfo[new Vector3Int(0, 0, 0)].tile_event = null;
        
        for(int i=0; i < nmountain; i++)
        {
            int x = Random.Range(0,mapW);
            int y= Random.Range(0,mapH);
            int[] pos = { x, y };
            if (!mountainpos.Contains(pos)&&new Vector3Int(x,y,0)!=Vector3Int.zero)
                mountainpos.Add(new int[]{ x, y});
        }
        
        foreach(int[] p in mountainpos)
        {
            Vector3Int pos = new Vector3Int(p[0], p[1], 0);
            if (tilemap.GetTile(pos) != null)
            {
                mountaintilemap.SetTile(pos, mountaintile);
                mapinfo[pos].type = tileinfo.TileType.BLOCK;
            }
        }
        
        foreach(KeyValuePair<Vector3Int,tileinfo> i in mapinfo){
            if (i.Value.tile_event != null)
                tilemap.SetTile(i.Key, questtile);
        }
        int endx = Random.Range(0, mapW);
        int endy = Random.Range(0, mapH);
        int[] endpos = { endx, endy };
        
      List<Vector3Int> ep = path_find.BFS(new Vector3Int(0, 0, 0), new Vector3Int(endx, endy, 0), mapinfo);
        if(ep==null||(ep!=null&&ep.Count<10)||mapinfo[new Vector3Int(endx, endy, 0)].type==tileinfo.TileType.BLOCK)
        { tilemap.ClearAllTiles();
            mountaintilemap.ClearAllTiles();
            mapinfo.Clear();
            mountainpos.Clear();
            create();
        }
        else
        {
           Specialtilemap.SetTile(new Vector3Int(endx, endy, 0), endtile);
        }
    }
    //点击移动
    
    public void clickdown()
    {
        if (iseventon == false && ismoved == false)
        {
            ismoved = true;
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            Vector3Int cellpos = tilemap.WorldToCell(pos);
            cellpos = new Vector3Int(cellpos.x, cellpos.y, 0);
            TileBase t = tilemap.GetTile(cellpos);
            
            Vector3Int playerpos = tilemap.WorldToCell(new Vector3(player.transform.position.x, player.transform.position.y, 0));
            if (playerpos == cellpos|| t == null)
            {
                ismoved = false;
                return;
            }
            //GetComponent<player_control>().moveto(cellpos);
            GetComponent<player_control>().movetotest(pathto);
        }
    }
    List<Vector3Int> rempath=new List<Vector3Int>();
    List<Vector3Int> pathto=new List<Vector3Int>();
    Vector3Int cellposbefore=new Vector3Int();
    public void updatesearch()
    {
     
        
        Vector3 pos = Input.mousePosition;

        pos = Camera.main.ScreenToWorldPoint(pos);
        Vector3Int cellpos = tilemap.WorldToCell(pos);
        cellpos = new Vector3Int(cellpos.x, cellpos.y, 0);
        if (tilemap.WorldToCell(player.transform.position) == cellpos )
            return;
        if(!mapinfo.ContainsKey(cellpos))
        {
            return;
        }
        if(mapinfo[cellpos].type != tileinfo.TileType.NORMAL)
        { return; }
        if (cellposbefore == cellpos)
            return;
        if(rempath!=null)
        foreach (Vector3Int i in rempath)
        {
            tilemap.SetColor(i, Color.white);
        }
    
        //TileBase t = tilemap.GetTile(cellpos);
        //if (t == null||mapinfo[cellpos].type==tileinfo.TileType.BLOCK) return;
        Vector3 ppos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        if (tilemap.WorldToCell(ppos) == cellpos)
            return;
        List<Vector3Int> path = path_find.BFS(tilemap.WorldToCell(ppos), cellpos, mapinfo);
        cellposbefore = cellpos;
        rempath = path;
        pathto = path;
        if(path!=null)
        foreach (Vector3Int i in path)
        {
            tilemap.SetTileFlags(i, 0);
            tilemap.SetColor(i, new Color(1, 1, 1, 0.5f));
            //shadowtilemap.SetTile(i, transparenttile);
        }
    }

}
