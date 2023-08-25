using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData
{
    public string name = "";
    public int level = 1;
    
    public Dictionary<HeroClassType, HeroClass> heroClass = new Dictionary<HeroClassType, HeroClass>();
    public Dictionary<AttributeType, BaseAttribute> attributes = new Dictionary<AttributeType, BaseAttribute>();
    public HeroData() { }
}
