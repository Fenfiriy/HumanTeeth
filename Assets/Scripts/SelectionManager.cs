using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    List<GameObject> selectedObjects = new List<GameObject>();
    [SerializeField]
    int maxCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                foreach (GameObject obj in selectedObjects)
                {
                    obj.GetComponent<Renderer>().material.color = Color.white;
                }
                selectedObjects.Clear();
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out DragNDrop dragAndDrop))
                {
                    if (!selectedObjects.Contains(hit.collider.gameObject))
                    {
                        if (selectedObjects.Count >= maxCount)
                        {
                            selectedObjects[0].GetComponent<Renderer>().material.color = Color.white;
                            selectedObjects.RemoveAt(0);
                        }
                        selectedObjects.Add(hit.collider.gameObject);
                        hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
                        selectedObjects.Remove(hit.collider.gameObject);
                    }
                }
            }

            foreach (GameObject obj in selectedObjects)
            {
                obj.GetComponent<DragNDrop>().MyOnMouseDown();
            }
        }

        if (Input.GetMouseButton(0))
        {
            foreach (GameObject obj in selectedObjects)
            {
                obj.GetComponent<DragNDrop>().MyOnMouseDrag();
            }
        }
    }
}
