using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongTimePanel : MonoBehaviour, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler
{
    private TMP_Text longTime;
    private TMP_Text meridiem;
    private TMP_Text longDate;
    private Image background;

    private string longTimeFormat;
    private string longDateFormat;

    private bool hasFocus;

    private void Awake()
    {
        this.longTime = base.gameObject.transform.Find("LongTime").GetComponent<TextMeshProUGUI>();
        this.meridiem = base.gameObject.transform.Find("Meridiem").GetComponent<TextMeshProUGUI>();
        this.longDate = base.gameObject.transform.Find("LongDate").GetComponent<TextMeshProUGUI>();
        this.background = base.gameObject.GetComponent<Image>();

        this.longTimeFormat = this.longTime.text;
        this.longDateFormat = this.longDate.text;

        var font = UnityEngine.Object.FindObjectOfType<FechaHora>().GetComponentInChildren<TextMeshProUGUI>().font;
        this.longTime.font = font;
        this.meridiem.font = font;
        this.longDate.font = font;
    }

    private void Update()
    {
        if (base.gameObject.activeSelf)
        {
            var timeNow = DateTime.Now;
            this.longTime.text = timeNow.ToString(this.longTimeFormat);
            this.meridiem.text = timeNow.ToString("tt");
            this.longDate.text = timeNow.ToString(this.longDateFormat);
        }
        if (!this.hasFocus && Input.GetMouseButtonUp(0))
        {
            this.OnHidePanel();
        }
    }

    public void OnShowPanel()
    {
        base.gameObject.SetActive(true);
        base.gameObject.transform.SetAsLastSibling();
    }

    public void OnHidePanel()
    {
        base.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.hasFocus = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.hasFocus = false;
    }

    public void SetTheme(UI_Theme theme)
    {
        this.longTime.color = theme.clockText;
        this.meridiem.color = theme.clockText;
        this.longDate.color = theme.clockText;
        this.background.color = theme.window_background;
    }
}