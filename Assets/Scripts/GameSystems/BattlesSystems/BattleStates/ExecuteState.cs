using UnityEngine;
using System.Collections;
using System;

public class ExecuteState : BattleState
{
    public ExecuteState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    private bool m_playerTurnEnded = false;
    private bool m_ennemyTurnEnded = false;

    public override IEnumerator Start()
    {
        BattleFlowState.ControlPlayerConsole(false);
        m_playerTurnEnded = true ? BattleFlowState.GetPlayerChangeZori() : false;
        m_ennemyTurnEnded = true ? BattleFlowState.GetEnnemyChangeZori() : false;

        int playerSpeed = (int)(BattleFlowState.ZoriPlayer.Zori.GetAttackSpeed(BattleFlowState.GetPlayerCapacity()) * BattleFlowState.ZoriPlayer.Zori.GetBonusEffect.speedBonus);
        int ennemySpeed = (int)(BattleFlowState.ZoriEnnemy.Zori.GetAttackSpeed(BattleFlowState.GetEnnemyCapacity()) * BattleFlowState.ZoriEnnemy.Zori.GetBonusEffect.speedBonus);

        ennemySpeed = 2;
        CheckStatus(ref playerSpeed, ref ennemySpeed);


        if (playerSpeed >= ennemySpeed && !BattleFlowState.GetPlayerChangeZori())
        {
            BattleFlowState.StartCoroutine(PlayerAttack());
        }
        else if (!BattleFlowState.GetEnnemyChangeZori())
        {
            BattleFlowState.StartCoroutine(EnnemyAttack());
        }
        return null;
    }

    public IEnumerator PlayerAttack()
    {
        Debug.Log("Player turn");
        if (BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus == Effects.E_Status.FREEZE || BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus == Effects.E_Status.SLEEP)
        {
            DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, BattleFlowState.ZoriPlayer.Zori.Stats.nickname +
                " cannot attack this turn because he is " + BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus.ToString()
                , BattleFlowState.readingSpeed);

            m_playerTurnEnded = true;

            CheckEndedTurn();

            if (!BattleFlowState.battleEnded && !m_ennemyTurnEnded)
                BattleFlowState.StartCoroutine(EnnemyAttack());

            yield break;
        }

        if (!BattleFlowState.GetPlayerCapacity())
        {
            m_playerTurnEnded = true;

            CheckEndedTurn();

            yield break;
        }

        yield return new WaitForSecondsRealtime(0);

        DisplayText.Clear();

        if (BattleFlowState.GetPlayerCapacity().Style == E_Style.EFFECT)
        {
            switch (BattleFlowState.GetPlayerCapacity().Target)
            {
                case E_Target.SELF:
                    CheckSelfBonus(BattleFlowState.GetPlayerCapacity(), BattleFlowState.ZoriPlayer.Zori);
                    break;
                case E_Target.ENNEMY:
                    CheckSelfDebuff(BattleFlowState.GetPlayerCapacity(), BattleFlowState.ZoriEnnemy.Zori);
                    CheckBrutDamage(BattleFlowState.GetPlayerCapacity(), null, BattleFlowState.ZoriEnnemy.Zori);
                    break;
            }

            m_playerTurnEnded = true;

            CheckEndedTurn();

            if (!BattleFlowState.battleEnded && !m_ennemyTurnEnded)
                BattleFlowState.StartCoroutine(EnnemyAttack());

            yield break;
        }

        int brutDmg = CheckBrutDamage(BattleFlowState.GetPlayerCapacity(), BattleFlowState.ZoriPlayer.Zori);

        if (brutDmg > 0 && BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus == Effects.E_Status.SLEEP)
        {
            BattleFlowState.ZoriEnnemy.Zori.GetStatus.AllReset();
        }

        if(brutDmg > 0)
            BattleFlowState.ZoriEnnemy.Zori.Health.TakeDamage(DealActualDamage(brutDmg,
                BattleFlowState.GetPlayerCapacity(),BattleFlowState.ZoriPlayer.Zori , BattleFlowState.ZoriEnnemy.Zori));

        m_playerTurnEnded = true;

        ApplyStatus(BattleFlowState.GetPlayerCapacity(), BattleFlowState.ZoriEnnemy.Zori);

        CheckEndedTurn();

