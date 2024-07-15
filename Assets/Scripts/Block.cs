using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(Deactivator))]

public class Block : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Deactivator _deactivator;

    private bool _isColorDefault = true;

    private void OnValidate()
    {
        if (_colorChanger == null || _colorChanger != GetComponent<ColorChanger>())
            _colorChanger = GetComponent<ColorChanger>();
    
        if (_deactivator == null || _deactivator != GetComponent<Deactivator>())
            _deactivator = GetComponent<Deactivator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFloorTouched(collision) == false)
            return;

        ChangeColor();
        _deactivator.Deactivate();
    }

    public void SetDefault()
    {
        _colorChanger.ChangeColorToDefault();
        _isColorDefault = true;
    }

    private bool isFloorTouched(Collision collision)
    {
        if (collision.transform.GetComponent<Floor>() == null)
            return false;

        return true;
    }

    private void ChangeColor()
    {
        if (_isColorDefault == false)
            return;

        _isColorDefault = false;
        _colorChanger.ChangeColor();
    }
}
