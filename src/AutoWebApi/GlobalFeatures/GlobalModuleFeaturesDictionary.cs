﻿using System.Collections.Generic;

namespace AutoWebApi.GlobalFeatures
{
    public class GlobalModuleFeaturesDictionary : Dictionary<string, GlobalModuleFeatures>
    {
        public GlobalFeatureManager FeatureManager { get; }

        public GlobalModuleFeaturesDictionary(
            GlobalFeatureManager featureManager)
        {
            FeatureManager = featureManager;
        }
    }
}
