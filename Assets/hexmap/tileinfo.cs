using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class tileinfo 
{
    public enum TileType { NORMAL,BLOCK,WATER}
    public Vector3Int pos;//对应tile坐标
    public TileType type;//换为枚举
    public TileEventLoad.Node tile_event;
    public Vector3Int posbefore;

    public tileinfo(Vector3Int pos,TileType type)
    {
        this.pos = pos;
        this.type = type;
    }
   
}
