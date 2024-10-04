namespace Students._NengkuanChen.Scripts.Utility
{
    public static class Log
    {
        public static void Info(string message)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            UnityEngine.Debug.Log(message);
#endif
        }

        public static void Warning(string message)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            UnityEngine.Debug.LogWarning(message);
#endif
        }

        public static void ThrowError(string message)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            UnityEngine.Debug.LogError(message);
#endif
        }

    }
}