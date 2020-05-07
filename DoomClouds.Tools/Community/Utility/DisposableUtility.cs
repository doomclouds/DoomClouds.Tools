using System;

namespace DoomClouds.Tools.Community.Utility
{
    internal static class DisposableUtility
    {
        public static void Dispose<T>(ref T item)
            where T : class, IDisposable
        {
            if (item == null)
            {
                return;
            }

            item.Dispose();
            item = default(T);
        }
    }
}
