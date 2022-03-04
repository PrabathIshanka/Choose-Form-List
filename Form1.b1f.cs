using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;

namespace ChooseformList
{
    [FormAttribute("ChooseformList.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {


        public Form1()
        {
            oApplication = (SAPbouiCOM.Application)Application.SBO_Application;
            oCompany = (SAPbobsCOM.Company)oApplication.Company.GetDICompany();
            //oForm = (SAPbouiCOM.Form)oApplication.Forms.ActiveForm;


        }


        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText0_KeyDownAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_2").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_4").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }
        public SAPbobsCOM.Company oCompany;
        public SAPbouiCOM.Application oApplication;
        public SAPbobsCOM.Recordset oRec;
        public SAPbouiCOM.Form oForm;
        public SAPbobsCOM.UserTable oUserTable;

        private string DocEntry;
        private string Query;


        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            // throw new System.NotImplementedException();
            oRec = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (String.IsNullOrEmpty(EditText0.Value.ToString()))
            {

                Application.SBO_Application.SetStatusBarMessage("Plase select a  purches order number", SAPbouiCOM.BoMessageTime.bmt_Medium, true);

            }
            else
            {
                DocEntry = EditText0.Value.ToString();
                // Query = "select t0.\"ItemCode\", .\"Dscrit0ption\" , t0.\"Quantity\" from POR1 t0 left join OPOR t1 on t1.\"DocEntry\" = t0.\"DocEntry\" where t1.\"DocEntry\"= " + DocEntry;
                //oRec.DoQuery(Query);

                Query = "SELECT \"ItemCode\", \"Dscription\" , \"Quantity\" FROM  POR1";

                if (oRec.RecordCount > 0)
                {
                    for (int i = 0; oRec.RecordCount > i; i++)
                    {
                        Matrix0.AddRow();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colCode").Cells.Item(i + 1).Specific).Value = oRec.Fields.Item("ItemCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colName").Cells.Item(i + 1).Specific).Value = oRec.Fields.Item("Dscription").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Qty").Cells.Item(i + 1).Specific).Value = oRec.Fields.Item("Quantity").Value.ToString();
                        oRec.MoveNext();
                    }

                }
            }

        }

        private SAPbouiCOM.LinkedButton LinkedButton0;

        private void EditText0_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }
    }
}