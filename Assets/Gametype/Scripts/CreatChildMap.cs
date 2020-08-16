using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CreatChildMap : MonoBehaviour
{
    private Vector2 startPointMinMax = new Vector2(0.2f,0.4f);
    private Vector2 endPointMinMax = new Vector2(0.6f,0.8f);
    public GameObject startDoor;
    public GameObject endDoor;
    public int childMapLength;



    public void CreateChildMap(int length)
    {
        int startPoint = Mathf.RoundToInt((length * Random.Range(startPointMinMax.x, startPointMinMax.y)));
        int endPoint = Mathf.RoundToInt((length * Random.Range(endPointMinMax.x, endPointMinMax.y)));

        childMapLength = Mathf.RoundToInt((endPoint) - (startPoint));

        GameObject a = Instantiate(startDoor, transform.GetChild(startPoint).transform);
        a.GetComponent<EnterAndLeave>().length = childMapLength;
        a.GetComponent<EnterAndLeave>().exitPoint = endPoint;
        a.GetComponent<EnterAndLeave>().isEnterOrLeave = true;
        

        

    }
}
