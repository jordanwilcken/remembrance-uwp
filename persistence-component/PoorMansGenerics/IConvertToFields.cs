using System.Runtime.InteropServices.WindowsRuntime;

namespace persistence_component.PoorMansGenerics
{
    internal interface IConvertToFields
    {
        DataFields ConvertToFields(IQuery query,[ReadOnlyArray] object[] data);
    }
}
