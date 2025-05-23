using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            timer += Time.deltaTime;
            level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

            if (timer > (level == 0 ? 0.5f : 0.2f))
            {
                GameManager.instance.pool.Get(1);
                timer = 0;
                Spawn();
            }

            if (GameManager.instance.pool.prefabs.Length > 1)
            {
                GameManager.instance.pool.Get(1);
            }
        }
    }

    void Spawn()
    {
       GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
       enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spwanTime;
    public int health;
    public float speed;
}
