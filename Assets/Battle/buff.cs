using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{
    [System.Serializable]
    // Start is called before the first frame update
    public class buffbase
    {
        public units buffobj;
        public string buffname;
        public float buff_value;
        public int countdown;
        public void set_buff_value(float buffv,int count,units u)
        {
            buff_value = buffv;
            countdown = count;
            buffobj = u;
        }
        public void count_reduce()
        {
            countdown--;
            if(countdown==0)
            {
                buff_over();
            }
        }
        public virtual void buff_ex()
        {

        }
        public virtual void buff_over()
        {

        }
    }
    public class speedup:buffbase
    {
        public speedup()
        {
            buffname = "speedup";
        }
        public override void buff_ex()
        {
            buffobj.speed += (int)buff_value;
        }
        public override void buff_over()
        {
            buffobj.speed -= (int)buff_value;
        }
    }
}
