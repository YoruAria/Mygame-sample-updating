using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CreatMap : MonoBehaviour
{
    
    public int length;    
    public List<GameObject> mapType;
    
    

    

    private void Awake()
    {
        
        CreateMainMap(length, mapType,this.transform);
        List<MapInfo> checkStartOrEnd = new List<MapInfo>(transform.GetComponentsInChildren<MapInfo>());
        checkStartOrEnd[0].isFirstOrLast = true;
        checkStartOrEnd[checkStartOrEnd.Count - 1].isFirstOrLast = true;
        //transform.GetComponent<CreatChildMap>().CreateChildMap(length);
    }

    public static void CreateMainMap(int count,List<GameObject> maps,Transform father)

    {
        List<float> howMuchForEachOne = new List<float>();
        float posLength = 0;
        float allPersent = 0;
        List<int> randomArea = new List<int>();
        int totalPart = 0;
        

        

        for (int j = 0; j < maps.Count; j++)
        {
            
            howMuchForEachOne.Add(Random.Range(25, 100));
            randomArea.Add(j);
        }

        for (int k = 0;k < howMuchForEachOne.Count; k++)
        {
            allPersent += howMuchForEachOne[k];
        }
        
        for (int i = 0;i < howMuchForEachOne.Count; i++)
        {
            int a = randomArea[Random.Range(0, randomArea.Count)];           
            randomArea.Remove(a);
            int thisPart = Mathf.RoundToInt(count / (allPersent / howMuchForEachOne[a]));
            totalPart += thisPart;

            for (int p = 0; p < thisPart; p++)
            {
                if(totalPart > count && p == thisPart - 1)
                {
                    break;
                }
                GameObject b = Instantiate(maps[a],father);
                b.transform.position = new Vector3(posLength, 0, 0);
                posLength += 17.78f;
            }
            if(totalPart < count && i == howMuchForEachOne.Count - 1)
            {
                GameObject b = Instantiate(maps[a], father);
                b.transform.position = new Vector3(posLength, 0, 0);
            }
        }
        GameObject.Find("eventlist").GetComponent<event_load>().CreatLevelEvent();



    }

    



}
