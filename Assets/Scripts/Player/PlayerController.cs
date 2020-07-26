using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private IAController _battlingZori = null;

    private E_Slots _move = E_Slots.A;

    public E_Slots GetMove { get { return _move; } }
    public E_Slots SetMove 
    { 
        set
        { 
            _move = value;
            _choosenAttack(_move);
        } 
    }

    private event Action<E_Slots> _choosenAttack = null;
    public event Action<E_Slots> ChoosenAttack
    {
        add
        {
            _choosenAttack -= value;
            _choosenAttack += value;
        }
        remove
        {
            _choosenAttack -= value;
        }
    }

    public IAController GetBattlingZori { get { return _battlingZori; } }

    private void Start()
    {
        PlayerManager.Instance.SetPlayer = this;
        _battlingZori.SetPlayer = this;
    }
}