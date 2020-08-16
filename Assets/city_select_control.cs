using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class city_select_control : MonoBehaviour
{
    
    public enum state { INIT,SELECTCITY,SELECTBEHAVE,INROAD};
    public state stat;

    public citys_create csr;
    public List<Transform> countryspos;
    private void Start()
    {
        stat = state.INIT;
        countryspos = csr.countryspos;
        System.Random rd = new System.Random();
        int index = rd.Next(countryspos.Count);
        var initc = countryspos[index];
        initc.gameObject.GetComponent<city_click>().controlcontrolclick();
    }

    void init_city()
    {

    }
    
}
