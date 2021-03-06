﻿namespace AngleSharp.Xml
{
    using System;
    using System.Collections.Generic;
    using AngleSharp.Dom;

    /// <summary>
    /// Represents the standard XML markup formatter.
    /// </summary>
    public sealed class XmlMarkupFormatter : IMarkupFormatter
    {
        #region Instance

        /// <summary>
        /// An instance of the XmlMarkupFormatter.
        /// </summary>
        public static readonly IMarkupFormatter Instance = new XmlMarkupFormatter();

        #endregion

        #region Methods

        String IMarkupFormatter.CloseTag(IElement element, Boolean selfClosing)
        {
            return selfClosing ? String.Empty : String.Concat("</", element.NodeName, ">");
        }

        String IMarkupFormatter.Comment(IComment comment)
        {
            return String.Concat("<!--", comment.Data, "-->");
        }

        String IMarkupFormatter.Doctype(IDocumentType doctype)
        {
            var publicId = doctype.PublicIdentifier;
            var systemId = doctype.SystemIdentifier;
            var noExternalId = String.IsNullOrEmpty(publicId) && String.IsNullOrEmpty(systemId);
            var externalId = noExternalId ? String.Empty : " " + (String.IsNullOrEmpty(publicId) ?
                String.Concat("SYSTEM \"", systemId, "\"") :
                String.Concat("PUBLIC \"", publicId, "\" \"", systemId, "\""));
            return String.Concat("<!DOCTYPE ", doctype.Name, externalId, ">");
        }

        String IMarkupFormatter.OpenTag(IElement element, Boolean selfClosing)
        {
            var temp = Pool.NewStringBuilder();
            temp.Append(Symbols.LessThan).Append(element.NodeName);

            foreach (var attribute in element.Attributes)
                temp.Append(" ").Append(Stringify(attribute));

            if (selfClosing)
                temp.Append(" /");

            temp.Append(Symbols.GreaterThan);
            return temp.ToPool();
        }

        String IMarkupFormatter.Processing(IProcessingInstruction processing)
        {
            var value = String.Concat(processing.Target, " ", processing.Data);
            return String.Concat("<?", value, "?>");
        }

        String IMarkupFormatter.Text(String text)
        {
            var temp = Pool.NewStringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case Symbols.Ampersand: temp.Append("&amp;"); break;
                    case Symbols.GreaterThan: temp.Append("&gt;"); break;
                    case Symbols.LessThan: temp.Append("&lt;"); break;
                    default: temp.Append(text[i]); break;
                }
            }

            return temp.ToPool();
        }

        #endregion

        #region Helpers

        static String Stringify(IAttr attribute)
        {
            var value = attribute.Value;
            var temp = Pool.NewStringBuilder();
            temp.Append(attribute.Name);
            temp.Append(Symbols.Equality).Append(Symbols.DoubleQuote);

            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case Symbols.SingleQuote: temp.Append("&apos;"); break;
                    case Symbols.DoubleQuote: temp.Append("&quot;"); break;
                    default: temp.Append(value[i]); break;
                }
            }

            return temp.Append(Symbols.DoubleQuote).ToPool();
        }

        #endregion
    }
}
