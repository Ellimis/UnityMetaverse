using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform drawPositionSource;
    public float lineWidth = 0.03f;
    public GameObject brush;
    public Material lineMaterial;
    public float distanceThreshold = 0.05f;

    private List<Vector3> currentLinePositions = new List<Vector3>();
    private LineRenderer currentLine;

    public void StartDrawing()
    {
        GameObject lineGameObject = new GameObject("Line");
        currentLine = lineGameObject.AddComponent<LineRenderer>();

        currentLinePositions.Add(drawPositionSource.position);
        currentLine.positionCount = currentLinePositions.Count;
        currentLine.SetPositions(currentLinePositions.ToArray());

        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;
    }

    public void StopDrawing()
    {
        currentLinePositions.Clear();
        currentLine = null;
    }

    public void UpdateDrawing()
    {
        if (!currentLine || currentLinePositions.Count == 0)
            return;

        Vector3 lastSetPosition = currentLinePositions[currentLinePositions.Count - 1];
        if(Vector3.Distance(lastSetPosition, drawPositionSource.position) > distanceThreshold)
        {
            UpdateLine();
        }
    }

    public void UpdateLine()
    {
        currentLinePositions.Add(drawPositionSource.position);
        currentLine.positionCount = currentLinePositions.Count;
        currentLine.SetPositions(currentLinePositions.ToArray());

        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;
    }

    public void SetLineMaterial(Material newMat)
    {
        brush.GetComponent<Renderer>().material = newMat;
        lineMaterial = newMat;
    }
}
