using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Pool))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private float _delay = 0.5f;

    private void OnValidate()
    {
        Pool pool = GetComponent<Pool>();

        if (_pool == null || _pool != pool)
            _pool = pool;
    }

    private void Start()
    {
        StartCoroutine(Timer(_delay));
    }

    private IEnumerator Timer(float delay)
    {
        bool isRunning = true;
        
        var wait = new WaitForSeconds(delay);

        while (isRunning)
        {
            SpawnBlock();
            yield return wait;
        }
    }

    private void SpawnBlock()
    {
        Block block = _pool.TakeBlock();
        block.SetDefault();
        block.transform.position = GetRandomPosition();
        block.gameObject.SetActive(true);
    }

    private Vector3 GetRandomPosition()
    {
        int PosY = 10;

        int min = 0;
        int max = 20;

        int deltaX = Random.Range(min, max);
        int deltaZ = Random.Range(min, max);

        Vector3 position = new Vector3(transform.position.x + deltaX, PosY, transform.position.z + deltaZ);

        return position;
    }
}