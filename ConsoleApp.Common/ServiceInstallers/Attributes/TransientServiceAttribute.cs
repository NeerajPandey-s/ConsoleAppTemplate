﻿using System;

namespace ConsoleApp.Common.ServiceInstallers.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TransientServiceAttribute : Attribute
    {
    }
}