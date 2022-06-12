using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISheet : MonoBehaviour
{
    SheetBuilder SheetBuilder;
    bool isSet = false;


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
                RefreshSheetUI();
            }
        }
    }

    void RefreshSheetUI()
    {
        foreach (var line in SheetBuilder.Sheet.sheetLines)
        {
            foreach (var note in line.notes)
            {

            }
        }
    }
}