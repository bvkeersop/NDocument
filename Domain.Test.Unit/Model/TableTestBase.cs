﻿using DocumentBuilder.Model;
using DocumentBuilder.Test.Unit.TestHelpers;

namespace DocumentBuilder.Test.Unit.Model
{
    public class TableTestBase
    {
        protected const string _longestDescription = "Very long description with most characters";
        protected IEnumerable<ProductTableRowWithHeaders> _productTableRowsWithHeaders;
        protected IEnumerable<ProductTableRowWithoutHeaders> _productTableRowsWithoutHeaders;
        protected Table<ProductTableRowWithoutHeaders> _tableWithoutHeaderAttributes;

        [TestInitialize]
        public void TableTestBaseInitialize()
        {
            _productTableRowsWithHeaders = ExampleProductsGenerator.CreateTableRowsWithHeaders();
            _productTableRowsWithoutHeaders = ExampleProductsGenerator.CreateTableRowsWithoutHeaders();
            _tableWithoutHeaderAttributes = new Table<ProductTableRowWithoutHeaders>(_productTableRowsWithoutHeaders);
        }
    }
}
