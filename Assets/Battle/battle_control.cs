using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class battle_control : MonoBehaviour
{
    // Start is called before the first frame update
    public enum battle_state { START,PLAYERTURN,ENEMYTURN,WIN,LOST,SKILLTARGETSEL}
    public enum skill_target {PLAYER,PLAYERTEAM,ENEMY,ENEMYTEAM }
    public battle_state state;
    public skill_target target_type;
    public GameObject player_pre;
    public GameObject enemy_pre;
    //多人队伍测试
    public List<GameObject> players;
    public List<GameObject> enemys;
    public List<units> players_units;
    public List<units> enemys_units;
    public List<units> moving_order;
    public int cur_moving_index;
    public int total_count;
    //

    

    public GameObject player;
    public GameObject enemy;
    public units punits;
    public units eunits;

    public Transform playerteam_pos;
    public Transform enemyteam_pos;

    public Button next_button;
    

    public Text txt;
    public GameObject skill_buttons;
    public Transform buttons_list;
    public Slider UIhealth;
    public Text leftAP;
    public Slider AP;
    
    public GameObject Stats;
    public GameObject items;
    GameObject map;
    void Start()
    {
        next_button.enabled = false;
        //StartCoroutine(start_battle());
    }
    List<units> playerlist;
    List<units> enemylist;
    public GameObject battle_object;
    public void init(List<units_attribute> playerlist,List<units_attribute> enemylist)
    {
        next_button.enabled = false;
        int posoffset = 0;
        if(playerlist!=null)
        foreach(units_attribute i in playerlist)
        {
           Sprite s= i.sprite;
            
            GameObject battleobj = Instantiate(battle_object, playerteam_pos);
            battleobj.GetComponent<units>().init(i);
            battleobj.transform.position+= new Vector3(posoffset, 0, 0);
            posoffset -= 25;
        }
        posoffset = 0;
        foreach (units_attribute i in enemylist)
        {
            GameObject battleobj = Instantiate(battle_object, enemyteam_pos);
            battleobj.GetComponent<units>().init(i);
            battleobj.transform.position += new Vector3(posoffset, 0, 0);
            posoffset += 25;
            enemys.Add(battleobj);
        }
        StartCoroutine(start_battle());
        map=GameObject.Find("map_fobj");
        map.SetActive(false);
    }
    IEnumerator start_battle()
    {

        state = battle_state.START;
        player = Instantiate(player_pre, playerteam_pos);
        //enemy = Instantiate(enemy_pre, enemyteam_pos);
        punits = player.GetComponent<units>();
        //eunits = enemy.GetComponent<units>();
        txt.text = "battle start!!!";
        //b1.GetComponent<skill_button>().set_skill_button(player.GetComponent<units>().skill_list[0]);
        //b2.GetComponent<skill_button>().set_skill_button(player.GetComponent<units>().skill_list[1]);
        //多人测试队伍
        GameObject player1 = Instantiate(player_pre, playerteam_pos);
        //GameObject enemy1 = Instantiate(enemy_pre, enemyteam_pos);
        player1.GetComponent<units>().skill_list.Add ( new skill.heavy_attack());
        player1.GetComponent<units>().skill_list.Add ( new skill.speedup());
        player1.GetComponent<units>().skill_list.Add(new skill.all_attack()) ;
        player.GetComponent<units>().skill_list.Add ( new skill.heavy_attack());
        player.GetComponent<units>().skill_list.Add(new skill.heal());
        //enemy.GetComponent<units>().skill_list.Add(new skill.attack());
        //enemy.GetComponent<units>().skill_list.Add(new skill.all_attack());
        //enemy1.GetComponent<units>().skill_list.Add(new skill.attack());
        //enemy1.GetComponent<units>().skill_list.Add(new skill.all_attack());
        player1.GetComponent<units>().speed=4;
        //enemy1.GetComponent<units>().speed=1;
        player1.transform.position += new Vector3(-25, 0, 0);
        //enemy1.transform.position += new Vector3(25, 0, 0);
        players.Add(player);
        players.Add(player1);
        //enemys.Add(enemy);
        //enemys.Add(enemy1);
        set_moving_order();

        //
        yield return new WaitForSeconds(2f);
        //state = battle_state.PLAYERTURN;
        //playerturn();
        
        next_turn();
    }
    public void set_moving_order()
    {
        moving_order.Clear();
        players_units.Clear();
        enemys_units.Clear();
        foreach (GameObject u in players)
        {
            players_units.Add(u.GetComponent<units>());
        }
        foreach (GameObject u in enemys)
        {
            enemys_units.Add(u.GetComponent<units>());
        }
        cur_moving_index = 0;
        
        moving_order.AddRange(players_units);
        moving_order.AddRange(enemys_units);
        total_count = moving_order.Count;//目前场上总人数（双方）
        foreach(units x in moving_order)
        {
            x.buff_countdown();//在所有人执行一回合后,减少所有buff的倒计时
        }
        moving_order.Sort();       
        
    }
    public void playerturn(units player)
    {
        //根据技能设置按键
        for (int i = 0;i < player.skill_list.Count; i++)
        {
            GameObject a = Instantiate(skill_buttons, buttons_list);
            a.GetComponent<skill_button>().set_skill_button(player.skill_list[i]);
        }
        UIhealth.maxValue = player.HP;
        UIhealth.value = player.Cur_Hp;
        
        
        state = battle_state.PLAYERTURN;
        txt.text = "selcet your action!!!";
        int deadcount = 0;
        foreach (units i in enemys_units)
        {
            if (i.isdead == true)
                deadcount++;
        }
        if (deadcount == enemys_units.Count)
        {
            state = battle_state.WIN;
            endbattle();
          
        }
    }
  
    public void setAPHUB(units x)//设置cost/ap的ui
    {
        AP.maxValue = x.max_cost;
        AP.value = x.cur_cost;
        leftAP.text = x.cur_cost.ToString();
    }
    public void next_turn()
    {
        DeleteSkill();
        next_button.enabled = false;
        foreach(units u in moving_order)
        {
            u.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (cur_moving_index== total_count)
        {
            set_moving_order();
            next_turn();
        }
        else
        {
            if(moving_order[cur_moving_index].obj_type=="player")
            {
                if (moving_order[cur_moving_index].isdead == false)
                {
                    moving_order[cur_moving_index].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                    UIStatsOpen(true);
                    state = battle_state.PLAYERTURN;
                    playerturn(moving_order[cur_moving_index]);//根据行动角色生成技能图标
                    //moving_order[cur_moving_index].buff_countdown();//减少所有buff的倒计时
                    moving_order[cur_moving_index].costadd(2);//每回合恢复两点cost
                    setAPHUB(moving_order[cur_moving_index]);
                    next_button.enabled = true;
                    cur_moving_index++;
                    return;
                }
                cur_moving_index++;
                
                next_turn();
                return;
            }
            if (moving_order[cur_moving_index].obj_type == "enemy")
            {
                if (moving_order[cur_moving_index].isdead == false)
                {
                    moving_order[cur_moving_index].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                    UIStatsOpen(false);
                    state = battle_state.ENEMYTURN;
                    StartCoroutine(enemy_turn(moving_order[cur_moving_index]));
                    cur_moving_index++;
                    return;

                }
                cur_moving_index++;
                next_turn();
                return;
            }
        }
    }
    IEnumerator enemy_turn(units enemy)
    {
        

        state = battle_state.ENEMYTURN;
        System.Random r = new System.Random();
        int index = r.Next(enemy.skill_list.Count);
        skill.skillbase s= enemy.skill_list[index];
        Debug.Log("type:" + s.skill_target_type);
        yield return new WaitForSeconds(1.5f);
        txt.text = "你正被攻击"+s.skillname;
        
        yield return  new WaitForSeconds(2f);
        yield return StartCoroutine(enemy_skill_ex(s, enemy));
        /*
        int x =UnityEngine.Random.Range(0, players_units.Count);
        bool isdead=players_units[x].take_damege(enemy.GetComponent<units>().damage);
        if (isdead == true)
        {
            //玩家目标死亡
            players_units[x].isdead = true;


        }
        */
        int deadcount = 0;
        foreach(units i in players_units)
        {
            if (i.isdead == true)
                deadcount++;
        }
        if(deadcount==players_units.Count)
        {
            state = battle_state.LOST;
            endbattle();
            yield break;
        }
        //state = battle_state.PLAYERTURN;
        //playerturn();
        next_turn();
    }
    void endcheck()
    {
        int deadcount = 0;
        foreach (units i in players_units)
        {
            if (i.isdead == true)
                deadcount++;
        }
        if (deadcount == players_units.Count)
        {
            state = battle_state.LOST;
            endbattle();
            return;
        }
        foreach (units i in enemys_units)
        {
            if (i.isdead == true)
                deadcount++;
        }
        if (deadcount == enemys_units.Count)
        {
            state = battle_state.WIN;
            endbattle();

        }
    }
    void endbattle()
    {
        if (state == battle_state.WIN)
        {
            txt.text = "you win";
            Destroy(GameObject.Find("battlescene(Clone)"));
            map.SetActive(true);
        }

        if (state == battle_state.LOST)
            txt.text = "you lost";
    }
    public void set_target_type(skill_target t)
    {
        if (state == battle_state.PLAYERTURN)
        {
            target_type = t;
            state = battle_state.SKILLTARGETSEL;
            Debug.Log(target_type);

        }
    }
    
    public void skill_ex(skill.skillbase s,GameObject g,float distance=0)//我方技能释放
    {
        if (state == battle_state.SKILLTARGETSEL)
        {
            if (moving_order[cur_moving_index - 1].cur_cost >= s.cost)
            {
                if (g != null && target_type == skill_target.ENEMY && g.CompareTag("Enemy"))
                {
                    //g为释放目标
                    s.excute(moving_order[cur_moving_index - 1], g.GetComponent<units>());
                    moving_order[cur_moving_index - 1].cur_cost -= s.cost;
                    setAPHUB(moving_order[cur_moving_index - 1]);
                    state = battle_state.PLAYERTURN;
                    //next_turn();
                    //state = battle_state.ENEMYTURN;
                    //StartCoroutine(enemy_turn());
                }
                else if (g != null && target_type == skill_target.PLAYER && g.CompareTag("Player"))
                {
                    //g为释放目标
                    s.excute(moving_order[cur_moving_index - 1], g.GetComponent<units>());
                    moving_order[cur_moving_index - 1].cur_cost -= s.cost;
                    setAPHUB(moving_order[cur_moving_index - 1]);
                    state = battle_state.PLAYERTURN;
                    //next_turn();              
                }
                else if (target_type == skill_target.ENEMYTEAM && distance >= 50)
                {
                    s.excute(moving_order[cur_moving_index - 1], enemys_units);
                    moving_order[cur_moving_index - 1].cur_cost -= s.cost;
                    setAPHUB(moving_order[cur_moving_index - 1]);
                    state = battle_state.PLAYERTURN;
                    //next_turn();
                }
                else
                    state = battle_state.PLAYERTURN;
                endcheck();
            }
            else
                state = battle_state.PLAYERTURN;

          
        }   
    }
    IEnumerator enemy_skill_ex(skill.skillbase s, units spawner)//敌人技能释放
    {
        if (s.skill_target_type == skill_target.ENEMY )//等价于对玩家释放
        {
            Debug.Log("111");
            System.Random r = new System.Random();
            int index;
            while (players_units[index=r.Next(players_units.Count)].isdead != false) ;
            
            s.excute(spawner, players_units[index]);
            
            //state = battle_state.ENEMYTURN;
            
        }
        else if (s.skill_target_type == skill_target.PLAYER )//等价于对敌人释放
        {
            System.Random r = new System.Random();
            int index;
            while (enemys_units[index = r.Next(enemys_units.Count)].isdead != false) ;
            s.excute(spawner, enemys_units[index]);
            
        }
        else if (s.skill_target_type == skill_target.ENEMYTEAM )//等价于对玩家群体释放
        {
            s.excute(spawner,players_units);
            
        }
        endcheck();
        yield break;
    }
    void DeleteSkill()
    {
        for(int i = 0; i< buttons_list.childCount; i++)
        {
            Destroy(buttons_list.GetChild(i).gameObject);
        }
        
    }
    void UIStatsOpen(bool isplayer)//在不是玩家回合关闭ui
    {
        if (isplayer == true)
        {
            Stats.SetActive(true);
            items.SetActive(true);
        }
        else
        {
            Stats.SetActive(false);
            items.SetActive(false);
        }
        
    }
}
