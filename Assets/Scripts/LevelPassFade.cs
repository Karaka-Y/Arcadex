using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassFade : MonoBehaviour

{   [SerializeField]
    private float fadeIntence = 0.6f;
    private float panelAlpha;
    private float textAlpha;
    private Image image;
    private Text text;
    private Color textColor;
    private Color panelColor;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable(){
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        panelColor = image.color;
        textColor = text.color;
        panelAlpha = panelColor.a;
        textAlpha = textColor.a;
        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Fade(){
        yield return new WaitForSeconds(2);
        while (panelAlpha > 0.05f){
            panelAlpha -= fadeIntence * Time.deltaTime;
            textAlpha -= fadeIntence * Time.deltaTime;
        
        panelColor.a = panelAlpha;
        textColor.a = textAlpha;
        image.color = panelColor;
        text.color = textColor;
        if(panelAlpha <= 0.08f){
            ResetAlpha();
            this.gameObject.SetActive(false);
    
        }
        yield return null;}
    }
    private void ResetAlpha(){
        panelColor.a = 0.4980392f;
        textColor.a = 1.0f;
        image.color = panelColor;
        text.color = textColor;
    }
    
}
