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

	void Start ()
	{
		InvokeRepeating ("dropApple", 2f, secondsBetweenAppleDrops);
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

		newPos.Set (currentPos.x + speed * Time.deltaTime, currentPos.y, currentPos.z);
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
	}
}