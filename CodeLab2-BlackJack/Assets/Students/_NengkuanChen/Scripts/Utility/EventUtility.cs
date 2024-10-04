using System;
using System.Collections.Generic;
using Students._NengkuanChen.Scripts.Utility;

namespace Utility
{
    
    public delegate void GameEventHandler(Object sender, GameEventArgs args);
    
    public static class EventUtility
    {
         private static Dictionary<Type, HashSet<GameEventHandler>> eventHandlers =
            new Dictionary<Type, HashSet<GameEventHandler>>();
        
        
        // /// <summary>
        // /// Thread safe
        // /// </summary>
        // /// <param name="sender"></param>
        // /// <param name="args"></param>
        // public static void Trigger(Object sender, GameEventArgs args)
        // {
        //     
        //     lock (eventHandlers)
        //     {
        //         if (!eventHandlers.TryGetValue(args.GetType(), out var handlers))
        //         {
        //             return;
        //         }
        //
        //         foreach (var handler in handlers)
        //         {
        //             Loom.QueueOnMainThread(() => handler(sender, args));
        //         }
        //     }
        // }
        
        /// <summary>
        /// Not thread safe. Must be called from the main thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void TriggerNow(Object sender, GameEventArgs args)
        {
            lock (eventHandlers)
            {
                if (!eventHandlers.TryGetValue(args.GetType(), out var handlers))
                {
                    return;
                }
                foreach (var handler in handlers)
                {
                    handler(sender, args);
                }
            }
        }
        
        
        public static void Subscribe(Type type, GameEventHandler handler)
        {
            if (!typeof(GameEventArgs).IsAssignableFrom(type))
            {
                Log.ThrowError($"{type} is not a GameEventArgs type.");
                return;
            }
            
            
            lock (eventHandlers)
            {
                if (!eventHandlers.TryGetValue(type, out var handlers))
                {
                    handlers = new HashSet<GameEventHandler>();
                    eventHandlers[type] = handlers;
                }

                handlers.Add(handler);
            }
            
        }
        
        
        public static void Unsubscribe(Type type, GameEventHandler handler)
        {
            if (!eventHandlers.TryGetValue(type, out var handlers))
            {
                Log.ThrowError($"{type} is not a GameEventArgs type, or {handler} has not been subscribed.");
                return;
            }

            lock (eventHandlers)
            {
                handlers.Remove(handler);
            }
        }
    }
}