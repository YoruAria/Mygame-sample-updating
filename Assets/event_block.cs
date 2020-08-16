using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[System.Serializable]
public class event_block : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject A;
    // Start is called before the first frame update
    public NewBehaviourScript1.Node event_node;
    public int i, j;
    public create_box.box[,] my_box;
    public bool isruned;//本区块是否被执行过
    void Awake()
    {
        my_box=GameObject.Find("Canvas_map").GetComponent<create_box>().my_box;
        event_node = new NewBehaviourScript1.Node();
        isruned = false;
    }
    void Start()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (A.activeInHierarchy == false)//检测事件互动窗口是否关闭
        {
            Debug.Log("event_block down!!!!");
            this.GetComponent<SpriteRenderer>().color = Color.white;
            A.SetActive(true);
            A.GetComponent<event_reader>().get_event(event_node);//把本区块内的事件交给对话事件系统执行
            if (i < 5 && !my_box[i + 1, j].bk.GetComponent<event_block>().isruned) my_box[i + 1, j].bk.GetComponent<event_block>().enabled = true;
            if (i > 0 && !my_box[i - 1, j].bk.GetComponent<event_block>().isruned) my_box[i - 1, j].bk.GetComponent<event_block>().enabled = true;
            if (j < 5 && !my_box[i, j + 1].bk.GetComponent<event_block>().isruned) my_box[i, j + 1].bk.GetComponent<event_block>().enabled = true;
            if (j > 5 && !my_box[i, j - 1].bk.GetComponent<event_block>().isruned) my_box[i, j - 1].bk.GetComponent<event_block>().enabled = true;
            isruned = true;
            this.GetComponent<event_block>().enabled = false;

        }
            

        
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
