﻿// Decompiled with JetBrains decompiler
// Type: NIDAQ.My.InternalXmlHelper
// Assembly: NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E0A2D9-BC78-4088-A605-9E0C1595E02F
// Assembly location: C:\Program Files (x86)\CIMProjects.Net\Marconi\NIDAQ\amd64\NIDAQ.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace NIDAQ.My
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal sealed class InternalXmlHelper
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    private InternalXmlHelper()
    {
    }

    public static string get_Value(IEnumerable<XElement> source)
    {
      IEnumerator<XElement> enumerator;
      try
      {
        enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
          return enumerator.Current.Value;
      }
      finally
      {
        enumerator?.Dispose();
      }
      return (string) null;
    }

    public static void set_Value(IEnumerable<XElement> source, string value)
    {
      IEnumerator<XElement> enumerator;
      try
      {
        enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
          return;
        enumerator.Current.Value = value;
      }
      finally
      {
        enumerator?.Dispose();
      }
    }

    public static string get_AttributeValue(IEnumerable<XElement> source, XName name)
    {
      IEnumerator<XElement> enumerator;
      try
      {
        enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
          return (string) enumerator.Current.Attribute(name);
      }
      finally
      {
        enumerator?.Dispose();
      }
      return (string) null;
    }

    public static void set_AttributeValue(IEnumerable<XElement> source, XName name, string value)
    {
      IEnumerator<XElement> enumerator;
      try
      {
        enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
          return;
        enumerator.Current.SetAttributeValue(name, (object) value);
      }
      finally
      {
        enumerator?.Dispose();
      }
    }

    public static string get_AttributeValue(XElement source, XName name) => (string) source.Attribute(name);

    public static void set_AttributeValue(XElement source, XName name, string value) => source.SetAttributeValue(name, (object) value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static XAttribute CreateAttribute(XName name, object value) => value == null ? (XAttribute) null : new XAttribute(name, RuntimeHelpers.GetObjectValue(value));

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static XAttribute CreateNamespaceAttribute(XName name, XNamespace ns)
    {
      XAttribute namespaceAttribute = new XAttribute(name, (object) ns.NamespaceName);
      namespaceAttribute.AddAnnotation((object) ns);
      return namespaceAttribute;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static object RemoveNamespaceAttributes(
      string[] inScopePrefixes,
      XNamespace[] inScopeNs,
      List<XAttribute> attributes,
      object obj)
    {
      switch (obj)
      {
        case XElement e:
          // ISSUE: reference to a compiler-generated method
          return (object) InternalXmlHelper.RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, e);
        case IEnumerable enumerable:
          // ISSUE: reference to a compiler-generated method
          return (object) InternalXmlHelper.RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, enumerable);
        default:
          return obj;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IEnumerable RemoveNamespaceAttributes(
      string[] inScopePrefixes,
      XNamespace[] inScopeNs,
      List<XAttribute> attributes,
      IEnumerable obj)
    {
      if (obj == null)
        return obj;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return obj is IEnumerable<XElement> source ? (IEnumerable) source.Select<XElement, XElement>(new Func<XElement, XElement>(new InternalXmlHelper.RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessXElement)) : (IEnumerable) obj.Cast<object>().Select<object, object>(new Func<object, object>(new InternalXmlHelper.RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessObject));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static XElement RemoveNamespaceAttributes(
      string[] inScopePrefixes,
      XNamespace[] inScopeNs,
      List<XAttribute> attributes,
      XElement e)
    {
      XAttribute nextAttribute;
      if (e != null)
      {
        for (XAttribute xattribute = e.FirstAttribute; xattribute != null; xattribute = nextAttribute)
        {
          nextAttribute = xattribute.NextAttribute;
          if (xattribute.IsNamespaceDeclaration)
          {
            XNamespace xnamespace1 = xattribute.Annotation<XNamespace>();
            string localName1 = xattribute.Name.LocalName;
            if ((object) xnamespace1 != null)
            {
              if (inScopePrefixes != null && inScopeNs != null)
              {
                int num = checked (inScopePrefixes.Length - 1);
                int index = 0;
                while (index <= num)
                {
                  string inScopePrefix = inScopePrefixes[index];
                  XNamespace inScopeN = inScopeNs[index];
                  if (localName1.Equals(inScopePrefix))
                  {
                    if (xnamespace1 == inScopeN)
                      xattribute.Remove();
                    xattribute = (XAttribute) null;
                    break;
                  }
                  checked { ++index; }
                }
              }
              if (xattribute != null)
              {
                if (attributes != null)
                {
                  int num = checked (attributes.Count - 1);
                  int index = 0;
                  while (index <= num)
                  {
                    XAttribute attribute = attributes[index];
                    string localName2 = attribute.Name.LocalName;
                    XNamespace xnamespace2 = attribute.Annotation<XNamespace>();
                    if ((object) xnamespace2 != null && localName1.Equals(localName2))
                    {
                      if (xnamespace1 == xnamespace2)
                        xattribute.Remove();
                      xattribute = (XAttribute) null;
                      break;
                    }
                    checked { ++index; }
                  }
                }
                if (xattribute != null)
                {
                  xattribute.Remove();
                  attributes.Add(xattribute);
                }
              }
            }
          }
        }
      }
      return e;
    }
  }
}
