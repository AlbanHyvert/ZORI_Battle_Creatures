using System.Collections.Generic;
using Utilities.Singleton;

public class ZoriDataManager : Singleton<ZoriDataManager>
{
    private List<ZoriData> _savedData = new List<ZoriData>();
    private List<Zori> _zoriList = new List<Zori>();
    private Dictionary<string, ZoriData> _datas = new Dictionary<string, ZoriData>();

    public void SaveData(Zori zori)
    {
        bool value = _datas.ContainsKey(zori.Data.Nickname);

        //If Dictionnary do not have the Key
        if(value == false)
        {
            //Add Data   
            _savedData.Add(zori.Data);
            _zoriList.Add(zori);
            _datas.Add(zori.Data.Nickname, zori.Data);
        }
        else
        {
            //Remove Data
            _savedData.Remove(zori.Data);
            _zoriList.Remove(zori);
            _datas.Remove(zori.Data.Nickname);
            
            //Add New Data
            _savedData.Add(zori.Data);
            _zoriList.Add(zori);
            _datas.Add(zori.Data.Nickname, zori.Data);
        }
    }

    public Dictionary<string, ZoriData> Datas()
        => _datas;
}