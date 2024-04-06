using UnityEngine;

public class LineDrawingTool : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 previousPosition;
    private bool isDrawing = false;

    void Start()
    {
        DrawWithLineRenderer();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        DrawWithLineRenderer();
    }

    void DrawWithLineRenderer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0) && isDrawing)
        {
            AddPointToLine();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 1;
        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, new Vector3(previousPosition.x, previousPosition.y, 0));
    }

    void AddPointToLine()
    {
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, previousPosition) > 0.1f) // Adjust sensitivity as needed
        {
            previousPosition = currentPosition;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(currentPosition.x, currentPosition.y, 0));
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
    }
}