using UnityEngine;

public class DiceBlock : MonoBehaviour
{
    public int Roll()
    {
        return Random.Range(1, 11);
    }
}
