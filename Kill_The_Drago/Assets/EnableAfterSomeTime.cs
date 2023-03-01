using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableAfterSomeTime : MonoBehaviour
{
    public float timer = 10f;

    public Text text;
    public SelfDestruct selfDestruct;

    private void Start() {
        text = GetComponent<Text>();
        selfDestruct = GetComponent<SelfDestruct>();
    }

	void Update () {
		timer -= Time.deltaTime;

		if(timer <= 0) {
			text.enabled = true;
            selfDestruct.enabled = true;
		}
	}
}
