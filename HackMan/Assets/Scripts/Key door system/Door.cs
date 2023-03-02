using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public PlayerMovement thePlayer;
    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    [SerializeField] GameObject LevelCompletePanel;
    [SerializeField] GameObject GameOverPanel;
 
    public bool doorOpen, waitingToOpen;

    private void Awake()
    {
        LevelCompletePanel = GameObject.Find("Level Complete Panel");
        GameOverPanel = GameObject.Find("GAme Over Panel");
    }
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position)<0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }

        if (doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1.5f)
        {
            //Activate the Level Complete Panel 
            LevelCompletePanel.SetActive(true);
            //Deactivate the GameOverPanel
            GameOverPanel.SetActive(false);
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }

        }   
    }
}
