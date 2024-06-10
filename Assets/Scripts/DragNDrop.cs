using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    [SerializeField]
    Vector3 mousePosition;
    Vector3 offset;
    public void MyOnMouseDown()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            offset = transform.position - hit.point;
            mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(hit.point);
        }
    }

    public void MyOnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition) + offset;
    }
}
