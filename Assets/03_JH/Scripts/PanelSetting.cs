using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSetting : MonoBehaviour
{
    Image img;
    RectTransform rect;
    public Scrollbar[] colorScroll;
    Scrollbar widthScroll;
    LineController lc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject panel = GameObject.Find("LinePanel");
        img = panel.GetComponent<Image>();
        rect = panel.GetComponent<RectTransform>();

        lc = GetComponent<LineController>(); 
         widthScroll = GameObject.Find("WidthScrollbar").GetComponent<Scrollbar>();

        IMG_Color();
        lc.width = widthScroll.value * 0.1f;
#if ENABLE_WINMD_SUPPORT
        transform.gameObject.SetActive(false);
#endif
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(img.transform.name);
        }
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
        rect.sizeDelta = new Vector2(330, widthScroll.value * 45);
        lc.width = widthScroll.value * 0.1f;
    }
  
    void IMG_Color()
    {
        img.color = new Color(colorScroll[0].value, colorScroll[1].value, colorScroll[2].value, colorScroll[3].value);
        lc.co = img.color;
    }
}
