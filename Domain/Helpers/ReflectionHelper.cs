﻿using System.Reflection;
using NDocument.Domain.Attributes;
using NDocument.Domain.Exceptions;

namespace NDocument.Domain.Helpers
{
    public static class ReflectionHelper<T>
    {
        public static IOrderedEnumerable<PropertyInfo> GetOrderedTableRowPropertyInfos(IEnumerable<T> tableRow)
        {
            var tableRowProperties = GetTableRowPropertyInfos(tableRow);
            return tableRowProperties.OrderBy(t => GetColumnAttribute(t).Order);
        }

        public static IEnumerable<ColumnAttribute> GetOrderedColumnAttributes(IEnumerable<T> tableRow)
        {
            var tableRowProperties = GetTableRowPropertyInfos(tableRow);

            return tableRowProperties
                .Select(t => GetColumnAttribute(t))
                .OrderBy(t => t.Order);
        }

        private static IEnumerable<PropertyInfo> GetTableRowPropertyInfos(IEnumerable<T> tableRows)
        {
            var tableRow = tableRows.ElementAt(0);

            if (tableRow == null)
            {
                throw new NDocumentException(NDocumentErrorCode.ProvidedTableIsEmpty);
            }

            var tableRowType = tableRow.GetType();
            return tableRowType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        private static ColumnAttribute GetColumnAttribute(PropertyInfo tableCell)
        {
            var columnAttribute = tableCell.GetCustomAttribute<ColumnAttribute>();

            if (columnAttribute is null)
            {
                return new ColumnAttribute(tableCell.Name);
            }

            if (columnAttribute.Name.IsSet == false)
            {
                return new ColumnAttribute(tableCell.Name, columnAttribute.Alignment, columnAttribute.Order);
            }

            return columnAttribute;
        }
    }
}
