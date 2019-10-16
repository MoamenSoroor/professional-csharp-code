using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace CSharpBookTraining.Formats
{

    public interface IFormatable
    {
        void Format();

    }


    public interface ICssFormatable : IFormatable
    {
        void FormatToCss();

    }


    public interface IXmlFormatable : IFormatable
    {
        void FormatToXML();

    }


    class Formatter
    {
        public static string Format(IFormatable formatable)
        {

            return null;
        }

    }
}
