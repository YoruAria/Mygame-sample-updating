using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataCreate 
{
    public Sprite sprite;
    /*
    public int max_cost;
    public int cur_cost;

    public Sprite sprite;
    public string unit_name;
    public bool isdead;
    public string obj_type;  //player or enemy
    public int HP;
    public int Cur_Hp;
    public int damage;
    public int speed;
    */
    [SerializeField]
    //public List<skill.skillbase> skill_list = new List<skill.skillbase>();

    public units_attribute magician()
    {
        units_attribute unit=new units_attribute();

        Sprite s = Resources.Load<Sprite>("Rogue_01");
       
        unit.sprite = s;

        unit.unit_name = "magician";
        unit.obj_type = "enemy";
        unit.HP = 100;
        unit.Cur_Hp = 100;
        unit.damage = 10;
        unit.speed = 5;
        skill.skillbase[] skill_list = { new skill.attack(), new skill.all_attack() };
        unit.skill_list.AddRange(skill_list);
        return unit;
    }
  
}
