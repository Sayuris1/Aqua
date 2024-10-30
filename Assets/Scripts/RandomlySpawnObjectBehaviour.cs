using System.Collections;
using UnityEngine;

public class RandomlySpawnObjectBehaviour : MonoBehaviour
{
   public GameObject ObjectToSpawn;

   public float TryInterval = 0.5f;
   public float Probability = 0.2f;
   public float CooldownTime = 2;

   private float _timeSinceLastSpawn = 0;

    private void Awake()
    {
        StartCoroutine(SpawnCorotuine());
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;        
    }

    private IEnumerator SpawnCorotuine()
    {
        while (true)
        {
            yield return new WaitForSeconds(TryInterval);

            if(_timeSinceLastSpawn < CooldownTime
                || Random.Range(0, 1f) > Probability)
                continue;
            
            Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
