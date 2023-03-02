using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joyStick;
    public GameObject joyStickBackground;
    public Vector2 joyStickVector;

    private Vector2 joyStickTouchPos;
    private Vector2 joyStickOriginalPos;
    private float joyStickRaius;
    

    // Start is called before the first frame update
    void Start()
    {
        joyStickOriginalPos = joyStickBackground.transform.position;
        joyStickRaius = joyStickBackground.GetComponent<RectTransform>().sizeDelta.y / 4;
       
    }

    public void PointerDown()
    {
        joyStick.transform.position = Input.mousePosition;
        joyStickBackground.transform.position = Input.mousePosition;
        joyStickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joyStickVector = (dragPos - joyStickTouchPos).normalized;

        float joyStickDist = Vector2.Distance(dragPos, joyStickTouchPos);

        if(joyStickDist < joyStickRaius)
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVector * joyStickDist;
            
        }
        else
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVector * joyStickRaius;
    
        }

    }

    public void PointerUp()
    {
        joyStickVector = Vector2.zero;
        joyStick.transform.position = joyStickOriginalPos;
        joyStickBackground.transform.position = joyStickOriginalPos;
    }
    
}
