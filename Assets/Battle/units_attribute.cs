using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class units_attribute 
{
    // Start is called before the first frame update
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

    [SerializeField]
    public List<skill.skillbase> skill_list = new List<skill.skillbase>();
}