        if (!BattleFlowState.battleEnded && !m_ennemyTurnEnded)
            BattleFlowState.StartCoroutine(EnnemyAttack());
    }

    private void CheckSelfBonus(Capacity capacity, Zori zori)
    {
        zori.GetBonusEffect.SetAtkBonus(capacity.BonusStats.attack);
        zori.GetBonusEffect.SetDefBonus(capacity.BonusStats.def);
        zori.GetBonusEffect.SetSpeedBonus(capacity.BonusStats.speed);
        zori.GetBonusEffect.SetSpeAtkBonus(capacity.BonusStats.speAtk);
        zori.GetBonusEffect.SetSpeDefBonus(capacity.BonusStats.speDef);
    }

    private void CheckSelfDebuff(Capacity capacity, Zori zori)
    {
        zori.GetBonusEffect.SetAtkBonus(capacity.BonusStats.attack);
        zori.GetBonusEffect.SetDefBonus(capacity.BonusStats.def);
        zori.GetBonusEffect.SetSpeedBonus(capacity.BonusStats.speed);
        zori.GetBonusEffect.SetSpeAtkBonus(capacity.BonusStats.speAtk);
        zori.GetBonusEffect.SetSpeDefBonus(capacity.BonusStats.speDef);
    }

    public IEnumerator EnnemyAttack()
    {
        Debug.Log("Ennemy turn");
        if (BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus == Effects.E_Status.FREEZE || BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus == Effects.E_Status.SLEEP)
        {
            DisplayText.AddText(BattleFlowState.EnnemyHud.descriptionText, BattleFlowState.ZoriEnnemy.Zori.Stats.nickname +
                " cannot attack this turn because he is " + BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus.ToString()
                , BattleFlowState.readingSpeed);

            m_ennemyTurnEnded = true;

            yield return new WaitForSecondsRealtime(DisplayText.GetTotalDuration());

            CheckEndedTurn();

            if (!BattleFlowState.battleEnded && !m_playerTurnEnded)
                BattleFlowState.StartCoroutine(PlayerAttack());
            
            yield break;
        }

        if(!BattleFlowState.GetEnnemyCapacity())
        {
            m_ennemyTurnEnded = true;

            CheckEndedTurn();

            yield break;
        }

        DisplayText.AddText(BattleFlowState.EnnemyHud.descriptionText, BattleFlowState.ZoriEnnemy.Zori.Stats.nickname +
                " use " + BattleFlowState.GetEnnemyCapacity().Name + '.', BattleFlowState.readingSpeed);

        yield return new WaitForSecondsRealtime(DisplayText.GetTotalDuration());

        DisplayText.Clear();

        if(BattleFlowState.GetEnnemyCapacity().Style == E_Style.EFFECT)
        {
           
            switch (BattleFlowState.GetPlayerCapacity().Target)
            {
                case E_Target.SELF:
                    CheckSelfBonus(BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriEnnemy.Zori);
                    break;
                case E_Target.ENNEMY:
                    CheckBrutDamage(BattleFlowState.GetEnnemyCapacity(), null, BattleFlowState.ZoriPlayer.Zori);
                    break;
            }

            m_ennemyTurnEnded = true;

            CheckEndedTurn();

            if (!BattleFlowState.battleEnded && !m_playerTurnEnded)
                BattleFlowState.StartCoroutine(PlayerAttack());

            yield break;
        }

        int brutDmg = CheckBrutDamage(BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriEnnemy.Zori);

        if(brutDmg > 0 && BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus == Effects.E_Status.SLEEP)
        {
            BattleFlowState.ZoriPlayer.Zori.GetStatus.AllReset();
        }

        if(brutDmg > 0)
            BattleFlowState.ZoriPlayer.Zori.Health.TakeDamage(DealActualDamage(brutDmg, 
                BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriEnnemy.Zori, BattleFlowState.ZoriPlayer.Zori));

        m_ennemyTurnEnded = true;

        ApplyStatus(BattleFlowState.GetEnnemyCapacity(), BattleFlowState.ZoriPlayer.Zori);

        CheckEndedTurn();

        if (!BattleFlowState.battleEnded && !m_playerTurnEnded)
        {

            BattleFlowState.StartCoroutine(PlayerAttack());
        }
    }

    private void CheckEndedTurn()
    {
        if (!m_ennemyTurnEnded || !m_playerTurnEnded)
            return;

        Debug.Log("Turn ended");
        BattleFlowState.SetState(new EndTurnState(BattleFlowState));
    }

    private void CheckStatus(ref int playerSpeed, ref int ennemySpeed)
    {
        if (BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus != Effects.E_Status.NONE)
        {
            switch (BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus)
            {
                case Effects.E_Status.PARALYSIS:
                    playerSpeed = playerSpeed / 2;
                    break;
            }
        }

        if (BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus != Effects.E_Status.NONE)
        {
            switch (BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus)
            {
                case Effects.E_Status.PARALYSIS:
                    ennemySpeed = ennemySpeed / 2;
                    break;
            }
        }
    }

    private void ApplyStatus(Capacity senderCap, Zori receiver)
    {
        if (receiver.GetStatus.CurrentStatus != Effects.E_Status.NONE)
            return;

        receiver.GetStatus.ApplyEffect(senderCap);
    }

    private int CheckBrutDamage(Capacity capacity, Zori sender = null, Zori receiver = null)
    {
        if (!capacity)
            return 0;

        switch (capacity.Style)
        {
            case E_Style.EFFECT:
                if (receiver.GetStatus.CurrentStatus != Effects.E_Status.NONE)
                    break;

                ApplyStatus(capacity, receiver);
                break;
            case E_Style.PHYSICS:
                return capacity.Power * (int)(sender.Stats.attack * sender.GetBonusEffect.atkBonus);
            case E_Style.SPECIAL:
                return capacity.Power * (int)(sender.Stats.speAttack * sender.GetBonusEffect.speAtkBonus);
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
                return (int)(receiver.Stats.defence * receiver.GetBonusEffect.defBonus) * 50;
            case E_Style.SPECIAL:
                return (int)(receiver.Stats.speDefence * receiver.GetBonusEffect.speDefBonus) * 50;
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