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

                if (row[11] == E_ZoriRarity.COMMON.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.COMMON;
                }
                else if (row[11] == E_ZoriRarity.UNCOMMON.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.UNCOMMON;
                }
                else if (row[11] == E_ZoriRarity.RARE.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.RARE;
                }
                else if (row[11] == E_ZoriRarity.VERYRARE.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.VERYRARE;
                }
                else if (row[11] == E_ZoriRarity.SEMIRARE.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.SEMIRARE;
                }
                else if (row[11] == E_ZoriRarity.LEGENDARY.ToString())
                {
                    zoriData.Rarity = E_ZoriRarity.LEGENDARY;
                }

                if (row[12] == E_Regions.EAST.ToString())
                {
                    zoriData.Region = E_Regions.EAST;
                }
                else if (row[12] == E_Regions.WEST.ToString())
                {
                    zoriData.Region = E_Regions.WEST;
                }
                else if (row[12] == E_Regions.SOUTH.ToString())
                {
                    zoriData.Region = E_Regions.SOUTH;
                }
                else if (row[12] == E_Regions.NORTH.ToString())
                {
                    zoriData.Region = E_Regions.NORTH;
                }

                if (row[13] == E_ZoriTypes.AERO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.AERO;
                }
                else if (row[13] == E_ZoriTypes.CRYO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.CRYO;
                }
                else if (row[13] == E_ZoriTypes.ELECTRO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.ELECTRO;
                }
                else if (row[13] == E_ZoriTypes.GEO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.GEO;
                }
                else if (row[13] == E_ZoriTypes.HYDRO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.HYDRO;
                }
                else if (row[13] == E_ZoriTypes.INSECTO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.INSECTO;
                }
                else if (row[13] == E_ZoriTypes.LUMA.ToString())
                {
                    zoriData.Type = E_ZoriTypes.LUMA;
                }
                else if (row[13] == E_ZoriTypes.UMBRA.ToString())
                {
                    zoriData.Type = E_ZoriTypes.UMBRA;
                }
                else if (row[13] == E_ZoriTypes.MARTIAL.ToString())
                {
                    zoriData.Type = E_ZoriTypes.MARTIAL;
                }
                else if (row[13] == E_ZoriTypes.MENTAL.ToString())
                {
                    zoriData.Type = E_ZoriTypes.MENTAL;
                }
                else if (row[13] == E_ZoriTypes.METAL.ToString())
                {
                    zoriData.Type = E_ZoriTypes.METAL;
                }
                else if (row[13] == E_ZoriTypes.SPECTRAL.ToString())
                {
                    zoriData.Type = E_ZoriTypes.SPECTRAL;
                }
                else if (row[13] == E_ZoriTypes.PYRO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.PYRO;
                }
                else if (row[13] == E_ZoriTypes.PHYTO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.PHYTO;
                }
                else if (row[13] == E_ZoriTypes.NEUTRAL.ToString())
                {
                    zoriData.Type = E_ZoriTypes.NEUTRAL;
                }
                else if (row[13] == E_ZoriTypes.VENO.ToString())
                {
                    zoriData.Type = E_ZoriTypes.VENO;
                }

                _zoriDataList.Add(zoriData);
            }
        }
    }
}