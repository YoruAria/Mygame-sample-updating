using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class controlbutton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject windows;
    public void OnPointerClick(PointerEventData eventData)
    {
        windows.SetActive(true);
        windows.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = this.transform.GetChild(0).GetComponent<Text>().text;
        windows.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = this.transform.GetChild(0).GetComponent<Text>().text;
        this.transform.parent.gameObject.SetActive(false);
        this.transform.parent.parent.GetChild(2).gameObject.SetActive(false);

        this.transform.parent.parent.GetChild(3).gameObject.SetActive(false);
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
