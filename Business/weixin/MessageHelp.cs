using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.weixin
{
    public class MessageHelp
    {
        public string ReturnMessage(Byte[] postBytes)
        {
            string responseContent = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(postBytes));
            XmlNode MsgType = xmldoc.SelectSingleNode("/xml/MsgType");
            if (MsgType != null)
            {
                switch (MsgType.InnerText)
                {
                    case "event":
                        responseContent = "";//处理事件的函数
                        break;
                    case "text":
                        responseContent = HandleText(xmldoc);//处理文本内容的函数
                        break;
                }
            }
            return responseContent;
        }

        public static string HandleText(XmlDocument xmldoc)
        {
            string responseContent = "";
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            XmlNode Content = xmldoc.SelectSingleNode("/xml/Content");
            if (Content != null)
            {
                responseContent = string.Format(ReplyType.Message_Text,
                       FromUserName.InnerText,
                       ToUserName.InnerText,
                       DateTime.Now.Ticks,
                       "欢迎您");
            }
            
            return responseContent;
        }

        public class ReplyType
        {
            public static string Message_Text
            {
                get {
                    return @" <xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[text]]></MsgType>
                            <Content><![CDATA[{3}]]></Content>
                            </xml>";
                        }
            }
        }
    }
}
