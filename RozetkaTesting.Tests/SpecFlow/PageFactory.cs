using System;
using System.Linq;
using System.Reflection;
using RozetkaTesting.Framework.Core;
using RozetkaTesting.WebPages;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.SpecFlow
{
    public static class PageFactory
    {
        /// <summary>
        /// Gets object of specified type from Scenario context or creates a new one, based on values available in Scenario and Feature contexts and sets it to Scenario context.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <returns>Object instance.</returns>
        public static T Get<T>() where T : BasePage
        {
            T t;
            if (!ScenarioContext.Current.TryGetValue(out t))
            {
                t = (T)CreateContextBoundObject(typeof(T));
                ScenarioContext.Current.Set<T>(t);
            }

            ScenarioContext.Current.Set<BasePage>(t);
            return t;
        }

        private static object CreateContextBoundObject(Type objectType)
        {
            ConstructorInfo[] ctors = objectType.GetConstructors();
            ConstructorInfo ctor = ctors.OrderBy(ci => ci.GetParameters().Length).Last();
            ParameterInfo[] ctorParams = ctor.GetParameters();
            object[] invokeParams = ctorParams.Select(FillFromContext).ToArray();

            try
            {
                return ctor.Invoke(invokeParams);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to execute constructor for " + objectType, ex);
            }
        }

        private static object FillFromContext(ParameterInfo parameterInfo)
        {
            if (parameterInfo.IsOptional)
            {
                return parameterInfo.DefaultValue;
            }

            if (parameterInfo.ParameterType == typeof (Driver))
            {
                return FeatureContext.Current.Get<Driver>();
            }
            else
            {
                return null;
            }
        }
    }
}