﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    /// </summary>
    sealed class CssBorderImageSourceProperty : CssProperty
    {
        #region ctor

        internal CssBorderImageSourceProperty(CssStyleDeclaration rule)
            : base(PropertyNames.BorderImageSource, rule)
        {
        }

        #endregion

        #region Methods

        protected override Object GetDefault(IElement element)
        {
            return null;
        }

        protected override Object Compute(IElement element)
        {
            return Converters.OptionalImageSourceConverter.Convert(Value);
        }

        protected override Boolean IsValid(ICssValue value)
        {
            return Converters.OptionalImageSourceConverter.Validate(value);
        }

        #endregion
    }
}
