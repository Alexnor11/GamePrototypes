using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBasket; i++) 
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyd()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
