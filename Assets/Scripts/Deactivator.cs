using System.Collections;
using UnityEngine;

public class Deactivator : MonoBehaviour 
{
    [SerializeField] private int _timeToDieMin = 2;
    [SerializeField] private int _timeToDieMax = 5;

    public void Deactivate()
    {
        StartCoroutine(Deactivation(GetRandomTime()));
    }

    private int GetRandomTime()
    {
        return Random.Range(_timeToDieMax, _timeToDieMin + 1);
    }

    private IEnumerator Deactivation(int time)
    {
        int second = 1;
        var wait = new WaitForSeconds(second);

        while (time-- > 0)
            yield return wait;

        gameObject.SetActive(false);
    }
}
