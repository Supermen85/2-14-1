using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;

    private Queue<Block> _blocks = new Queue<Block>();
    
    public Block TakeBlock()
    {
        if (_blocks.Count == 0)
            CreateBlock();

        Block block = _blocks.Dequeue();

        Deactivator deactivator = block.GetComponent<Deactivator>();
        deactivator.Died += Enqueue;

        return block;
    }

    private void CreateBlock()
    {
        Block block = Instantiate(_blockPrefab, transform.position, Quaternion.identity);
        _blocks.Enqueue(block);
        block.gameObject.SetActive(false);
    }

    private void Enqueue(Block block)
    {
        _blocks.Enqueue(block);
        Deactivator deactivator = block.GetComponent<Deactivator>();
        deactivator.Died -= Enqueue;
    }
}