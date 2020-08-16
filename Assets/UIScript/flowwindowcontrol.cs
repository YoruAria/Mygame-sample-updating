using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class flowwindowcontrol : MonoBehaviour
{
    public GameObject detail;
    
    public void check()
    {
        string name = transform.parent.Find("nameofthecity").GetChild(0).GetComponent<Text>().text;
        GameObject d=Instantiate(detail);
        d.transform.Find("Panel/CityName").GetChild(0).GetComponent<Text>().text = name;
        citys_create.isopen = true;
        Destroy(this.transform.parent.parent.gameObject);
        

    }  

    public void totarget()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        citys_create.isopen = true;
        
        this.transform.parent.parent.parent.GetComponent<city_click>().controlcontrolclick();
        Destroy(this.transform.parent.parent.gameObject);
        
        
    }
    
    public void leave()
    {
        citys_create.isopen = true;
        Destroy(this.transform.parent.parent.gameObject);
    }

}
