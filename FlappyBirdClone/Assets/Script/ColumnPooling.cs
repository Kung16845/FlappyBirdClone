using UnityEngine;

public class ColumnPooling : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    public float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameManager.instance.isGameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
            // for (int i = 1; i < columnPoolSize; i++)
            // {
            //     columns[i - 1] = columns[i];
            // }
            // columns[columnPoolSize - 1] = columns[0];
        }
    }
    public void ResetColumns()
    {
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i].transform.position = objectPoolPosition;
        }
        currentColumn = 0;
        timeSinceLastSpawned = spawnRate; // So that a column spawns immediately after reset
    }
}
