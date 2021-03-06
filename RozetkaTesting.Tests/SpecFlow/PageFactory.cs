﻿using System;
using System.Linq;
using System.Reflection;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages;
using RozetkaTesting.WebPages.Helpers;
using RozetkaTesting.WebPages.PageComponents;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.SpecFlow
{
    public static class PageFactory
    {
        #region Public Methods

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
                t = (T) CreateContextBoundObject(typeof (T));
                ScenarioContext.Current.Set<T>(t);
            }

            ScenarioContext.Current.Set<BasePage>(t);
            return t;
        }

        /// <summary>
        /// Gets BasePage object with specified name.
        /// </summary>
        /// <param name="pageName">Page attribute name value.</param>
        /// <returns>BasePage instance.</returns>
        public static BasePage Get(string pageName)
        {
            BasePage basePage;
            if (ScenarioContext.Current.TryGetValue(out basePage) && basePage.GetPageNames().Contains(pageName))
            {
                return basePage;
            }

            Type pageType = ReflectionHelper.GetPageType(pageName);
            Object pageObj = CreateContextBoundObject(pageType);
            basePage = (BasePage) pageObj;

            ScenarioContext.Current.Set(pageObj, pageObj.ToString());
            ScenarioContext.Current.Set<BasePage>(basePage); // set as current page for reflection-based step bindings
            return basePage;
        }

        #endregion

        #region Private Methods

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

            if (parameterInfo.ParameterType == typeof (IDriver))
            {
                return FeatureContext.Current.Get<IDriver>();
            }

            if (parameterInfo.ParameterType == typeof (IPriceFilterComponent))
            {
                return new PriceFilterComponent();
            }

            if (parameterInfo.ParameterType == typeof (IResultPageComponent))
            {
                return new ResultPageComponent(FeatureContext.Current.Get<IDriver>());
            }

            if (parameterInfo.ParameterType == typeof (IHeaderComponent))
            {
                return new HeaderComponent();
            }

            else
            {
                return null;
            }
        }

        #endregion
    }
}