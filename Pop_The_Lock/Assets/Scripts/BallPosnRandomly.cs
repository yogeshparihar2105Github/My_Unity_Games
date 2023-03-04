using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPosnRandomly : MonoBehaviour
{
    [SerializeField] GameObject myLock;
    float radius;

    private void Start() {
        float diff_X = myLock.transform.position.x - transform.position.x;
        float diff_Y = myLock.transform.position.y - transform.position.y;

        radius = Mathf.Sqrt( (diff_X * diff_X) + (diff_Y * diff_Y) );
    }

    Vector3 BallPosn(GameObject center, float radius, int angle)
    {
        Vector3 ballPos = new Vector3();
 
        ballPos.x = center.transform.position.x + (radius * Mathf.Cos(angle*40 / (180f / Mathf.PI)));
        ballPos.y = center.transform.position.y + (radius * Mathf.Sin(angle*40 / (180f / Mathf.PI)));
        ballPos.z = 0;

        return ballPos;
    }

    [ContextMenu("chage")]
    public void ChangeTheBallPos() 
    { 
        int angle = Random.Range(0,360);

        transform.position = BallPosn(myLock, radius, angle);
    }


}
