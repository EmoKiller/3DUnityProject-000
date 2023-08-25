using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroController : MonoBehaviour
{
    
    [SerializeField] private TMP_Text heroClassChoose;
    [SerializeField] private TMP_Text sex;
    [SerializeField] private List<TMP_Text> textMeshPro;
    [SerializeField] private List<RuntimeAnimatorController> controller = new List<RuntimeAnimatorController>();
    [SerializeField] private int index = 0;
    [SerializeField] private Animator animator;
    
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
        UpdateInfomationHero();
        animator.runtimeAnimatorController = controller[0];
        

    }
    private void Start()
    {
        
    }
    public void Prev()
    {
        if (index <= 0)
            return;
        animator.runtimeAnimatorController = controller[--index];
        UpdateInfomationHero();
        
        
    }
    public void Next()
    {
        if (index >= controller.Count - 1)
            return;
        animator.runtimeAnimatorController = controller[++index];
        UpdateInfomationHero();
    }
    
    private void UpdateInfomationHero()
    {
        heroClassChoose.text = ((HeroClassType)index).ToString();
        for ( int i = 0; i <= textMeshPro.Count - 1; i++)
        {
            textMeshPro[i].text = ConfigDataHelper.GameConfig.heroConfig.heroClass[(HeroClassType)index].baseAttribute[(AttributeType)i].value.ToString();
        }
        
    }
}
