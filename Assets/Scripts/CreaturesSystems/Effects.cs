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

    public static bool CanBeAffected(E_Types[] zoriTypes, Capacity capacity)
    {
        int index = 0;

        for (int i = 0; i < zoriTypes.Length; i++)
        {
            switch (capacity.Effect)
            {
                case E_Status.PARALYSIS:
                    if (zoriTypes[i] == E_Types.ELECTRO)
                        index++;
                    break;
                case E_Status.BURN:
                    if (zoriTypes[i] == E_Types.PYRO)
                        index++;
                    break;
                case E_Status.FREEZE:
                    if (zoriTypes[i] == E_Types.CRYO)
                        index++;
                    break;
                case E_Status.POISON:
                    if (zoriTypes[i] == E_Types.VENO)
                        index++;
                    break;
                case E_Status.SLEEP:
                    if (zoriTypes[i] == E_Types.MENTAL)
                        index++;
                    break;
            }
        }

        return index == 0 ? true : false;
    }

    public static E_Status TryStatus(E_Types[] zoriTypes, Capacity capacity)
    {
        int index = 0;

        for (int i = 0; i < zoriTypes.Length; i++)
        {
            switch (capacity.Effect)
            {
                case E_Status.PARALYSIS:
                    if (zoriTypes[i] == E_Types.ELECTRO)
                        index++;
                    break;
                case E_Status.BURN:
                    if (zoriTypes[i] == E_Types.PYRO)
                        index++;
                    break;
                case E_Status.FREEZE:
                    if (zoriTypes[i] == E_Types.CRYO)
                        index++;
                    break;
                case E_Status.POISON:
                    if (zoriTypes[i] == E_Types.VENO)
                        index++;
                    break;
                case E_Status.SLEEP:
                    if (zoriTypes[i] == E_Types.MENTAL)
                        index++;
                    break;
            }
        }

        return index == 0 ? capacity.Effect : E_Status.NONE;
    }
}