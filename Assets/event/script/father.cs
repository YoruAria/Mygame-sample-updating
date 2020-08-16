using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class father : MonoBehaviour
{
    // Start is called before the first frame update
    public Value value;
   public EnemyDataCreate enemyDataCreate;
    public List<units_attribute> enemylist;
    public GameObject Battlescene;
    private void Start()
    {
        
    }
    public void battle_start()
    {
        Instantiate(Battlescene);
        battle_control bc = GameObject.Find("Battle_control").GetComponent<battle_control>();
        
        bc.init(null, enemylist);

    }
    public virtual void execute(string num)
    {

    }
}
