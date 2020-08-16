using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class skill : MonoBehaviour
{
    
    // Start is called before the first frame update
    [System.Serializable]
    public class skillbase
    {
        public string skillname;
        public battle_control.skill_target skill_target_type;
        public int cost;
        public virtual void excute(units player,units enemy=null)
        {           
        }
        public virtual void excute(units player, List<units> enemy = null)
        {
        }
    }
    public class attack:skillbase
    {
        public attack()
        {
            skillname = "attack";
            cost = 1;
            skill_target_type = battle_control.skill_target.ENEMY;
        }

        public override void excute(units player, units enemy = null)
        {
            Debug.Log("attack");
            enemy.take_damege(player.damage);
        }
    }
    public class heal : skillbase
    {
        public heal()
        {
            skillname = "heal";
            cost = 1;
            skill_target_type = battle_control.skill_target.PLAYER;
        }

        public override void excute(units player, units enemy)
        {
            Debug.Log("heal");
            enemy.get_heal(20);
        }
    }
    public class heavy_attack : skillbase
    {
        public heavy_attack()
        {
            cost = 2;
            skillname = "heavy_attack";
            skill_target_type = battle_control.skill_target.ENEMY
                ;
        }

        public override void excute(units player, units enemy)
        {
            Debug.Log("heavy_attack");
            enemy.take_damege(player.damage*2);
        }
    }
    public class all_attack : skillbase
    {
        public all_attack()
        {
            cost = 2;
            skillname = "all_attack";
            skill_target_type = battle_control.skill_target.ENEMYTEAM;
                ;
        }

        public override void excute(units player, List<units> enemy)
        {
            Debug.Log("all_attack");
            foreach(units a in enemy)
            {
                a.take_damege(player.damage / 2);
            }
            
        }
    }
    public class speedup : skillbase
    {
        public speedup()
        {
            cost = 2;
            skillname = "speedup";
            skill_target_type = battle_control.skill_target.PLAYER;
                
        }

        public override void excute(units player, units enemy)
        {
            Debug.Log("speedup");
            enemy.get_buff(new buff.speedup(),5,2);
            
        }
    }
}
