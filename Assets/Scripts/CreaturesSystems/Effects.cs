public static class Effects
{
    public enum E_Effects
    {
        PARALYSIS = 0,
        BURN,
        FREEZE,
        POISON,
        SLEEP,
        NONE
    }

    public static bool CanBeAffected(E_Types[] zoriTypes, E_Types capacityType)
    {
        int index = 0;

        for (int i = 0; i < zoriTypes.Length; i++)
        {
            if(zoriTypes[i] != capacityType)
            {
                index++;
            }
        }

        return index > 0 ? true : false;
    }
}