using UnityEngine.UI.Extensions;
using UnityEngine;

public class DrawPathUI : MonoBehaviour
{
    [SerializeField]
    private UILineRenderer uiLineRenderer;

    [SerializeField]
    private RectTransform[] points;

    private void Start()
    {
        uiLineRenderer = GetComponent<UILineRenderer>();

        Draw();
    }

    [ContextMenu("Draw")]
    private void Draw()
    {
        if (uiLineRenderer != null && points.Length > 1)
        {
            uiLineRenderer.Points = new Vector2[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                uiLineRenderer.Points[i] = points[i].anchoredPosition;
            }
        }
    }
}