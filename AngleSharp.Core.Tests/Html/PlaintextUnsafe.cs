﻿using AngleSharp.Dom;
using NUnit.Framework;

namespace AngleSharp.Core.Tests
{
    [TestFixture]
    public class PlaintextUnsafeTests
    {
        [Test]
        public void IllegalCodepointForNumericEntity()
        {
            var doc = DocumentBuilder.Html(@"FOO&#x000D;ZOO");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO\rZOO", dochtml0body1Text0.TextContent);
        }

        [Test]
        public void NullCharacterAfterHtml()
        {
            var doc = DocumentBuilder.Html("<html>" + Symbols.Null.ToString() + "<frameset></frameset>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(0, dochtml0frameset1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0frameset1.Attributes.Count);
            Assert.AreEqual("frameset", dochtml0frameset1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0frameset1.NodeType);
        }

        [Test]
        public void NullCharacterWithSpacesAfterHtml()
        {
            var doc = DocumentBuilder.Html("<html> " + Symbols.Null.ToString() + " <frameset></frameset>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(0, dochtml0frameset1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0frameset1.Attributes.Count);
            Assert.AreEqual("frameset", dochtml0frameset1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0frameset1.NodeType);
        }

        [Test]
        public void NullCharacterWithCharactersAfterHtml()
        {
            var doc = DocumentBuilder.Html("<html>a" + Symbols.Null.ToString() + "a<frameset></frameset>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("aa", dochtml0body1Text0.TextContent);
        }

        [Test]
        public void DoubleNullCharactersAfterHtml()
        {
            var doc = DocumentBuilder.Html(@"<html>" + Symbols.Null.ToString() + Symbols.Null.ToString() + "<frameset></frameset>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(0, dochtml0frameset1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0frameset1.Attributes.Count);
            Assert.AreEqual("frameset", dochtml0frameset1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0frameset1.NodeType);
        }

        [Test]
        public void NullCharacterWithLinebreakAfterHtml()
        {
            var doc = DocumentBuilder.Html("<html>" + Symbols.Null.ToString() + @"
 <frameset></frameset>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(0, dochtml0frameset1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0frameset1.Attributes.Count);
            Assert.AreEqual("frameset", dochtml0frameset1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0frameset1.NodeType);
        }

        [Test]
        public void PlaintextWithFillerText()
        {
            var doc = DocumentBuilder.Html(@"<plaintext>□filler□text□".Replace('□', Symbols.Null));

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1plaintext0 = dochtml0body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml0body1plaintext0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1plaintext0.Attributes.Count);
            Assert.AreEqual("plaintext", dochtml0body1plaintext0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1plaintext0.NodeType);

            var dochtml0body1plaintext0Text0 = dochtml0body1plaintext0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1plaintext0Text0.NodeType);
            Assert.AreEqual("�filler�text�".Replace('�', Symbols.Replacement), dochtml0body1plaintext0Text0.TextContent);

        }

        [Test]
        public void NullCharacterInCDataWithFillerInSvg()
        {
            var doc = DocumentBuilder.Html("<svg><![CDATA[" + Symbols.Null.ToString() + 
                "filler" + Symbols.Null.ToString() + "text" + Symbols.Null.ToString() + "]]>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml0body1svg0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1svg0.Attributes.Count);
            Assert.AreEqual("svg", dochtml0body1svg0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1svg0.NodeType);

            var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1svg0Text0.NodeType);
            Assert.AreEqual("�filler�text�".Replace('�', Symbols.Replacement), dochtml0body1svg0Text0.TextContent);
        }

        [Test]
        public void NullCharacterInComment()
        {
            var doc = DocumentBuilder.Html(@"<body><!" + Symbols.Null.ToString() + ">");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1child = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(0, dochtml0body1child.ChildNodes.Length);
            Assert.AreEqual(Symbols.Replacement.ToString(), dochtml0body1child.TextContent);
            Assert.AreEqual(NodeType.Comment, dochtml0body1child.NodeType);
        }

        [Test]
        public void NullAndOtherCharactersInComment()
        {
            var doc = DocumentBuilder.Html(@"<body><!" + Symbols.Null.ToString() + "filler" + Symbols.Null.ToString() + "text>");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Comment = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(0, dochtml0body1Comment.ChildNodes.Length);
            Assert.AreEqual("�filler�text".Replace('�', Symbols.Replacement), dochtml0body1Comment.TextContent);
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment.NodeType);
        }

        [Test]
        public void NullCharactersInForeignObjectInSvg()
        {
            var doc = DocumentBuilder.Html(@"<body><svg><foreignObject>" + Symbols.Null.ToString() + "filler" + Symbols.Null.ToString() + "text");

            var dochtml0 = doc.ChildNodes[0] as Element;
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml0body1svg0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1svg0.Attributes.Count);
            Assert.AreEqual("svg", dochtml0body1svg0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1svg0.NodeType);

            var dochtml0body1svg0foreignObject0 = dochtml0body1svg0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml0body1svg0foreignObject0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1svg0foreignObject0.Attributes.Count);
            Assert.AreEqual("foreignObject", dochtml0body1svg0foreignObject0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1svg0foreignObject0.NodeType);

            var dochtml0body1svg0foreignObject0Text0 = dochtml0body1svg0foreignObject0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1svg0foreignObject0Text0.NodeType);
            Assert.AreEqual("fillertext", dochtml0body1svg0foreignObject0Text0.TextContent);
        }

