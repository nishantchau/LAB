using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentFeeDetailController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                long admissionTypeId = 0, cstatus = 0;
                if (model.IsNewAdmission) { admissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.NEWADMISSION); }
                else { admissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.READMISSION); }
                if (model.ChequePaidAmount > 0) { cstatus = DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.SUBMITTED); }
                else { cstatus = model.ChequeStatus.GetValueOrDefault(); }
                model.ChequeStatus = cstatus;
                //model.StudentFeeId = new FrontEndApi.StudentFeeApi().GetStudentFeeId(model.ClassId, model.SectionId, model.StudentId, admissionTypeId);
                long studentfeeDetailsId = new FrontEndApi.StudentFeeDetailApi().Add(model);
                if (Component.Constants.DEFAULTVALUE.ISMAILSENDSTART)
                {
                    sendmail(studentfeeDetailsId);
                }
                return studentfeeDetailsId;
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> SearchStudentFeeDetailByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        private void sendmail(long studentfeeDetailId)
        {
            //DTO.LABURNUM.COM.StudentFeeDetailModel studentfeeDetail = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(studentfeeDetailId)).MapSingle();

            DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = studentfeeDetailId };
            model.ApiClientModel.UserName = Component.Constants.APIACCESS.APIUSERNAME;
            model.ApiClientModel.Password = Component.Constants.APIACCESS.APIPASSWORD;
            model = SearchMonthlyFeeReceiptData(model);
            DTO.LABURNUM.COM.StudentModel studentmodel = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId)).MapSingle();
            string from = Component.Constants.MAIL.MAILSENTFROM;
            string subject = "Thank you For Paying Fee For the Month Of " + model.MonthName + "-" + new Component.Utility().GetISTDateTime().Year + " At Laburnum Public School.";
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/ThankYouMailOnPaymentOfMonthlyFee.cshtml", model);
            if (new Component.Mailer().MailSend(studentmodel.EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel SearchPendingFee(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetPendingFee(model)).MapSingle();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel SearchMonthlyFeeReceiptData(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel studentFeeDetailModel = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(model.StudentFeeDetailId)).MapSingle();
                API.LABURNUM.COM.StudentFeeDetail dbstudentfeeDetails = new FrontEndApi.StudentFeeDetailApi().GetFeePaidDetailDuringMonthlyFeePayment(studentFeeDetailModel.StudentId, studentFeeDetailModel.ClassId, studentFeeDetailModel.SectionId, studentFeeDetailModel.AcademicYearId,model.StudentFeeDetailId);
                if (dbstudentfeeDetails.ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE))
                {
                    studentFeeDetailModel.LastPendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                    studentFeeDetailModel.BounceChequePanelty = API.LABURNUM.COM.Component.Constants.DEFAULTVALUE.CHEQUEBOUNCEPANELTY;
                    studentFeeDetailModel.BounceChequeAmount = dbstudentfeeDetails.ChequePaidAmount.GetValueOrDefault();
                }
                else
                {
                    studentFeeDetailModel.LastPendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                }
                return studentFeeDetailModel;
            }
            else { return null; }
        }

        public bool UpdateChequeStatus(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel dtomodel = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().UpdateChequeStatus(model.StudentFeeDetailId, model.ChequeStatus.GetValueOrDefault(), model.ChequeBounceRemarks)).MapSingle();
                SendChequeStatusUpdateEmail(dtomodel.StudentFeeDetailId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SendChequeStatusUpdateEmail(long studentFeeDetailsId)
        {
            DTO.LABURNUM.COM.StudentFeeDetailModel model = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(studentFeeDetailsId)).MapSingle();
            string EmailId = new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId).EmailId;
            string from = Component.Constants.MAIL.MAILSENTFROM;
            string subject = "Cheque Status Update Against Cheque No. " + model.ChequeNumber + " Submitted At Laburnum Public School.";
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/EmailBodyForChequeStatusUpdate.cshtml", model);
            if (new Component.Mailer().MailSend(EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> SearchPendingFeeByStudentModel(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                API.LABURNUM.COM.Student dbstudent = new FrontEndApi.StudentApi().GetStudentByAdmissionNumber(model.AdmissionNumber);
                return new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = dbstudent.StudentId, AcademicYearId = model.AcademicYearId })).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel SearchPendingFeeReceiptData(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel studentFeeDetailModel = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(model.StudentFeeDetailId)).MapSingle();
                List<API.LABURNUM.COM.StudentFeeDetail> dbstudentfeeDetailList = new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = studentFeeDetailModel.StudentId, ClassId = studentFeeDetailModel.ClassId, SectionId = studentFeeDetailModel.SectionId, AcademicYearId = studentFeeDetailModel.AcademicYearId });
                int index = dbstudentfeeDetailList.FindIndex(x => x.StudentFeeDetailId == model.StudentFeeDetailId);
                API.LABURNUM.COM.StudentFeeDetail dbstudentfeeDetails =new StudentFeeDetail();
                if (index >= 0)
                {
                    index = index + 1;
                    dbstudentfeeDetails = dbstudentfeeDetailList[index];
                }
                if (dbstudentfeeDetails.ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE))
                {
                    studentFeeDetailModel.LastPendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                    studentFeeDetailModel.BounceChequePanelty = API.LABURNUM.COM.Component.Constants.DEFAULTVALUE.CHEQUEBOUNCEPANELTY;
                    studentFeeDetailModel.BounceChequeAmount = dbstudentfeeDetails.ChequePaidAmount.GetValueOrDefault();
                }
                else
                {
                    studentFeeDetailModel.LastPendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                }
                return studentFeeDetailModel;
            }
            else { return null; }
        }
    }
}