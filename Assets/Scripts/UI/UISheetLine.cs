using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISheetLine : MonoBehaviour, IPointerClickHandler
{
    private Sheet sheet;
    private SheetLine sheetLine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSheetLine(SheetLine sheetLine)
    {
        this.sheetLine = sheetLine;
    }

    public void SetSheet(Sheet sheet)
    {
        this.sheet = sheet;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}