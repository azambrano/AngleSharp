﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Html;
    using System;

    /// <summary>
    /// Represents the HTML details element.
    /// </summary>
    sealed class HtmlDetailsElement : HtmlElement, IHtmlDetailsElement
    {
        #region ctor

        /// <summary>
        /// Creates a new HTML details element.
        /// </summary>
        public HtmlDetailsElement(Document owner)
            : base(owner, Tags.Details, NodeFlags.Special)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the details element is open.
        /// </summary>
        public Boolean IsOpen
        {
            get { return GetOwnAttribute(AttributeNames.Open) != null; }
            set { SetOwnAttribute(AttributeNames.Open, value ? String.Empty : null); }
        }

        #endregion
    }
}
