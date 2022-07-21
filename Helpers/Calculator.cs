namespace UltimateBannerMerging.Helpers
{
    public static class Calculator
    {
        public static float CalculateDealtDamageMultiplier(float quantity, int maxQuantity, int maxMultiplier)
        {
            return (maxMultiplier - 1) * quantity / maxQuantity + 1;
        }

        public static float CalculateReceivedDamageMultiplier(float quantity, int maxQuantity)
        {
            return 1 - quantity / maxQuantity;
        }

        public static int CalculateLootMultiplier(float quantity, int maxQuantity, int maxMultiplier)
        {
            return (int)((maxMultiplier - 1) * quantity / maxQuantity) + 1;
        }
    }
}
