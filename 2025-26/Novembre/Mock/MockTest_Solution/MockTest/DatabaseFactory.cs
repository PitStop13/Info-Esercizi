using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MockTest
{
    public enum DataBaseType
    {
        /// <summary>
        /// database basato su file 
        /// database bassato su liste in memoria
        /// </summary>
        fileBase,
        inmemory,
    }

    internal static class DataBaseFactory
    {
        public static IDatabaseMock CreateDataBase(DataBaseType tipo)
        {
            switch (tipo)
            {
                case DataBaseType.fileBase:
                    return new DatabaseMock();

                case DataBaseType.inmemory:
                //return new ;
                default:
                    throw new ArgumentException($"tipo di database non supotato");
            }
        }

        public static IDatabaseMock CreateDataBase()
        {
            return new DatabaseMock();
        }
    }
}






