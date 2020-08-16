using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citys_small_create : MonoBehaviour
{
    public int smallcitysnum;
    public float point_distance;

    // Start is called before the first frame update
    void Start()
    {

        List<Transform> trans = new List<Transform>();
        for (int i = 0;i<smallcitysnum; i++)
        {
            GameObject p = Resources.Load("city") as GameObject;
            p = Instantiate(p);

            p.transform.position = new Vector3(transform.position.x+Random.Range(-10.0f,10.0f), transform.position.y + Random.Range(-10.0f, 10.0f),-5);

            List<RaycastHit2D> hits = new List<RaycastHit2D>(Physics2D.RaycastAll(p.transform.position, new Vector2(0, 0)));
            if (hits.Count == 1)
            {
                foreach (RaycastHit2D hit in hits)
                {

                    if (hit.collider.CompareTag("background"))
                    {
                        trans.Add(p.transform);
                        foreach (Transform x in trans)
                        {
                            if (((p.transform.position - x.position).magnitude < point_distance) && ((p.transform.position - x.position).magnitude > 0))
                            {
                                smallcitysnum++;
                                trans.RemoveAt(trans.Count - 1);
                                Destroy(p);

                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        smallcitysnum++;
                        Destroy(p);
                    }
                }
            }
            else
            {
                smallcitysnum++;
                Destroy(p);
            }
        }
    }
   
}
