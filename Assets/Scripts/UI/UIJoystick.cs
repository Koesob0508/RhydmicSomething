using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform lever;
    RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    PlayerController PlayerController;
    private Vector2 inputVector;    // 추가
    private bool isInput;    // 추가


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        PlayerController = FindObjectOfType<PlayerController>(true);
    }

    void Update()
    {
        if (isInput)
        {
            PlayerController.Move(inputVector);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var rectPos = new Vector2(rectTransform.position.x, rectTransform.position.y);
        var inputDir = eventData.position - rectPos;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
        //var clampedDir = inputDir.magnitude < leverRange ? inputDir
        //    : inputDir.normalized * leverRange;
        inputVector = clampedDir.normalized;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isInput = false;
        lever.anchoredPosition = Vector2.zero;
    }

}