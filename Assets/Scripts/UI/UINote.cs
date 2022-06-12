using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINote : MonoBehaviour, IPointerClickHandler
{
    private Image Image;
    private UISheet UISheet;
    private Sheet sheet;
    private int lineIndex;
    private int noteIndex;

    // Use this for initialization
    void Start()
    {
        Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetIndex(int _lineIndex, int _noteIndex)
    {
        lineIndex = _lineIndex;
        noteIndex = _noteIndex;
    }

    public void SetSheet(Sheet sheet) => this.sheet = sheet;
    public void SetUISheet(UISheet uISheet) => this.UISheet = uISheet;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!UISheet.IsBuildMode) return;

        switch (sheet.GetNoteType(lineIndex, noteIndex))
        {
            case Define.eNoteType.none:
                if (sheet.UseNote(lineIndex, noteIndex))
                {
                    Image.color = Color.green;
                }
                break;
            case Define.eNoteType.On:
                if (sheet.ReturnNote(lineIndex, noteIndex))
                {
                    Image.color = Color.gray;
                }
                break;
        }
    }
}