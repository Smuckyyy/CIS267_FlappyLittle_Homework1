using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 6f;

    private float lastY = 0f;
    public float variationLimit = 6f;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float newY = Random.Range(lastY - variationLimit, lastY + variationLimit);
        newY = Mathf.Clamp(newY, lowestPoint, highestPoint);

        Instantiate(pipe, new Vector3(transform.position.x, newY, 0), Quaternion.identity);
        lastY = newY;
    }
}