        [Test]
        public void PreTagStartingWithTwoEmptyLines()
        {
            var doc = DocumentBuilder.Html(@"<!DOCTYPE html><pre>

A</pre>");

            var doctype = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(doctype);
            Assert.AreEqual(NodeType.DocumentType, doctype.NodeType);
            Assert.AreEqual(@"html", doctype.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1pre0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1pre0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1pre0.Attributes.Count);
            Assert.AreEqual("pre", dochtml1body1pre0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1pre0.NodeType);

            var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1pre0Text0.NodeType);
            Assert.AreEqual("\nA", dochtml1body1pre0Text0.TextContent);
        }

        [Test]
        public void PreTagStartingWithOneEmptyLine()
        {
            var doc = DocumentBuilder.Html(@"<!DOCTYPE html><pre>
A</pre>");

            var doctype = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(doctype);
            Assert.AreEqual(NodeType.DocumentType, doctype.NodeType);
            Assert.AreEqual(@"html", doctype.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1pre0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1pre0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1pre0.Attributes.Count);
            Assert.AreEqual("pre", dochtml1body1pre0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1pre0.NodeType);

            var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1pre0Text0.NodeType);
            Assert.AreEqual("A", dochtml1body1pre0Text0.TextContent);
        }

        [Test]
        public void NullCharacterInMathTextInMathTag()
        {
            var doc = DocumentBuilder.Html(@"<!DOCTYPE html><table><tr><td><math><mtext>" + Symbols.Null.ToString() + "a");

            var doctype = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(doctype);
            Assert.AreEqual(NodeType.DocumentType, doctype.NodeType);
            Assert.AreEqual(@"html", doctype.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0.Attributes.Count);
            Assert.AreEqual("table", dochtml1body1table0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0.NodeType);

            var dochtml1body1table0tbody0 = dochtml1body1table0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0tbody0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0tbody0.Attributes.Count);
            Assert.AreEqual("tbody", dochtml1body1table0tbody0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0tbody0.NodeType);

