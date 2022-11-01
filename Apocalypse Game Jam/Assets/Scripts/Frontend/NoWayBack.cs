using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoWayBack : MonoBehaviour
{
    private float risingText;
    private float risingEffect;
    public Image effect;
    public TextMeshProUGUI text;
    

    // Start is called before the first frame update
    void Start()
    {
        risingText = 0.05f;
        risingEffect = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        float alphaE = System.Math.Max(0, System.Math.Min(effect.color.a + Time.deltaTime * risingEffect, 1));
        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, alphaE);
        if (alphaE == 1) {
            risingEffect = -0.2f;
        } else if (alphaE == 0) {
            risingEffect = 0.2f;
        }

        float alphaT = System.Math.Max(0, System.Math.Min(text.color.a + Time.deltaTime * risingText, 1));
        text.color = new Color(text.color.r, text.color.g, text.color.b, alphaT);
        if (alphaT == 1) {
            risingText = -0.05f;
        } else if (alphaT == 0) {
            risingText = 0.05f;
        }
    }
}
