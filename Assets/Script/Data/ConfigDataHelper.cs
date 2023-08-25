using Newtonsoft.Json;
using UnityEngine;

public class ConfigDataHelper 
{
    private static GameConfig gameConfig = null;
    public static GameConfig GameConfig
    {
        get
        {
            if (gameConfig == null)
                gameConfig = JsonConvert.DeserializeObject<GameConfig>(Resources.Load<TextAsset>("Data/GameConfig").text);
            return gameConfig;
        }
    }
    private static UserData userData = null;
    public static UserData UserData
    {
        get
        {
            if (!ES3.KeyExists(GameConstants.USERDATA))
            {
                userData = GetHeroClassData();
                ES3.Save(GameConstants.USERDATA, userData);
            }
            else
                userData = ES3.Load<UserData>(GameConstants.USERDATA);
            return userData;
        }
    }
    

    private static UserData GetHeroClassData()
    {
        UserData user = new UserData();
        user.data.Add("Hero1", GetHeroData());
        return user;
    }
    private static HeroData GetHeroData()
    {
        HeroData hero1 = new HeroData();
        hero1.heroClass = GameConfig.heroConfig.heroClass;
        Debug.Log(hero1.heroClass.Values);
        //hero1.attributes = GameConfig.heroConfig.heroClass.
        return hero1;
    }
}
