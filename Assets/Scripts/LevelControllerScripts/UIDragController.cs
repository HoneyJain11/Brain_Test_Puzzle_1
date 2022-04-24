using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragController : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas canvas;
    RectTransform rectTransform;
    public Level8Controller controller;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

 
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            this.gameObject.SetActive(false);
            controller.CounterUpdate();
        }
    }

}

