using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrajectoryCreator : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    {
        Hide();
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void UpdateDots(Vector3 ballPos, Vector3 force)
    {
        lineRenderer.SetPosition(0, ballPos);
        lineRenderer.SetPosition(1, new Vector3(force.x, ballPos.y, force.y));
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
