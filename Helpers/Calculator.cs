namespace UltimateBannerMerging.Helpers;

public class DamageCalculator
{
    private readonly int _maxQuantity;

    private readonly int _maxDamageMultiplier;

    private readonly int _maxLootMultiplier;

    public DamageCalculator(int maxQuantity, int maxDamageMultiplier, int maxLootMultiplier)
    {
        _maxQuantity = maxQuantity;
        _maxDamageMultiplier = maxDamageMultiplier;
        _maxLootMultiplier = maxLootMultiplier;
    }
    public float CalculateDealtDamageMultiplier(float quantity)
    {
        return (_maxDamageMultiplier - 1) * quantity / _maxQuantity + 1;
    }

    public float CalculateReceivedDamageMultiplier(float quantity)
    {
        return 1 - quantity / _maxQuantity;
    }

    public int CalculateLootMultiplier(float quantity)
    {
        return (int)((_maxLootMultiplier - 1) * quantity / _maxQuantity) + 1;
    }
}
