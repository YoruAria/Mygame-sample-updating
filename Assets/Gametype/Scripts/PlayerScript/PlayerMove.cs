using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Transform player;
    private int times;
    private float totalLength;
    private bool isMoving = false;
    private Camera cmr;
    private Text debugText;
    private GameObject show;
    private NewBehaviourScript1.Node nod;
    private List<MapInfo> levels;
    private GameObject laseScene;

    private void Awake()
    {
        laseScene = GameObject.Find("map_test_empty");
    }
    private void Start()
    {
        cmr = GameObject.Find("Player_Camera").GetComponent<Camera>(); 
        player = this.transform;
        times = 0;
        totalLength = player.position.x;
        debugText = GameObject.Find("Text").GetComponent<Text>();
        show = GameObject.Find("event_show");
        show.SetActive(false);
        levels = new List<MapInfo>( GameObject.Find("MainMap").GetComponentsInChildren<MapInfo>());
        debugText.text = 1 + "英里";
        
    }
    // Update is called once per frame
    void Update()
    {
        if(times < levels.Count-1) 
        { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMoving == false &&show.activeInHierarchy == false) 
            {
                MoveForward();
            }
            
        }
        
        }
        if (isMoving == true && player.position.x < totalLength - 0.5)
        {
            player.position = Vector3.Lerp(transform.position, new Vector3(totalLength, player.position.y, 0), 0.8f);
        }
        else if (isMoving == true && player.position.x > totalLength - 0.5 )
        {
            player.position = new Vector3(totalLength, player.position.y, 0);

            isMoving = false;
            if(levels[times].isFirstOrLast == false)
            {
                show.SetActive(true);
                show.GetComponent<event_reader_new>().get_event(levels[times].event_node);
            }
            
        }



    }
    private void LateUpdate()
    {
        cmr.transform.position = new Vector3(  player.position.x + 3.58f,0,-10);
    }

    void MoveForward()
    {
        show.SetActive(false);
        totalLength += 17.78f;
        isMoving = true;
        times++;
        debugText.text = (times+1) + "英里";
   
    }
    public void ExitGameMode()
    {
        laseScene.SetActive(true);
        SceneManager.UnloadSceneAsync("Game");
    } 
    
}
