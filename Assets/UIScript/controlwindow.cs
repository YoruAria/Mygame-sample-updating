using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class controlwindow : MonoBehaviour,IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler
{

    public GameObject functions;
    public GameObject cityname;
    public GameObject closeall;
    public void OnPointerClick(PointerEventData eventData)
    {
        
        
        
        functions.SetActive(true);
        cityname.SetActive(true);
        closeall.SetActive(false);

        gameObject.transform.parent.parent.GetChild(3).gameObject.SetActive(true);

        Debug.Log("点击");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("按下");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("进入");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("抬起");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("离开");
    }
}
