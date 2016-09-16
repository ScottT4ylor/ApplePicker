using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float killHeight= -20f;
    ApplePicker apScript;
    private static Vector3 gravity;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        gravity = new Vector3(0, -9.8f, 0);
        apScript = Camera.main.GetComponent<ApplePicker>();
        rb = gameObject.GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        rb.AddForce(gravity * AppleTree.difficulty, ForceMode.Acceleration);
    }
	
	void Update ()
	{
		if (transform.position.y <= killHeight)
		{
			apScript.appleDropped();
			Destroy (this.gameObject);
		}
	}
}
