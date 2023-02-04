using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner ;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();


    }
    private void OnTriggerExit ( Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject , 2 );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefap;
    
    public void SpawnObstacles()
    {
        int obtacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obtacleSpawnIndex).transform;
        Instantiate(obstaclePrefap , spawnPoint.position , Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    public void SpawnCoins()
    {
        int coinsToSpawn = 1;
        for (int i = 0  ; i  <  coinsToSpawn  ; i++){
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider(Collider Collider)
    {
       Vector3 point = new Vector3(
        Random.Range(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.x),
        Random.Range(GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.max.y),
        Random.Range(GetComponent<Collider>().bounds.min.z, GetComponent<Collider>().bounds.max.z)
       ) ;
       if (point != GetComponent<Collider>().ClosestPoint(point))
       {
        point = GetRandomPointInCollider(GetComponent<Collider>());
       }
       point.y = 1;
       return point;
    }
}
