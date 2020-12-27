using ExcelReader.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace ExcelReader.Sets
{
    internal class Set : ISet
    {
        private XmlDocument _woorkbook;
        private XmlDocument _style;
        private XmlDocument _sharedStrings;
        private IEnumerable<XmlDocument> _sheets;

        internal Set(XmlDocument workbook, XmlDocument style, XmlDocument sharedStrings, IEnumerable<XmlDocument> sheets)
        {
            _woorkbook = workbook;
            _style = style;
            _sharedStrings = sharedStrings;
            _sheets = sheets;
        }

        public IEnumerable<ITable> Tables => _tables;

        public void AddTable(ITable table)
        {
            throw new NotImplementedException();
        }

        public void AddTable(ITable table, int position)
        {
            throw new NotImplementedException();
        }
        public void RemoveTable(ITable table)
        {
            throw new NotImplementedException();
        }

        public void RemoveTable(int position)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITable> GetEnumerator()
        {
            return Tables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private readonly List<ITable> _tables = new List<ITable>();
    }
}
