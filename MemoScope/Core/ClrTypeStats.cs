using System.Windows.Forms;
using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;

namespace MemoScope.Core
{
    public class ClrTypeStats : ITypeNameData
    {
        public int Id { get; }
        public ClrType Type { get; }
        public ulong MethodTable { get; }

        [OLVColumn(Title = "Type Name", Width = 500)]
        public string TypeName => TypeHelpers.ManageAlias(Type);

        [OLVColumn(Title = "Nb", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public long NbInstances { get; private set; }

        [OLVColumn(Title = "Total Size", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public ulong TotalSize { get; private set; }

        public ClrTypeStats(int id, ClrType type)
        {
            Id = id;
            MethodTable = type.MethodTable;
            Type = type;
        }

        public ClrTypeStats(int id, ClrType type, long nbInstances, ulong totalSize) : this(id, type)
        {
            NbInstances = nbInstances;
            TotalSize= totalSize;
        }

        public void Inc(ulong size)
        {
            TotalSize += size;
            NbInstances++;
        }
    }
}