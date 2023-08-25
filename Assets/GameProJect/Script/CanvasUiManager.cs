using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Collections.Specialized.BitVector32;

public class CanvasUiManager : Singleton<CanvasUiManager>
{
    

    [Header("Text")]
    //[SerializeField] private TextMeshProUGUI hpPoint;
    //[SerializeField] private TextMeshProUGUI mpPoint;
    //[SerializeField] private TextMeshProUGUI spPoint;
    [SerializeField] private TMP_Text hpPoint;
    [SerializeField] private TMP_Text mpPoint;
    [SerializeField] private TMP_Text spPoint;
    [Header("Slider")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private Slider staminaSlider;

    public TMP_Text HPPoint => hpPoint;
    public TMP_Text MPPoint => mpPoint;
    public TMP_Text SPPoint => spPoint;
    public Slider HPSlider => healthSlider;
    public Slider MPSlider => manaSlider;
    public Slider SPSlider => staminaSlider;
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       
    }
    public void Reduce(Slider slider, TMP_Text text,float reduce)
    {
        slider.value -= reduce;
        text.text = ((int)slider.value).ToString();
    }
    public void Regenerate(Slider slider, TMP_Text text, float reduce)
    {
        slider.value += reduce;
        text.text = ((int)slider.value).ToString();
    }
}
