using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class exitwindow : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler
{
    
    
    public void OnPointerClick(PointerEventData eventData)
    {


        
        Destroy(gameObject.transform.parent.parent.gameObject);


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
