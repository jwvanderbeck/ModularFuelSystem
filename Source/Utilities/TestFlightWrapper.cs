﻿using System;
using System.Reflection;

namespace RealFuels
{
    public static class TestFlightWrapper
    {
        private const BindingFlags tfBindingFlags = BindingFlags.Public | BindingFlags.Static;
        
        private static Type tfInterface = null;
        private static MethodInfo addInteropValue = null;

        static TestFlightWrapper()
        {
            tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore", false);
            if (tfInterface != null)
            {
                Type[] argumentTypes = new[] { typeof(Part), typeof(string), typeof(string), typeof(string) };
                addInteropValue = tfInterface.GetMethod("AddInteropValue", tfBindingFlags, null, argumentTypes, null);
            }
        }

        public static void AddInteropValue(Part part, string name, string value, string owner)
        {
            if (addInteropValue != null)
            {
                try
                {
                    object[] parameters = { part, name, value, owner };
                    addInteropValue.Invoke(null, parameters);
                }
                catch { }
            }
        }
    }
}
