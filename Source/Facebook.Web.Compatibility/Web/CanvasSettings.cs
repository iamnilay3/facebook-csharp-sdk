﻿using System;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Facebook.Web
{
    /// <summary>
    /// Represents the Facebook application's canvas settings.
    /// </summary>
    [Obsolete]
    [TypeForwardedFrom("Facebook.Web, Version=4.2.1.0, Culture=neutral, PublicKeyToken=58cb4f2111d1e6de")]
    public class CanvasSettings : ICanvasSettings
    {
        /// <summary>
        /// The base url of your application on Facebook.
        /// </summary>
        public Uri CanvasPageUrl { get; set; }

        /// <summary>
        /// Facebook pulls the content for your application's 
        /// canvas pages from this base url.
        /// </summary>
        public Uri CanvasUrl { get; set; }

        /// <summary>
        /// The url to return the user after they
        /// cancel authorization.
        /// </summary>
        public Uri AuthorizeCancelUrl { get; set; }

        private static ICanvasSettings current;

        /// <summary>
        /// Gets the FacebookSettings stored in the configuration file.
        /// </summary>
        public static ICanvasSettings Current
        {
            get
            {
                if (current == null)
                {
                    var settings = ConfigurationManager.GetSection("canvasSettings");
                    if (settings == null)
                    {
                        return null;
                    }
                    current = settings as CanvasConfigurationSettings;
                }
                return current;
            }
        }
    }
}