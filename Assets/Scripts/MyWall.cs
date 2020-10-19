using UnityEngine;

public class MyWall : MonoBehaviour
{
    private Color _defaultColor;

    [SerializeField] private Renderer _renderer;

    public void Awake()
    {
        _defaultColor = _renderer.material.color;
    }

    public void ResetColor()
    {
        _renderer.material.SetColor("_Color", _defaultColor);
    }

    public override string ToString()
    {
        return _defaultColor.ToString();
    }
}
