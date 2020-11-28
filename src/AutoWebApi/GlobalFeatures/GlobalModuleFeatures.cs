using AutoWebApi.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AutoWebApi.GlobalFeatures
{
    public abstract class GlobalModuleFeatures
    {
        public GlobalFeatureManager FeatureManager { get; }

        protected GlobalFeatureDictionary AllFeatures { get; }

        protected GlobalModuleFeatures(
            GlobalFeatureManager featureManager)
        {
            FeatureManager = featureManager;
            AllFeatures = new GlobalFeatureDictionary();
        }

        public virtual void Enable<TFeature>()
            where TFeature : GlobalFeature
        {
            GetFeature<TFeature>().Enable();
        }

        public virtual void Disable<TFeature>()
            where TFeature : GlobalFeature
        {
            GetFeature<TFeature>().Disable();
        }

        public virtual void SetEnabled<TFeature>(bool isEnabled)
            where TFeature : GlobalFeature
        {
            GetFeature<TFeature>().SetEnabled(isEnabled);
        }

        public virtual void Enable(string featureName)
        {
            GetFeature(featureName).Enable();
        }

        public virtual void Disable(string featureName)
        {
            GetFeature(featureName).Disable();
        }

        public virtual void SetEnabled(string featureName, bool isEnabled)
        {
            GetFeature(featureName).SetEnabled(isEnabled);
        }

        public virtual void EnableAll()
        {
            foreach (var feature in AllFeatures.Values)
            {
                feature.Enable();
            }
        }

        public virtual void DisableAll()
        {
            foreach (var feature in AllFeatures.Values)
            {
                feature.Disable();
            }
        }

        public virtual GlobalFeature GetFeature(string featureName)
        {
            var feature = AllFeatures.GetOrDefault(featureName);
            if (feature == null)
            {
                throw new Exception($"There is no feature defined by name '{featureName}'.");
            }

            return feature;
        }

        public virtual TFeature GetFeature<TFeature>()
            where TFeature : GlobalFeature
        {
            return (TFeature) GetFeature(GlobalFeatureNameAttribute.GetName<TFeature>());
        }

        public virtual IReadOnlyList<GlobalFeature> GetFeatures()
        {
            return AllFeatures.Values.ToImmutableList();
        }

        protected void AddFeature(GlobalFeature feature)
        {
            AllFeatures[feature.FeatureName] = feature;
        }
    }
}
