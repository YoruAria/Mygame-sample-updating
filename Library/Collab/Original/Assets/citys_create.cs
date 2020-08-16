using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citys_create : MonoBehaviour
{
     int citysnum = 15;

    // Start is called before the first frame update
    void Start()
    {

        List<int> citys = new List<int>();

        for (int i = 0; i < citysnum; i++)
        {

            
            GameObject p = Resources.Load("city") as GameObject;
            p = Instantiate(p);
            
            p.transform.position = new Vector3(Random.Range(-9, 10), Random.Range(-5, 6), -5);
            Ray ray = new Ray(p.transform.position, Vector3.forward);
            RaycastHit hit;
            
            


            if (Physics.Raycast(ray, out hit,10) == true)
            {
                Debug.Log(1);
                if (hit.collider == this.gameObject.GetComponent<Collider2D>())
                    citys.Add(i);
                else
                    Destroy(p);
                                   
            }

        }
    }
    private void Update()
    {
     
    }

}
