using System;
using System.Collections;
using UnityEngine;

public class Deactivator : MonoBehaviour 
{
    [SerializeField] private int _timeToDieMin = 2;
    [SerializeField] private int _timeToDieMax = 5;

    public event Action<Block> Died;

    public void Deactivate()
    {
        StartCoroutine(Deactivation(GetRandomTime()));
    }

    private int GetRandomTime()
    {
        return UnityEngine.Random.Range(_timeToDieMax, _timeToDieMin + 1);
    }

    private IEnumerator Deactivation(int time)
    {
        int second = 1;
        var wait = new WaitForSeconds(second);

        while (time-- > 0)
            yield return wait;

        gameObject.SetActive(false);

        Block block = GetComponent<Block>();
        Died?.Invoke(block);
    }
}
