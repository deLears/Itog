


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit.SDK.Samples.Rooms.CS
{
    
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class Command : IExternalCommand
    {
    
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData,
                                               ref string message,
                                               ElementSet elements)
        {
            try
            {
                Transaction tran = new Transaction(commandData.Application.ActiveUIDocument.Document, "Rooms");
                tran.Start();
                RoomsData data = new RoomsData(commandData);

                
                using (roomsInformationForm infoForm = new roomsInformationForm(data))
                {
                    infoForm.ShowDialog();
                }
                tran.Commit();
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
    }
}