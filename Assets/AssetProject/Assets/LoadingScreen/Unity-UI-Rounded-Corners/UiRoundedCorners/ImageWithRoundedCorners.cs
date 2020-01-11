using UnityEngine;

[ExecuteInEditMode]
internal class ImageWithRoundedCorners : MonoBehaviour
{
    private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

    public Material material;
    public float radius = 20;

    internal void Refresh()
    {
        var rect = ((RectTransform)transform).rect;
        material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
    }
}