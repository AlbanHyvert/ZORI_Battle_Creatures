public static class Effects
{
    public enum E_Status
    {
        NONE = 0,
        PARALYSIS,
        BURN,
        FREEZE,
        POISON,
        SLEEP,
        DEAD
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

    public static E_Status TryStatus(E_Types[] zoriTypes, Capacity capacity)
    {
        int index = 0;

        for (int i = 0; i < zoriTypes.Length; i++)
        {
            if (zoriTypes[i] != capacity.Type)
            {
                index++;
            }
        }

        return index > 0 ? capacity.Effect : E_Status.NONE;
    }
}