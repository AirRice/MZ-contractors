using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseoverUI : MonoBehaviour
{
    public GameObject ElementToShow;

    //Taken from https://discussions.unity.com/t/onmouseover-ui-button-c/166886
    private bool mouse_over = false;

    // Start is called before the first frame update
    void Start()
    {
        ElementToShow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_over)
        {
            ElementToShow.SetActive(true);
            Debug.Log("Mouse Over");
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        
        Debug.Log("Mouse Enter");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
        mouse_over =false;
 
        Debug.Log("Mouse Exit");
    }
}
