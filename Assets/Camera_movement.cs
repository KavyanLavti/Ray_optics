using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Camera _camera;
    public float RotationSpeed = 10;
    //public Transform pivot;
    //LineRenderer _lineRenderer;
    void Awake()
    {
       _camera = GetComponentInChildren<Camera>();
       transform.rotation = Quaternion.identity;
       //_lineRenderer = GetComponent<LineRenderer>();
       // _lineRenderer.positionCount = 18;
    }
    private void Start()
    {
        //_lineRenderer.SetPosition(0, Vector3.zero);
        //_lineRenderer.SetPosition(1, new Vector3(-5, 0, 0));
        //_lineRenderer.SetPosition(2, new Vector3(-5, 0.05f, 0));
        //_lineRenderer.SetPosition(3, new Vector3(-5, -0.05f, 0));
        //_lineRenderer.SetPosition(4, new Vector3(-5, 0, 0));
        //_lineRenderer.SetPosition(5, new Vector3(-10, 0, 0));
        //_lineRenderer.SetPosition(6, new Vector3(-10, 0.05f, 0));
        //_lineRenderer.SetPosition(7, new Vector3(-10, -0.05f, 0));
        //_lineRenderer.SetPosition(8, new Vector3(-10, 0, 0));
        //_lineRenderer.SetPosition(9, new Vector3(5, 0, 0));
        //_lineRenderer.SetPosition(10, new Vector3(5, 0.05f, 0));
        //_lineRenderer.SetPosition(11, new Vector3(5, -0.05f, 0));
        //_lineRenderer.SetPosition(12, new Vector3(5, 0, 0));
        //_lineRenderer.SetPosition(13, new Vector3(10, 0, 0));
        //_lineRenderer.SetPosition(14, new Vector3(10, 0.05f, 0));
        //_lineRenderer.SetPosition(15, new Vector3(10, -0.05f, 0));
        //_lineRenderer.SetPosition(16, new Vector3(10, 0, 0));
        //_lineRenderer.SetPosition(17, Vector3.zero);
    }


    void Update()
    {
        {
            if (Input.mouseScrollDelta.y < 0 && _camera.orthographicSize < 30f)
            {
                _camera.orthographicSize++;
            }
            else if (Input.mouseScrollDelta.y > 0 && _camera.orthographicSize > 10f)
            {
                _camera.orthographicSize--;
            }
        }
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0f, -Time.deltaTime * RotationSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0f, Time.deltaTime * RotationSpeed, 0);
            }
        }
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                transform.rotation = Quaternion.identity;
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                transform.rotation = Quaternion.identity;
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                transform.rotation = Quaternion.identity;
                transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            }
        }
       //// if (Input.GetKeyDown(KeyCode.R))
       // {
       //     transform.rotation = Quaternion.identity;
       // }
    }
}
