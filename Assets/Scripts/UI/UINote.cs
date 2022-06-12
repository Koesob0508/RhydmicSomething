using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINote : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image Image;
    [SerializeField] UISheet UISheet;
    [SerializeField] Sheet sheet;
    [SerializeField] int lineIndex;
    [SerializeField] int noteIndex;

    // Use this for initialization
    void Awake()
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

        ChangeImageColor(sheet.GetNoteType(_lineIndex, _noteIndex) == Define.eNoteType.On);
    }

    public void SetSheet(Sheet sheet) => this.sheet = sheet;
    public void SetUISheet(UISheet uISheet) => this.UISheet = uISheet;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!UISheet.IsBuildMode) return;

        switch (sheet.GetNoteType(lineIndex, noteIndex))
        {
            case Define.eNoteType.Off:
                if (sheet.UseNote(lineIndex, noteIndex))
                    ChangeImageColor(true);
                break;
            case Define.eNoteType.On:
                if (sheet.ReturnNote(lineIndex, noteIndex))
                    ChangeImageColor(false);
                break;
        }
    }

    void ChangeImageColor(bool isOn)
    {
        if (isOn)
            Image.color = Color.green;
        else
            Image.color = Color.gray;
    }
}