using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float killHeight= -20f;
    ApplePicker apScript;

	// Use this for initialization
	void Start ()
    {
        apScript = Camera.main.GetComponent<ApplePicker>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y <= killHeight)
		{
			Destroy (this.gameObject);
            apScript.appleDropped();
		}
	}
}
