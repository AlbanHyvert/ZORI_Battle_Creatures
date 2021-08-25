using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item
{
    private static uint current_id = 1;

    private uint m_id;
    private string m_name;
    private E_Pocket m_pocket;
    private E_ObjectType m_type;
    private string m_effect;
    private string m_description;
    private uint m_purschasing_price;
    private uint m_sales_price;

    public uint ID { get => m_id; }
    public string Name { get => m_name; }
    public E_Pocket PocketObject { get => m_pocket; }
    public E_ObjectType TypeObject { get => m_type; }
    public string Effect { get => m_effect; }
    public string Descrption { get => m_description; }
    public uint PurchasingPrice { get => m_purschasing_price; }
    public uint SalePrice { get => m_sales_price; }


    public void Init(string name, E_Pocket pocket, E_ObjectType type, string effect, string description, uint purschasing_price, uint sales_price)
    {
        m_id = current_id++;
        m_name = name;
        m_pocket = pocket;
        m_type = type;
        m_effect = effect;
        m_description = description;
        m_purschasing_price = purschasing_price;
        m_sales_price = sales_price;
    }
}
