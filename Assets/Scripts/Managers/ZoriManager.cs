using Engine.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class ZoriManager : Singleton<ZoriManager>
{
    [SerializeField] private List<ZoriID> _zoriIDList = new List<ZoriID>();
    [SerializeField] private TextAsset _zoriFile = null;
    
    private List<ZoriData> _zoriDataList = new List<ZoriData>();

    public List<ZoriID> ZoriIDList { get => _zoriIDList; }
    public List<ZoriData> ZoriDataList { get => _zoriDataList; }

    private void Start()
    {
        string[] data = _zoriFile.text.Split(new char[] { '\n' });

        Debug.Log(data.Length);

        for (int i = 1; i < data.Length -1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });
            ZoriData zoriData = new ZoriData();

            if (row[1] != "")
            {
                int ID = 0;
                int baseAtk = 0;
                int maxAtk = 0;
                int baseDef = 0;
                int maxDef = 0;
                int baseHP = 0;
                int maxHP = 0;
                int level = 0;
                int experience = 0;
                int speed = 0;

                int.TryParse(row[0], out ID);
                int.TryParse(row[2], out baseAtk);
                int.TryParse(row[3], out maxAtk);
                int.TryParse(row[4], out baseDef);
                int.TryParse(row[5], out maxDef);
                int.TryParse(row[6], out baseHP);
                int.TryParse(row[7], out maxHP);
                int.TryParse(row[8], out level);
                int.TryParse(row[9], out experience);
                int.TryParse(row[10], out speed);

                zoriData.ID = ID;
                zoriData.Name = row[1];
                zoriData.Attack.Minimum = baseAtk;
                zoriData.Attack.Maximum = maxAtk;
                zoriData.Defence.Minimum = baseDef;
                zoriData.Defence.Maximum = maxDef;
                zoriData.HP.Minimum = baseHP;
                zoriData.HP.Maximum = maxHP;
                zoriData.Level = level;
                zoriData.Experience = experience;
                zoriData.Speed = speed;

                if (row[11] == ZoriRarityEnums.COMMON.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.COMMON;
                }
                else if (row[11] == ZoriRarityEnums.UNCOMMON.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.UNCOMMON;
                }
                else if (row[11] == ZoriRarityEnums.RARE.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.RARE;
                }
                else if (row[11] == ZoriRarityEnums.VERYRARE.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.VERYRARE;
                }
                else if (row[11] == ZoriRarityEnums.SEMIRARE.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.SEMIRARE;
                }
                else if (row[11] == ZoriRarityEnums.LEGENDARY.ToString())
                {
                    zoriData.Rarity = ZoriRarityEnums.LEGENDARY;
                }

                if (row[12] == RegionEnums.EAST.ToString())
                {
                    zoriData.Region = RegionEnums.EAST;
                }
                else if (row[12] == RegionEnums.WEST.ToString())
                {
                    zoriData.Region = RegionEnums.WEST;
                }
                else if (row[12] == RegionEnums.SOUTH.ToString())
                {
                    zoriData.Region = RegionEnums.SOUTH;
                }
                else if (row[12] == RegionEnums.NORTH.ToString())
                {
                    zoriData.Region = RegionEnums.NORTH;
                }

                if (row[13] == ZoriTypeEnums.AERO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.AERO;
                }
                else if (row[13] == ZoriTypeEnums.CRYO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.CRYO;
                }
                else if (row[13] == ZoriTypeEnums.ELECTRO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.ELECTRO;
                }
                else if (row[13] == ZoriTypeEnums.GEO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.GEO;
                }
                else if (row[13] == ZoriTypeEnums.HYDRO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.HYDRO;
                }
                else if (row[13] == ZoriTypeEnums.INSECTO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.INSECTO;
                }
                else if (row[13] == ZoriTypeEnums.LUMA.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.LUMA;
                }
                else if (row[13] == ZoriTypeEnums.UMBRA.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.UMBRA;
                }
                else if (row[13] == ZoriTypeEnums.MARTIAL.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.MARTIAL;
                }
                else if (row[13] == ZoriTypeEnums.MENTAL.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.MENTAL;
                }
                else if (row[13] == ZoriTypeEnums.METAL.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.METAL;
                }
                else if (row[13] == ZoriTypeEnums.SPECTRAL.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.SPECTRAL;
                }
                else if (row[13] == ZoriTypeEnums.PYRO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.PYRO;
                }
                else if (row[13] == ZoriTypeEnums.PHYTO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.PHYTO;
                }
                else if (row[13] == ZoriTypeEnums.NEUTRAL.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.NEUTRAL;
                }
                else if (row[13] == ZoriTypeEnums.VENO.ToString())
                {
                    zoriData.Type = ZoriTypeEnums.VENO;
                }

                _zoriDataList.Add(zoriData);
            }
        }

        Debug.Log("zoriDataListSize : " + _zoriDataList.Count);

        for (int i = 0; i < _zoriDataList.Count; i++)
        {
            Debug.Log("file number : " + i + " " + _zoriDataList[i].Rarity);
        }
    }
}