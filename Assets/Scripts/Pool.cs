using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;

    [SerializeField] private int _capacity = 20;

    private List<Block> _blocks = new List<Block>();
    
    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Block block = Instantiate(_blockPrefab, transform.position, Quaternion.identity);        
            _blocks.Add(block);
            block.gameObject.SetActive(false);
        }
    }

    public Block TakeBlock()
    {
        foreach (var block in _blocks)
            if (block.gameObject.activeSelf == false)
                return block;

        return null;
    }
}