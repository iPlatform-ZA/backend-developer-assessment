using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace BackEndApplication.Utils
{
    public class XMLHelper
    {
        public static string GetInnerText(XmlNode node)
        {
            return node == null ? "" : node.InnerText;
        }

        public static string GetAttributeValue(XmlAttribute node)
        {
            return node == null ? "" : node.Value;
        }

        public static XmlNodeList GetChildNodes(XmlNode node)
        {
            return node == null ? new EmptyNodeList() : node.ChildNodes;
        }


        class EmptyNodeList : XmlNodeList
        {
            public override XmlNode Item(int index)
            {
                throw new NotImplementedException();
            }

            public override IEnumerator GetEnumerator()
            {
                return new EmptyNodeListEnumerator();
            }

            public class EmptyNodeListEnumerator : IEnumerator
            {
                public bool MoveNext()
                {
                    return false;
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }

                public object Current
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            public override int Count
            {
                get
                {
                    return 0;
                }
            }
        }

    }
}