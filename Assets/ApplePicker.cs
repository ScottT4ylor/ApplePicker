using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	void Start ()
    {
        basketList = new List<GameObject>();
        for (int i=0; i <numBaskets; i++)
        {
            GameObject basket = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            basket.transform.position = pos;
            basketList.Add(basket);
        }
	}
	
	void Update ()
    {
	
	}
    public void appleDropped()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject ap in appleArray)
        {
            Destroy(ap);
        }
        GameObject toDestroy = basketList[basketList.Count - 1];
        Destroy(toDestroy);//this will currently break since I don't have the game ending code yet.
        basketList.Remove(toDestroy);//also going to break
        if (basketList.Count <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}
