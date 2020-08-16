﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class skill_button : MonoBehaviour,IPointerClickHandler, IDragHandler, IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    // Start is called before the first frame update
    skill.skillbase skill;
    public battle_control battle_ctr;
    public GameObject tar;
    battle_control.skill_target target_type;

    public Vector2 rem_position;
    public Vector2 last_position;
    
    GameObject acttar;

    public Vector3 globalMousePos;
    public void set_skill_button(skill.skillbase s)
    {
        skill = s;
        target_type = skill.skill_target_type;
        transform.GetChild(0).GetComponent<Text>().text = skill.skillname;
    }
    public void OnPointerClick(PointerEventData data)
    {
       
    }
    public void OnPointerDown(PointerEventData data)
    {
        //acttar = Instantiate(tar, transform);
    }
    public void OnPointerUp(PointerEventData data)
    {
        //Destroy(acttar);
    }
    public void OnDrag(PointerEventData data)
    {
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(this.GetComponent<RectTransform>(), data.position,
        //data.pressEventCamera, out globalMousePos);
        //acttar.transform.position = globalMousePos;

        battle_ctr.set_target_type(target_type);
        rem_position = data.pressPosition;
    }
    public void OnEndDrag(PointerEventData data)
    {
        

        last_position = data.position;
        

        float d = (last_position - rem_position).magnitude;
        if (last_position.y - rem_position.y < 200)
            d = -d;

            if (data.hovered.Count!=0)
            battle_ctr.skill_ex(skill, data.hovered[0],d);
        else
            battle_ctr.skill_ex(skill, null,d);
    }
    void Start()
    {
        battle_ctr= GameObject.Find("Battle_control").GetComponent<battle_control>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
