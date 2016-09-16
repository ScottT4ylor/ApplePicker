using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{
	public GameObject applePrefab;
	public float speed = 2f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirection = 0.005f;
	public float secondsBetweenAppleDrops = 1f;
	private Vector3 currentPos;
	private Vector3 newPos;
    public static float difficulty;

    void Start ()
	{
		Invoke ("dropApple", 2f);
        difficulty = 1;
	}

	void Update ()
	{
		currentPos = transform.position;
		if (currentPos.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs (speed);
		}
		else if (currentPos.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs (speed);
		}

		newPos.Set (currentPos.x + speed * AppleTree.difficulty * Time.deltaTime, currentPos.y, currentPos.z);
		transform.position = newPos;
	}
	void FixedUpdate()
	{
		if (Random.value <= chanceToChangeDirection)
		{
			speed *= -1f;
		}
	}

	void dropApple()
	{
		GameObject apple = Instantiate (applePrefab, transform.position, Quaternion.identity) as GameObject;
		apple.transform.position = transform.position;
		StartCoroutine(dropDelay ());
	}

	IEnumerator dropDelay()
	{
		yield return new WaitForSeconds (2 / difficulty);
		dropApple ();
	}
}