using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnterAndLeave : MonoBehaviour,IPointerClickHandler
{
    public bool isEnterOrLeave;
    public int length;
    
    public GameObject startPoint;
    public int exitPoint;
    public GameObject endDoor;
    public List<GameObject> mapType;
    public Transform mainMap;

    private void Start()
    {
        if(isEnterOrLeave == true)
        {
            mainMap = transform.parent.parent.transform;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("点击");
        if(isEnterOrLeave == true)
        {
            CreateAMiniMap();
        }else if(isEnterOrLeave == false)
        {
            Debug.Log("蓝色点击");
            mainMap.gameObject.SetActive(true);
            Camera cmr = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            cmr.transform.position = new Vector3( mainMap.transform.GetChild(exitPoint).gameObject.transform.position.x, mainMap.transform.GetChild(exitPoint).gameObject.transform.position.y,-10);
            transform.parent.parent.transform.gameObject.SetActive(false);
            

        }
    }

    private void CreateAMiniMap()
    {
        Camera cmr = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        GameObject b = Instantiate(startPoint, transform.parent.parent.parent.transform);
        CreatMap.CreateMainMap(length, mapType, b.transform);
        Instantiate(endDoor, b.transform.GetChild(b.transform.childCount - 1).transform);
        endDoor.GetComponent<EnterAndLeave>().length = length;
        endDoor.GetComponent<EnterAndLeave>().mainMap = mainMap;
        endDoor.GetComponent<EnterAndLeave>().exitPoint = exitPoint;
        cmr.transform.position = new Vector3(0, 0, -10);

    
        mainMap.gameObject.SetActive(false);


    }
}
