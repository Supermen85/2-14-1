using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _material;

    private void OnValidate()
    {
        if (_renderer == null || _renderer != GetComponent<MeshRenderer>())
            _renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColorToDefault()
    {
        _renderer.material = _defaultMaterial;
    }

    public void ChangeColor()
    {
        _renderer.material = _material;
    }
}
