using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NXOpen;

namespace NX
{
    public class NX : INX
    {
        public void SetFlowCutRefTool(Tag OperTag, Tag cutter)
        {
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;
            Part displayPart = theSession.Parts.Display;

            NXOpen.CAM.SurfaceContourBuilder surfaceContourBuilder1;
            var oper = NXOpen.Utilities.NXObjectManager.Get(OperTag) as NXOpen.CAM.Operation;
            surfaceContourBuilder1 = workPart.CAMSetup.CAMOperationCollection.CreateSurfaceContourBuilder(oper);
            surfaceContourBuilder1.ReferenceTool = NXOpen.Utilities.NXObjectManager.Get(cutter) as NXOpen.CAM.Tool;
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
            surfaceContourBuilder1.FlowBuilder.NonSteepCutting.Stepover.DistanceBuilder.Value = depth;
            surfaceContourBuilder1.Commit();
            surfaceContourBuilder1.Destroy();
        }
    }
}
