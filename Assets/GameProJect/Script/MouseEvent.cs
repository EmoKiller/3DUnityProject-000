using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour 
{
    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
    private void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }
}
