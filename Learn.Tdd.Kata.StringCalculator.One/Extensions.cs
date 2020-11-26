using System;

namespace Learn.Tdd.Kata.StringCalculator.One
{
    public static class Extensions
    {
        public static void IgnoreException(this Action act)
        {
            try
            {
                act?.Invoke();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}