            var dochtml1body1table0tbody0tr0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0tbody0tr0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0tbody0tr0.Attributes.Count);
            Assert.AreEqual("tr", dochtml1body1table0tbody0tr0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0tbody0tr0.NodeType);

            var dochtml1body1table0tbody0tr0td0 = dochtml1body1table0tbody0tr0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0tbody0tr0td0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0tbody0tr0td0.Attributes.Count);
            Assert.AreEqual("td", dochtml1body1table0tbody0tr0td0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

            var dochtml1body1table0tbody0tr0td0math0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0tbody0tr0td0math0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0tbody0tr0td0math0.Attributes.Count);
            Assert.AreEqual("math", dochtml1body1table0tbody0tr0td0math0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0tbody0tr0td0math0.NodeType);

            var dochtml1body1table0tbody0tr0td0math0mtext0 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1table0tbody0tr0td0math0mtext0.Attributes.Count);
            Assert.AreEqual("mtext", dochtml1body1table0tbody0tr0td0math0mtext0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0.NodeType);

            var dochtml1body1table0tbody0tr0td0math0mtext0Text0 = dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mtext0Text0.NodeType);
            Assert.AreEqual("a", dochtml1body1table0tbody0tr0td0math0mtext0Text0.TextContent);
        }

        [Test]
        public void NullCharacterAfterLetterInMathIdentifier()
        {
            var doc = DocumentBuilder.Html(@"<!DOCTYPE html><math><mi>a" + Symbols.Null.ToString() + "b");

            var doctype = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(doctype);
            Assert.AreEqual(NodeType.DocumentType, doctype.NodeType);
            Assert.AreEqual(@"html", doctype.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1math0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1math0.Attributes.Count);
            Assert.AreEqual("math", dochtml1body1math0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1math0.NodeType);

            var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1math0mi0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1math0mi0.Attributes.Count);
            Assert.AreEqual("mi", dochtml1body1math0mi0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1math0mi0.NodeType);

            var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
            Assert.AreEqual("ab", dochtml1body1math0mi0Text0.TextContent);
        }

        [Test]
        public void NullCharacterAfterLetterInMathNumeric()
        {
            var doc = DocumentBuilder.Html(@"<!DOCTYPE html><math><mn>a" + Symbols.Null.ToString() + "b");

            var doctype = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(doctype);
            Assert.AreEqual(NodeType.DocumentType, doctype.NodeType);
            Assert.AreEqual(@"html", doctype.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1math0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1math0.Attributes.Count);
            Assert.AreEqual("math", dochtml1body1math0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1math0.NodeType);

            var dochtml1body1math0mn0 = dochtml1body1math0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1math0mn0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1math0mn0.Attributes.Count);
            Assert.AreEqual("mn", dochtml1body1math0mn0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1math0mn0.NodeType);

            var dochtml1body1math0mn0Text0 = dochtml1body1math0mn0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1math0mn0Text0.NodeType);
            Assert.AreEqual("ab", dochtml1body1math0mn0Text0.TextContent);
        }

        [Test]
        public void TitleClosedWrongRestOkay()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><title>foo/title><link></head><body>X");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1head0title0 = dochtml1head0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1head0title0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0title0.Attributes.Count);
            Assert.AreEqual("title", dochtml1head0title0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0title0.NodeType);

            var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1head0title0Text0.NodeType);
            Assert.AreEqual("foo/title><link></head><body>X", dochtml1head0title0Text0.TextContent);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(0, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);
        }

        [Test]
        public void NoFramesWithCommentInsideThatContainsAnotherNoFramesPair()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><noframes><!--<noframes></noframes>--></noframes>");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1head0noframes0 = dochtml1head0.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1head0noframes0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0noframes0.Attributes.Count);
            Assert.AreEqual("noframes", dochtml1head0noframes0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0noframes0.NodeType);

            var dochtml1head0noframes0Text0 = dochtml1head0noframes0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1head0noframes0Text0.NodeType);
            Assert.AreEqual("<!--<noframes>", dochtml1head0noframes0Text0.TextContent);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1Text0.NodeType);
            Assert.AreEqual("-->", dochtml1body1Text0.TextContent);
        }

        [Test]
        public void TextAreaWithCommentInsideThatContainsAnotherTextAreaPair()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><textarea><!--<textarea></textarea>--></textarea>");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1textarea0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1textarea0.Attributes.Count);
            Assert.AreEqual("textarea", dochtml1body1textarea0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1textarea0.NodeType);

            var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
            Assert.AreEqual("<!--<textarea>", dochtml1body1textarea0Text0.TextContent);

            var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Text, dochtml1body1Text1.NodeType);
            Assert.AreEqual("-->", dochtml1body1Text1.TextContent);
        }

        [Test]
        public void TextAreaWithQuiteCloseTextAreaClosingInside()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><textarea>&lt;/textarea></textarea>");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1textarea0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1textarea0.Attributes.Count);
            Assert.AreEqual("textarea", dochtml1body1textarea0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1textarea0.NodeType);

            var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
            Assert.AreEqual("</textarea>", dochtml1body1textarea0Text0.TextContent);
        }

        [Test]
        public void TextAreaWithEntityInside()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><textarea>&lt;</textarea>");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1textarea0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1textarea0.Attributes.Count);
            Assert.AreEqual("textarea", dochtml1body1textarea0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1textarea0.NodeType);

            var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
            Assert.AreEqual("<", dochtml1body1textarea0Text0.TextContent);
        }

        [Test]
        public void TextAreaWithTextThatContainsEntityInside()
        {
            var doc = DocumentBuilder.Html(@"<!doctype html><textarea>a&lt;b</textarea>");

            var docType0 = doc.ChildNodes[0] as DocumentType;
            Assert.IsNotNull(docType0);
            Assert.AreEqual(NodeType.DocumentType, docType0.NodeType);
            Assert.AreEqual(@"html", docType0.Name);

            var dochtml1 = doc.ChildNodes[1] as Element;
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Count);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Count);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Count);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
            Assert.AreEqual(1, dochtml1body1textarea0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1textarea0.Attributes.Count);
            Assert.AreEqual("textarea", dochtml1body1textarea0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1textarea0.NodeType);

            var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
            Assert.AreEqual("a<b", dochtml1body1textarea0Text0.TextContent);
        }
    }
}
