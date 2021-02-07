using UnityEngine;
using System.Collections;

public class ExecuteState : BattleState
{
    public ExecuteState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    private bool m_playerTurnEnded = false;
    private bool m_ennemyTurnEnded = false;

    public override IEnumerator Start()
    {
        Debug.Log("ExecuteTurn");

        BattleFlowState.ControlPlayerConsole(false);

        int playerSpeed = BattleFlowState.ZoriPlayer.Zori.GetAttackSpeed(BattleFlowState.GetPlayerCapacity());
        int ennemySpeed = BattleFlowState.ZoriEnnemy.Zori.GetAttackSpeed(BattleFlowState.GetEnnemyCapacity());

        CheckStatus(ref playerSpeed, ref ennemySpeed);

        if (playerSpeed >= ennemySpeed)
        {
            BattleFlowState.StartCoroutine(PlayerAttack());
        }
        else
        {
            BattleFlowState.StartCoroutine(EnnemyAttack());
        }
        return null;
    }

    public IEnumerator PlayerAttack()
    {
        if (!BattleFlowState.GetEnnemyCapacity())
        {
            DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, BattleFlowState.ZoriPlayer.Zori.Stats.nickname +
                " cannot attack this turn because he is " + BattleFlowState.ZoriPlayer.Zori.CurrentEffect.ToString()
                , BattleFlowState.readingSpeed);

            m_playerTurnEnded = true;

            CheckEndedTurn();

            yield break;
        }

        DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, BattleFlowState.ZoriPlayer.Zori.Stats.nickname +
                " use " + BattleFlowState.GetPlayerCapacity().Name + '.', BattleFlowState.readingSpeed);

        yield return new WaitForSecondsRealtime(DisplayText.GetTotalDuration());

        DisplayText.Clear();

        int brutDmg = CheckBrutDamage(BattleFlowState.GetPlayerCapacity(), BattleFlowState.ZoriPlayer.Zori);

        BattleFlowState.ZoriEnnemy.Zori.Health.TakeDamage(DealActualDamage(brutDmg,
            BattleFlowState.GetPlayerCapacity(),BattleFlowState.ZoriPlayer.Zori , BattleFlowState.ZoriEnnemy.Zori));

        m_playerTurnEnded = true;

        CheckEndedTurn();

        if (!BattleFlowState.battleEnded && !m_ennemyTurnEnded)
            BattleFlowState.StartCoroutine(EnnemyAttack());
    }

    public IEnumerator EnnemyAttack()
    {
        if(!BattleFlowState.GetEnnemyCapacity())
        {
            DisplayText.AddText(BattleFlowState.EnnemyHud.descriptionText, BattleFlowState.ZoriEnnemy.Zori.Stats.nickname +
                " cannot attack this turn because he is " + BattleFlowState.ZoriEnnemy.Zori.CurrentEffect.ToString()
                , BattleFlowState.readingSpeed);

            m_ennemyTurnEnded = true;

            CheckEndedTurn();

            yield break;
        }

        DisplayText.AddText(BattleFlowState.EnnemyHud.descriptionText, BattleFlowState.ZoriEnnemy.Zori.Stats.nickname +
                " use " + BattleFlowState.GetEnnemyCapacity().Name + '.', BattleFlowState.readingSpeed);

        yield return new WaitForSecondsRealtime(DisplayText.GetTotalDuration());

        DisplayText.Clear();

        int brutDmg = CheckBrutDamage(BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriEnnemy.Zori);

        BattleFlowState.ZoriPlayer.Zori.Health.TakeDamage(DealActualDamage(brutDmg, 
            BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriEnnemy.Zori, BattleFlowState.ZoriPlayer.Zori));

        m_ennemyTurnEnded = true;

        CheckEndedTurn();

        if (!BattleFlowState.battleEnded && !m_playerTurnEnded)
            BattleFlowState.StartCoroutine(PlayerAttack());
    }

    private void CheckEndedTurn()
    {
        if (!m_ennemyTurnEnded || !m_playerTurnEnded)
            return;

        BattleFlowState.SetState(new EndTurnState(BattleFlowState));
    }

    private void CheckStatus(ref int playerSpeed, ref int ennemySpeed)
    {
        if (BattleFlowState.ZoriPlayer.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriPlayer.Zori.CurrentEffect)
            {
                case Effects.E_Effects.PARALYSIS:
                    playerSpeed = playerSpeed / 2;
                    break;
                case Effects.E_Effects.BURN:
                    playerSpeed = (int)(playerSpeed * 0.2f);
                    break;
            }
        }

        if (BattleFlowState.ZoriPlayer.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriPlayer.Zori.CurrentEffect)
            {
                case Effects.E_Effects.PARALYSIS:
                    playerSpeed = playerSpeed / 2;
                    break;
                case Effects.E_Effects.BURN:
                    playerSpeed = (int)(playerSpeed * 0.2f);
                    break;
                default:
                    break;
            }
        }
    }

    private int CheckBrutDamage(Capacity capacity, Zori sender)
    {
        switch (capacity.Style)
        {
            case E_Style.EFFECT:
                //Afflict effect
                break;
            case E_Style.PHYSICS:
                return capacity.Power * (sender.Stats.attack * 1);
            case E_Style.SPECIAL:
                return capacity.Power * (sender.Stats.speAttack * 1);
        }

        return 0;
    }

    private int CheckBrutDefence(Capacity capacity, Zori receiver)
    {
        switch (capacity.Style)
        {
            case E_Style.EFFECT:
                //Afflict effect
                break;
            case E_Style.PHYSICS:
                return (receiver.Stats.defence * 1) * 50;
            case E_Style.SPECIAL:
                return (receiver.Stats.speDefence * 1) * 50;
        }

        return 0;
    }

    private int DealActualDamage(int actualDamage, Capacity capacity, Zori sender, Zori receiver)
    {
        float bonusDmg = sender.Stats.level * 0.4f + 2;
        float defenceValue = CheckBrutDefence(capacity, receiver);
        float dmg = ((actualDamage * bonusDmg) / defenceValue) + 2;

        float mult = CheckMultipliers(capacity.Type, receiver);

        float stab = CheckStab(capacity, sender);

        return (int)(dmg * stab * mult * BattleFlowState.ItemMult * BattleFlowState.FoodMult); 
    }

    private float CheckMultipliers(E_Types capacityType, Zori zori)
    {
        float mult = 1f;
        switch (capacityType)
        {
            case E_Types.NEUTRAL:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.SPECTRAL:
                            return 0f;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.PYRO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 2f;
                            break;
                        case E_Types.CRYO:
                            mult *= 2f;
                            break;
                        case E_Types.GEO:
                            mult *= 0.5f;
                            break;
                        case E_Types.INSECTO:
                            mult *= 2f;
                            break;
                        case E_Types.METAL:
                            mult *= 2f;
                            break;
                        case E_Types.LUMA:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.HYDRO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 2f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            mult *= 2f;
                            break;
                        default:
                            mult *= 1;
                            break;
                    }
                }
                return mult;
            case E_Types.PHYTO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 2f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.CRYO:
                            mult *= 0.5f;
                            break;
                        case E_Types.VENO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            mult *= 2f;
                            break;
                        case E_Types.AERO:
                            mult *= 0.5f;
                            break;
                        case E_Types.INSECTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.LUMA:
                            mult *= 2f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.ELECTRO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.HYDRO:
                            mult *= 2f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.ELECTRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            return 0f;
                        case E_Types.AERO:
                            mult *= 2f;
                            break;
                        case E_Types.METAL:
                            mult *= 2f;
                            break;
                        case E_Types.MENTAL:
                            mult *= 2f;
                            break;
                        case E_Types.LUMA:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.CRYO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 2f;
                            break;
                        case E_Types.CRYO:
                            mult *= 0.5f;
                            break;
                        case E_Types.AERO:
                            mult *= 0.5f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.LUMA:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.VENO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PHYTO:
                            mult *= 2f;
                            break;
                        case E_Types.VENO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            mult *= 0.5f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.MARTIAL:
                            mult *= 2f;
                            break;
                        case E_Types.MENTAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.SPECTRAL:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.GEO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 2f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.ELECTRO:
                            mult *= 2f;
                            break;
                        case E_Types.VENO:
                            mult *= 2f;
                            break;
                        case E_Types.GEO:
                            mult *= 0.5f;
                            break;
                        case E_Types.AERO:
                            return 0;
                        case E_Types.INSECTO:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.AERO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PHYTO:
                            mult *= 2f;
                            break;
                        case E_Types.ELECTRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.CRYO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            mult *= 0.5f;
                            break;
                        case E_Types.AERO:
                            mult *= 0.5f;
                            break;
                        case E_Types.INSECTO:
                            mult *= 2f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.INSECTO:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 2f;
                            break;
                        case E_Types.CRYO:
                            mult *= 0.5f;
                            break;
                        case E_Types.VENO:
                            mult *= 0.5f;
                            break;
                        case E_Types.AERO:
                            mult *= 0.5f;
                            break;
                        case E_Types.INSECTO:
                            mult *= 2f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.MARTIAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.MENTAL:
                            mult *= 2f;
                            break;
                        case E_Types.SPECTRAL:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.METAL:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.HYDRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.CRYO:
                            mult *= 2f;
                            break;
                        case E_Types.VENO:
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.MARTIAL:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.CRYO:
                            mult *= 2f;
                            break;
                        case E_Types.VENO:
                            mult *= 0.5f;
                            break;
                        case E_Types.GEO:
                            mult *= 2f;
                            break;
                        case E_Types.AERO:
                            mult *= 0.5f;
                            break;
                        case E_Types.METAL:
                            mult *= 2f;
                            break;
                        case E_Types.SPECTRAL:
                            return 0;
                        case E_Types.UMBRA:
                            mult *= 2f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.MENTAL:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.VENO:
                            mult *= 2f;
                            break;
                        case E_Types.INSECTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.MARTIAL:
                            mult *= 2f;
                            break;
                        case E_Types.MENTAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.UMBRA:
                            mult *= 0.5f;
                            break;
                        case E_Types.LUMA:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.SPECTRAL:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.NEUTRAL:
                            return 0;
                        case E_Types.MARTIAL:
                            return 0;
                        case E_Types.MENTAL:
                            mult *= 2f;
                            break;
                        case E_Types.SPECTRAL:
                            mult *= 2f;
                            break;
                        case E_Types.UMBRA:
                            mult *= 0.5f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
            case E_Types.UMBRA:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.INSECTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.METAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.MARTIAL:
                            mult *= 0.5f;
                            break;
                        case E_Types.MENTAL:
                            mult *= 2f;
                            break;
                        case E_Types.SPECTRAL:
                            mult *= 2f;
                            break;
                        case E_Types.UMBRA:
                            mult *= 0.5f;
                            break;
                        case E_Types.LUMA:
                            mult *= 2f;
                            break;
                        default:
                            break;
                    }
                }
                return mult;
            case E_Types.LUMA:
                for (int i = 0; i < zori.Types.Length; i++)
                {
                    switch (zori.Types[i])
                    {
                        case E_Types.PYRO:
                            mult *= 0.5f;
                            break;
                        case E_Types.PHYTO:
                            mult *= 0.5f;
                            break;
                        case E_Types.CRYO:
                            mult *= 2f;
                            break;
                        case E_Types.GEO:
                            mult *= 0.5f;
                            break;
                        case E_Types.SPECTRAL:
                            mult *= 2f;
                            break;
                        case E_Types.UMBRA:
                            mult *= 2f;
                            break;
                        default:
                            mult *= 1f;
                            break;
                    }
                }
                return mult;
        }
        return 1;
    }

    private float CheckStab(Capacity capacity, Zori sender)
    {
        for (int i = 0; i < sender.Types.Length; i++)
        {
            if (capacity.Type == sender.Types[i])
            {
                return  1.5f;
            }
        }

        return 1f;
    }
}