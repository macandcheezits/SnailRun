using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [System.Serializable]
    public struct SpawnableObject{
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;
    public float maxSpawnRate = 2f;
    public float minSpawnRate = 1f;

    private void OnEnable(){
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable(){
        CancelInvoke();
    }

    private void Spawn(){
        float spawnChance = Random.value;

        foreach(var obj in  objects){
            if(spawnChance < obj.spawnChance){
                Debug.Log("obj.spawnChance < spawnChance");
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }else{
                Debug.Log("obj.spawnChance >= spawnChance");
            }
            Debug.Log($"object spawn chance: {obj.spawnChance}");
            Debug.Log($"spawn chance: {spawnChance}");
            Debug.Log($"obstacle: {obj.prefab.name}");
            Debug.Log($"object is visible:{obj.prefab.GetComponent<SpriteRenderer>().isVisible}");

            spawnChance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}

