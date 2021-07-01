using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSetting : MonoBehaviour
{
    Image img;
    RectTransform rect;
    Scrollbar[] colorScroll;
    Scrollbar widthScroll;
    LineController lc;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        GameObject getScroll = GameObject.Find("ColorScrollbars");
        colorScroll = new Scrollbar[getScroll.transform.childCount];
        for (int i = 0; i < getScroll.transform.childCount; i++)
            colorScroll[i] = getScroll.transform.GetChild(i).GetComponent<Scrollbar>();

        lc = GetComponent<LineController>();

        widthScroll = GameObject.Find("WidthScrollbar").GetComponent<Scrollbar>();

        IMG_Color();
        lc.width = widthScroll.value * 0.1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(img.transform.name);
        }
    }

    void IMG_Color()
    {
        img.color = new Color(colorScroll[0].value, colorScroll[1].value, colorScroll[2].value, colorScroll[3].value);
        lc.co = img.color;
    }

    public void SetColor_R()
    {
        IMG_Color();
    }
    public void SetColor_G()
    {
        IMG_Color();
    }
    public void SetColor_B()
    {
        IMG_Color();
    }
    public void SetColor_A()
    {
        IMG_Color();
    }

    public void SetWidth()
    {
        rect.sizeDelta = new Vector2(100, widthScroll.value * 45);
        lc.width = widthScroll.value * 0.1f;
    }
}
