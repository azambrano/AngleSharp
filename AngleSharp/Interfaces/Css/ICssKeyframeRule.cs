﻿namespace AngleSharp.DOM.Css
{
    using System;

    /// <summary>
    /// Represents the style rule for a single key.
    /// </summary>
    [DomName("CSSKeyframeRule")]
    public interface ICssKeyframeRule : ICssRule
    {
        /// <summary>
        /// Gets or sets the keyframe selector as a comma-separated list of percentage values.
        /// </summary>
        [DomName("keyText")]
        String KeyText { get; set; }

        /// <summary>
        /// Gets the style associated with this keyframe.
        /// </summary>
        [DomName("style")]
        CSSStyleDeclaration Style { get; }
    }
}