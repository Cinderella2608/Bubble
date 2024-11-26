using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject bubblePrefab;
    public float Spawn;
    private bool isSpawning = true;

    void Start()
    {
        int randomIndex = Random.Range(0, sprites.Length);

        if (randomIndex >= 0 && randomIndex < sprites.Length)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[randomIndex];
        }

        StartCoroutine(SpawnBubble());
    }

    IEnumerator SpawnBubble()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Spawn);
            CreateBubble();
        }
    }
    private void CreateBubble()
    {
        float randomX = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(randomX, -5f, 0);

        GameObject Bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        //Destroy(Bubble, 0.5f);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
    }
}
