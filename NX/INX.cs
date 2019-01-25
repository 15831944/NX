using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NX
{
    public interface INX
    {
        /// <summary>
        /// 设置清根步距
        /// </summary>
        /// <param name="depth">步距</param>
        void SetFlowCutStepOver(NXOpen.Tag OperTag,double depth);
        /// <summary>
        /// 设置清根参考刀具
        /// </summary>
        /// <param name="depth">步距</param>
        void SetFlowCutRefTool(NXOpen.Tag OperTag,NXOpen.Tag cutter);
    }

    public class Entry
    {
        public static INX GetInstance()
        {
            var assemblyName = "NX9.0";
            if (SnapEx.Helper.NxVersion < 7.5)
            {
                assemblyName = "NX6.0";
            }
            INX result = (INX)System.Reflection.Assembly.Load(assemblyName).CreateInstance("NX.NX", false);
            return result;
        } 
    }
}
