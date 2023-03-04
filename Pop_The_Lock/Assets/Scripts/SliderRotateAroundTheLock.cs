using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderRotateAroundTheLock : MonoBehaviour
{
    [SerializeField] GameObject myLock;
    [SerializeField] int speed;
    bool isTriggering = false;

    [SerializeField] BallPosnRandomly ballPosnRandomly;

    [SerializeField] GameObject lockHandel;
    [SerializeField] TextMeshProUGUI successText;

    [SerializeField] int success = 3;

    [SerializeField] GameObject restartButon;
    [SerializeField] GameObject nextLvlButon;


    private void Start() 
    {
        successText.text = success.ToString();
        lockHandel.transform.position = new Vector3(0, 0.3f, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.RotateAround(myLock.transform.position, Vector3.forward, speed * Time.deltaTime * 10f);

        if(isTriggering)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ChangeRotation_Dir();
                success--;
                successText.text = success.ToString();
                if(success < 1)
                {
                    print("You Win");
                    lockHandel.transform.position = new Vector3(0, 0.9f, 0);

                    Time.timeScale = 0;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    ballPosnRandomly.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                    nextLvlButon.SetActive(true);
                }
            }   
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 0;
                print("Game Over");
                myLock.GetComponent<SpriteRenderer>().color = Color.red;
                Camera.main.backgroundColor = Color.red;
                restartButon.SetActive(true);
                
            }   
        }
    }

    private void ChangeRotation_Dir()
    {
        ballPosnRandomly.ChangeTheBallPos();
        speed = speed * (-1);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        isTriggering = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        isTriggering = false;
    }

    IEnumerator waitAndPause()
    {
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        print("Game Over");
    }

}
