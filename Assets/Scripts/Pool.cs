using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private int _capacity = 20;

    private Queue<Block> _blocks = new Queue<Block>();
    
    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Block block = Instantiate(_blockPrefab, transform.position, Quaternion.identity);        
            _blocks.Enqueue(block);
            block.gameObject.SetActive(false);
        }
    }

    public Block TakeBlock()
    {
        Block block = _blocks.Dequeue();
        _blocks.Enqueue(block);

        return block;
    }
}