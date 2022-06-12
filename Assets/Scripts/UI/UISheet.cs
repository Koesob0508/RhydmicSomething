using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISheet : MonoBehaviour
{
    [SerializeField] SheetBuilder SheetBuilder;
    [SerializeField] GameObject SheetLineContent;
    [SerializeField] GameObject JoyStickBg;
    [SerializeField] GameObject DeckBg;

    [SerializeField] GameObject SheetLinePrefab;
    [SerializeField] GameObject NotePrefab;

    [SerializeField] bool isBuildMode = false;
    [SerializeField] bool isSet = false;

    public bool IsBuildMode { get => isBuildMode; private set => isBuildMode = value; }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isSet)
        {
            if (SheetBuilder.Sheet != null)
            {
                InitSheetUI(SheetBuilder.Sheet);
            }
        }
    }

    void InitSheetUI(Sheet sheet)
    {
        for (int i = 0; i < sheet.sheetLines.Count; i++)
        {
            var lineObject = Instantiate(SheetLinePrefab, SheetLineContent.transform);
            var lineScript = lineObject.GetComponent<UISheetLine>();
            lineScript.SetSheet(sheet);
            lineScript.SetSheetLine(sheet.sheetLines[i]);

            for (int j = 0; j < sheet.noteLength; j++)
            {
                var noteObject = Instantiate(NotePrefab, lineObject.transform);
                var noteScript = noteObject.GetComponent<UINote>();
                noteScript.SetSheet(sheet);
                noteScript.SetUISheet(this);
                noteScript.SetIndex(i, j);
            }
        }
    }

    public void StartSheetBuild()
    {
        IsBuildMode = true;
        JoyStickBg.gameObject.SetActive(false);
        DeckBg.gameObject.SetActive(true);
    }

    public void DoneSheetBuild()
    {
        IsBuildMode = false;
        JoyStickBg.gameObject.SetActive(true);
        DeckBg.gameObject.SetActive(false);
    }
}