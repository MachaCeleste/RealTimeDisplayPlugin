using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeClock : MonoBehaviour
{
    private TMP_Text time;

    private string timeFormat;

    private Button button;

    private void Awake()
    {
        this.button = base.gameObject.transform.GetComponent<Button>();
        this.time = base.gameObject.transform.Find("Time").GetComponent<TextMeshProUGUI>();

        this.timeFormat = this.time.text;

        var font = UnityEngine.Object.FindObjectOfType<FechaHora>().GetComponentInChildren<TextMeshProUGUI>().font;
        this.time.font = font;

        this.button.onClick.AddListener(() =>
        {
            ShowPanel();
        });
    }

    private void Update()
    {
        var timeNow = DateTime.Now;
        this.time.text = timeNow.ToString(timeFormat);
    }

    private void ShowPanel()
    {
        UnityEngine.Object.FindObjectOfType<LongTimePanel>(true).OnShowPanel();
    }

    public void SetTheme(UI_Theme theme)
    {
        this.button.colors = new ColorBlock()
        {
            fadeDuration = 0.1f,
            colorMultiplier = 1,
            normalColor = theme.clockText,
            pressedColor = theme.clockText,
            highlightedColor = theme.clockTextHighlight,
            selectedColor = theme.clockTextHighlight,
            disabledColor = Color.white
        };
    }
}