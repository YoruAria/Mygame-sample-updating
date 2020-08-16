using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;
using System;

public class units : MonoBehaviour, IComparable<units>
{
    // Start is called before the first frame update
    public Slider slid;
    public Slider UIHealth;
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
    public List<skill.skillbase> skill_list=new List<skill.skillbase>();
    public List<buff.buffbase> buff_list=new List<buff.buffbase>();
    public int CompareTo(units obj)
    {
        return -this.speed.CompareTo(obj.speed);//降序
    }
    public void init(units_attribute unit)
    {
        HP = unit.HP;
        Cur_Hp = unit.HP;
        damage = unit.damage;
        speed = unit.speed;
        obj_type = unit.obj_type;
        unit_name = unit.unit_name;
        sprite = unit.sprite;
        skill_list = unit.skill_list;
        construct();
    }
    public void construct()
    {
        transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = this.sprite;
        slid.maxValue = HP;
        slid.value = Cur_Hp;
    }
    public void get_buff(buff.buffbase b,float buff_v,int count)//获得buff
    {
        b.set_buff_value(buff_v, count,this);
        buff_list.Add(b);
        b.buff_ex();
    }
     
    public void buff_countdown()
    {
        foreach(buff.buffbase x in buff_list)
        {
            x.count_reduce();
        }
    }
    public void costadd(int i)
    {
        cur_cost += i;
        if (cur_cost >= max_cost) cur_cost = max_cost;
    }
    void Awake()
    {
        //测试
        max_cost = 4;
        cur_cost = 3;
        //skill_list.Add(new skill.attack());
        //skill_list.Add(new skill.heal());

        slid.maxValue = HP;
        slid.value = Cur_Hp;
        isdead = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool take_damege(int d)
    {
        Cur_Hp -= d;
        slid.value = Cur_Hp;

        if (Cur_Hp <= 0)
        {
            isdead = true;
            return true;//死亡
        }
        else
            return false;//未死亡
    }
    public void get_heal(int h)
    {
        Cur_Hp += h;
        if (Cur_Hp >= HP)
            Cur_Hp = HP;
        slid.value = Cur_Hp;
    }
}
