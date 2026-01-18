using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания я блок
    public GameObject applePrefab;
    // Скорость дыижения яблок
    public float speed = 1f;
    // Расстояние, направление движение яилони
    public float leftAndRightEge = 10f;
    // случайное изменения направления движения
    public float chanceToChangeDirections = 0.1f;
    // Частота создания яблок
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
        
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x > leftAndRightEge)
        {
            speed = -Mathf.Abs(speed); // Начать движение влево
        }
        else if (pos.x < -leftAndRightEge)
        {
            speed = Mathf.Abs(speed); // Начать движение вправо
        }
        
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
