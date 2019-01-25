using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NX
{
    public class NX : INX
    {
        public void SetFlowCutRefTool(Tag OperTag, Tag cutter)
        {
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;
            var ufSession = NXOpen.UF.UFSession.GetUFSession();
            double dia ;
            ufSession.Param.AskDoubleValue(cutter, NXOpen.UF.UFConstants.UF_PARAM_TL_DIAMETER, out dia);
            NXOpen.CAM.SurfaceContourBuilder surfaceContourBuilder1;
            var oper = NXOpen.Utilities.NXObjectManager.Get(OperTag) as NXOpen.CAM.Operation;
            surfaceContourBuilder1 = workPart.CAMSetup.CAMOperationCollection.CreateSurfaceContourBuilder(oper);
            surfaceContourBuilder1.FlowBuilder.TlDiameter = dia;
            surfaceContourBuilder1.Commit();
            surfaceContourBuilder1.Destroy();
        }

        public void SetFlowCutStepOver(Tag OperTag, double depth)
        {
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            NXOpen.CAM.SurfaceContourBuilder surfaceContourBuilder1;
            var oper = NXOpen.Utilities.NXObjectManager.Get(OperTag) as NXOpen.CAM.Operation;
            surfaceContourBuilder1 = workPart.CAMSetup.CAMOperationCollection.CreateSurfaceContourBuilder(oper);
            surfaceContourBuilder1.FlowBuilder.StepoverBuilder.DistanceBuilder.Value = depth;
            surfaceContourBuilder1.Commit();
            surfaceContourBuilder1.Destroy();

        }
    }
}
