using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private int stars;

    public int Coins => coins;
    public int Stars => stars;

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
    }

    public void AddStar()
    {
        stars++;
    }
}
