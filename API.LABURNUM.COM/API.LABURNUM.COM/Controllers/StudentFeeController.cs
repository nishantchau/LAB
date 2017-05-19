using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentFeeController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                long studentfeeId = new FrontEndApi.StudentFeeApi().Add(model);
                long cstatus = 0;
                if (model.ChequePaidAmount > 0) { cstatus = DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.SUBMITTED); }
                else { cstatus = model.ChequeStatus.GetValueOrDefault(); }
                long studentFeeDetailsId = new FrontEndApi.StudentFeeDetailApi().Add(new DTO.LABURNUM.COM.StudentFeeDetailModel()
                {
                    CollectedById = model.CollectedById,
                    AcademicYearId = model.AcademicYearId,
                    StudentId = model.StudentId,
                    ClassId = model.ClassId,
                    SectionId = model.SectionId,
                    PayForTheMonth = System.DateTime.Now.Month,
                    CashPaidAmount = model.CashPaidAmount,
                    ChequePaidAmount = model.ChequePaidAmount,
                    BankId = model.BankId,
                    ChequeDate = model.ChequeDate,
                    ChequeNumber = model.ChequeNumber,
                    PendingFee = model.PendingFee,
                    ChequeStatus = cstatus
                });
                sendmail(studentFeeDetailsId);
                return studentFeeDetailsId;
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeModel> SearchStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        private void sendmail(long studentFeeDetailsId)
        {
            DTO.LABURNUM.COM.StudentFeeDetailModel smodel = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = studentFeeDetailsId };
            smodel.ApiClientModel.UserName = Component.Constants.APIACCESS.APIUSERNAME; ;
            smodel.ApiClientModel.Password = Component.Constants.APIACCESS.APIPASSWORD; ;
            DTO.LABURNUM.COM.StudentFeeModel model = SearchAdmissionFeeReceiptDataByDetailId(smodel);
            //DTO.LABURNUM.COM.StudentFeeDetailModel studentfeeDetail = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetFeePaidDetailDuringAdmission(studentId, classId, sectionId, academicyearId)).MapSingle();
            DTO.LABURNUM.COM.StudentModel studentmodel = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId)).MapSingle();
            model.StudentFeeId = studentFeeDetailsId;
            string from = Component.Constants.MAIL.MAILSENTFROM;
            string subject = Component.Constants.MAILSUBJECT.ADMISSIONSUBJECT;
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/NewAdmissionThankyouEmail.cshtml", model);
            if (new Component.Mailer().MailSend(studentmodel.EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }

        public DTO.LABURNUM.COM.StudentFeeModel SearchAdmissionFeeReceiptData(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentFeeModel studentFeeModel = new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeById(model.StudentFeeId)).MapSingle();
                API.LABURNUM.COM.StudentFeeDetail dbstudentfeeDetails = new FrontEndApi.StudentFeeDetailApi().GetFeePaidDetailDuringAdmission(studentFeeModel.StudentId, studentFeeModel.ClassId, studentFeeModel.SectionId, studentFeeModel.AcademicYearId);
                studentFeeModel.PendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                studentFeeModel.CashPaidAmount = dbstudentfeeDetails.CashPaidAmount.GetValueOrDefault();
                studentFeeModel.ChequePaidAmount = dbstudentfeeDetails.ChequePaidAmount.GetValueOrDefault();
                studentFeeModel.ChequeNumber = dbstudentfeeDetails.ChequeNumber;
                studentFeeModel.ChequeDate = dbstudentfeeDetails.ChequeDate;
                return studentFeeModel;
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.StudentFeeModel SearchAdmissionFeeReceiptDataByDetailId(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                API.LABURNUM.COM.StudentFeeDetail dbstudentfeeDetails = new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(model.StudentFeeDetailId);

                DTO.LABURNUM.COM.StudentFeeModel studentFeeModel = new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeModel()
                {
                    StudentId = dbstudentfeeDetails.StudentId,
                    ClassId = dbstudentfeeDetails.ClassId,
                    SectionId = dbstudentfeeDetails.SectionId
                })).MapSingle();

                studentFeeModel.PendingFee = dbstudentfeeDetails.PendingFee.GetValueOrDefault();
                studentFeeModel.CashPaidAmount = dbstudentfeeDetails.CashPaidAmount.GetValueOrDefault();
                studentFeeModel.ChequePaidAmount = dbstudentfeeDetails.ChequePaidAmount.GetValueOrDefault();
                studentFeeModel.ChequeNumber = dbstudentfeeDetails.ChequeNumber;
                studentFeeModel.ChequeDate = dbstudentfeeDetails.ChequeDate;
                return studentFeeModel;
            }
            else { return null; }
        }
    }
}