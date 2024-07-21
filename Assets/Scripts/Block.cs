using System;
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
        ColorChanger colorChanger = GetComponent<ColorChanger>();
        Deactivator deactivator = GetComponent<Deactivator>();

        if (_colorChanger == null || _colorChanger != colorChanger)
            _colorChanger = colorChanger;

        if (_deactivator == null || _deactivator != deactivator)
            _deactivator = deactivator;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Floor>() != null)
        {
            ChangeColor();
            _deactivator.Deactivate();
        }
    }

    public void SetDefault()
    {
        _colorChanger.ChangeColorToDefault();
        _isColorDefault = true;
    }

    private void ChangeColor()
    {
        if (_isColorDefault == false)
            return;

        _isColorDefault = false;
        _colorChanger.ChangeColor();
    }
}
