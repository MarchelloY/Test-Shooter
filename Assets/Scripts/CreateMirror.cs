using UnityEngine;

public class CreateMirror : MonoBehaviour
{
    [SerializeField] private Renderer mirror;
    [SerializeField] private Camera mirrorCamera;

    private void Start()
    {
        var rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        mirrorCamera.targetTexture = rt;
        rt.Create();
        mirror.material.SetTexture("_MainTex", rt);
    }
}