using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;
using Newtonsoft.Json;

namespace API.LABURNUM.COM.Controllers
{
    public class CommonAttendanceController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return AddAttendanceAsperClass(model);
            }
            else
            {
                return -1;
            }
        }

        public long AddAttendanceAsperClass(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            long AttendenceId = 0;
            switch (model.ClassId)
            {
                case 1:
                    DTO.LABURNUM.COM.AttendanceClassPreNurseryModel pmodel = new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    new FrontEndApi.AttendanceClassPreNurseryApi().Add(pmodel);
                    break;
                case 2:
                    DTO.LABURNUM.COM.AttendanceClassLKGModel lkgmodel = new DTO.LABURNUM.COM.AttendanceClassLKGModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClassLKGApi().Add(lkgmodel);
                    break;
                case 3:
                    DTO.LABURNUM.COM.AttendanceClassUKGModel ukgmodel = new DTO.LABURNUM.COM.AttendanceClassUKGModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClassUKGApi().Add(ukgmodel);
                    break;

                case 4:
                    DTO.LABURNUM.COM.AttendanceClass1Model firstmodel = new DTO.LABURNUM.COM.AttendanceClass1Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass1Api().Add(firstmodel);
                    break;

                case 5:
                    DTO.LABURNUM.COM.AttendanceClass2Model secondmodel = new DTO.LABURNUM.COM.AttendanceClass2Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass2Api().Add(secondmodel);
                    break;

                case 6:
                    DTO.LABURNUM.COM.AttendanceClass3Model thirdmodel = new DTO.LABURNUM.COM.AttendanceClass3Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass3Api().Add(thirdmodel);
                    break;

                case 7:
                    DTO.LABURNUM.COM.AttendanceClass4Model fourmodel = new DTO.LABURNUM.COM.AttendanceClass4Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass4Api().Add(fourmodel);
                    break;

                case 8:
                    DTO.LABURNUM.COM.AttendanceClass5Model fivemodel = new DTO.LABURNUM.COM.AttendanceClass5Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass5Api().Add(fivemodel);
                    break;

                case 9:
                    DTO.LABURNUM.COM.AttendanceClass6Model sixmodel = new DTO.LABURNUM.COM.AttendanceClass6Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass6Api().Add(sixmodel);
                    break;

                case 10:
                    DTO.LABURNUM.COM.AttendanceClass7Model sevenmodel = new DTO.LABURNUM.COM.AttendanceClass7Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass7Api().Add(sevenmodel);
                    break;

                case 11:
                    DTO.LABURNUM.COM.AttendanceClass8Model eightmodel = new DTO.LABURNUM.COM.AttendanceClass8Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass8Api().Add(eightmodel);
                    break;

                case 12:
                    DTO.LABURNUM.COM.AttendanceClass9Model ninemodel = new DTO.LABURNUM.COM.AttendanceClass9Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass9Api().Add(ninemodel);
                    break;

                case 13:
                    DTO.LABURNUM.COM.AttendanceClass10Model tenmodel = new DTO.LABURNUM.COM.AttendanceClass10Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass10Api().Add(tenmodel);
                    break;

                case 14:
                    DTO.LABURNUM.COM.AttendanceClass11Model elevenmodel = new DTO.LABURNUM.COM.AttendanceClass11Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass11Api().Add(elevenmodel);
                    break;

                case 15:
                    DTO.LABURNUM.COM.AttendanceClass12Model twelvemodel = new DTO.LABURNUM.COM.AttendanceClass12Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        MorningAttendanceDate = model.MorningAttendanceDate,
                        FacultyId = model.FacultyId
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass12Api().Add(twelvemodel);
                    break;
            }
            string msg = "Blank";
            if (model.IsPresentInMorning) { msg = API.LABURNUM.COM.Component.Constants.SMSAPI.PRESENTSMSMSG; }
            else { msg = API.LABURNUM.COM.Component.Constants.SMSAPI.ABSENTSMSMSG; }
            model.Mobile = new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId).Mobile;
            if (Component.Constants.DEFAULTVALUE.ISMSGSENDSTART)
            {
                new Component.MessageApiHelper().SendSingleSMS(model.Mobile, msg);
            }
            return AttendenceId;
        }

        public dynamic SearchAttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return AttendanceByAdvanceSearch(model);
            }
            else
            {
                return -1;
            }
        }

        private dynamic AttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {

            switch (model.ClassId)
            {
                case 1:
                    DTO.LABURNUM.COM.AttendanceClassPreNurseryModel pmodel = new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
                    {
                        AttendanceClassPreNurseryId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassPreNurseryHelper(new FrontEndApi.AttendanceClassPreNurseryApi().GetAttendanceClassPreNurseryByAdvanceSearch(pmodel)).Map();
                    break;
                case 2:
                    DTO.LABURNUM.COM.AttendanceClassLKGModel lkgmodel = new DTO.LABURNUM.COM.AttendanceClassLKGModel()
                    {
                        AttendanceClassLKGId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassLKGHelper(new FrontEndApi.AttendanceClassLKGApi().GetAttendanceClassLKGByAdvanceSearch(lkgmodel)).Map();
                    break;
                case 3:
                    DTO.LABURNUM.COM.AttendanceClassUKGModel ukgmodel = new DTO.LABURNUM.COM.AttendanceClassUKGModel()
                    {
                        AttendanceClassUKGId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassUKGHelper(new FrontEndApi.AttendanceClassUKGApi().GetAttendanceClassUKGByAdvanceSearch(ukgmodel)).Map();
                    break;

                case 4:
                    DTO.LABURNUM.COM.AttendanceClass1Model firstmodel = new DTO.LABURNUM.COM.AttendanceClass1Model()
                    {
                        AttendanceClass1Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass1Helper(new FrontEndApi.AttendanceClass1Api().GetAttendanceClass1ByAdvanceSearch(firstmodel)).Map();
                    break;

                case 5:
                    DTO.LABURNUM.COM.AttendanceClass2Model secondmodel = new DTO.LABURNUM.COM.AttendanceClass2Model()
                    {
                        AttendanceClass2Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass2Helper(new FrontEndApi.AttendanceClass2Api().GetAttendanceClass2ByAdvanceSearch(secondmodel)).Map();
                    break;

                case 6:
                    DTO.LABURNUM.COM.AttendanceClass3Model thirdmodel = new DTO.LABURNUM.COM.AttendanceClass3Model()
                    {
                        AttendanceClass3Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass3Helper(new FrontEndApi.AttendanceClass3Api().GetAttendanceClass3ByAdvanceSearch(thirdmodel)).Map();
                    break;

                case 7:
                    DTO.LABURNUM.COM.AttendanceClass4Model fourmodel = new DTO.LABURNUM.COM.AttendanceClass4Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass4Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass4Helper(new FrontEndApi.AttendanceClass4Api().GetAttendanceClass4ByAdvanceSearch(fourmodel)).Map();
                    break;

                case 8:
                    DTO.LABURNUM.COM.AttendanceClass5Model fivemodel = new DTO.LABURNUM.COM.AttendanceClass5Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass5Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass5Helper(new FrontEndApi.AttendanceClass5Api().GetAttendanceClass5ByAdvanceSearch(fivemodel)).Map();
                    break;

                case 9:
                    DTO.LABURNUM.COM.AttendanceClass6Model sixmodel = new DTO.LABURNUM.COM.AttendanceClass6Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass6Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass6Helper(new FrontEndApi.AttendanceClass6Api().GetAttendanceClass6ByAdvanceSearch(sixmodel)).Map();
                    break;

                case 10:
                    DTO.LABURNUM.COM.AttendanceClass7Model sevenmodel = new DTO.LABURNUM.COM.AttendanceClass7Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass7Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass7Helper(new FrontEndApi.AttendanceClass7Api().GetAttendanceClass7ByAdvanceSearch(sevenmodel)).Map();
                    break;

                case 11:
                    DTO.LABURNUM.COM.AttendanceClass8Model eightmodel = new DTO.LABURNUM.COM.AttendanceClass8Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass8Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass8Helper(new FrontEndApi.AttendanceClass8Api().GetAttendanceClass8ByAdvanceSearch(eightmodel)).Map();
                    break;

                case 12:
                    DTO.LABURNUM.COM.AttendanceClass9Model ninemodel = new DTO.LABURNUM.COM.AttendanceClass9Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass9Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass9Helper(new FrontEndApi.AttendanceClass9Api().GetAttendanceClass9ByAdvanceSearch(ninemodel)).Map();
                    break;

                case 13:
                    DTO.LABURNUM.COM.AttendanceClass10Model tenmodel = new DTO.LABURNUM.COM.AttendanceClass10Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass10Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass10Helper(new FrontEndApi.AttendanceClass10Api().GetAttendanceClass10ByAdvanceSearch(tenmodel)).Map();
                    break;

                case 14:
                    DTO.LABURNUM.COM.AttendanceClass11Model elevenmodel = new DTO.LABURNUM.COM.AttendanceClass11Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass11Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass11Helper(new FrontEndApi.AttendanceClass11Api().GetAttendanceClass11ByAdvanceSearch(elevenmodel)).Map();
                    break;

                case 15:
                    DTO.LABURNUM.COM.AttendanceClass12Model twelvemodel = new DTO.LABURNUM.COM.AttendanceClass12Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresentInMorning = model.IsPresentInMorning,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                        AttendanceClass12Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass12Helper(new FrontEndApi.AttendanceClass12Api().GetAttendanceClass12ByAdvanceSearch(twelvemodel)).Map();
                    break;
            }
            return null;
        }

        public List<DTO.LABURNUM.COM.CommonAttendanceModel> SearchStudentListForAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList = new List<DTO.LABURNUM.COM.CommonAttendanceModel>();
                List<API.LABURNUM.COM.Student> dbStudents = new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(new DTO.LABURNUM.COM.StudentModel() { ClassId = model.ClassId, SectionId = model.SectionId });
                foreach (API.LABURNUM.COM.Student item in dbStudents)
                {
                    dbList.Add(new DTO.LABURNUM.COM.CommonAttendanceModel()
                    {
                        ClassId = item.ClassId,
                        SectionId = item.SectionId,
                        StudentId = item.StudentId,
                        StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName,
                        Mobile = item.Mobile,
                        FatherName = item.FatherName,
                        AdmissionNumber = item.AdmissionNumber,
                    });
                }
                return dbList;
            }
            else
            {
                return null;
            }
        }

        public void AddAttendanceList(List<DTO.LABURNUM.COM.CommonAttendanceModel> model)
        {
            foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in model)
            {
                Add(item);
            }
        }

        public DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel SearchAttendanceReport(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel responsemodel = new DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel();
            List<API.LABURNUM.COM.Student> dbStudents = new List<Student>();
            if (model.StudentId <= 0)
            {
                dbStudents = new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(new DTO.LABURNUM.COM.StudentModel() { ClassId = model.ClassId, SectionId = model.SectionId });
            }
            else
            {
                dbStudents.Add(new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId));
            }
            int lstday = 0, r;
            if (model.MonthId > 0 && model.StartDate.Year == 0001)
            {
                model.StartDate = new DateTime(2017, model.MonthId, 1, 00, 00, 00);
                if (model.MonthId == 2)
                {
                    if (model.StartDate.Year % 4 == 0)
                    {
                        lstday = 28;
                    }
                    else
                    {
                        lstday = 29;
                    }
                }
                if (model.MonthId == 1 || model.MonthId == 3 || model.MonthId == 5 || model.MonthId == 7 || model.MonthId == 8 || model.MonthId == 8 || model.MonthId == 12)
                {
                    lstday = 31;
                }
                else
                {
                    lstday = 30;
                }
                model.EndDate = new DateTime(2017, model.MonthId, lstday, 00, 00, 00).AddDays(1).AddSeconds(-1);
                r = 1;
            }
            else
            {
                r = model.StartDate.Day;
                lstday = model.StartDate.Day;
            }

            switch (model.ClassId)
            {
                case 1:
                    List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> aNlist = AttendanceByAdvanceSearch(model);
                    if (aNlist.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = aNlist[0].MorningAttendanceDate;
                        if (aNlist[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = aNlist[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> flist = aNlist.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 2:
                    List<DTO.LABURNUM.COM.AttendanceClassLKGModel> ALkgList = AttendanceByAdvanceSearch(model);
                    if (ALkgList.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = ALkgList[0].MorningAttendanceDate;
                        if (ALkgList[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = ALkgList[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClassLKGModel> flist = ALkgList.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 3:
                    List<DTO.LABURNUM.COM.AttendanceClassUKGModel> ukgmodel = AttendanceByAdvanceSearch(model);
                    if (ukgmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = ukgmodel[0].MorningAttendanceDate;
                        if (ukgmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = ukgmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClassUKGModel> flist = ukgmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;

                case 4:
                    List<DTO.LABURNUM.COM.AttendanceClass1Model> firstmodel = AttendanceByAdvanceSearch(model);
                    if (firstmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = firstmodel[0].MorningAttendanceDate;
                        if (firstmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = firstmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass1Model> flist = firstmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 5:
                    List<DTO.LABURNUM.COM.AttendanceClass2Model> secondmodel = AttendanceByAdvanceSearch(model);
                    if (secondmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = secondmodel[0].MorningAttendanceDate;
                        if (secondmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = secondmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass2Model> flist = secondmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 6:
                    List<DTO.LABURNUM.COM.AttendanceClass3Model> thirdmodel = AttendanceByAdvanceSearch(model);
                    if (thirdmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = thirdmodel[0].MorningAttendanceDate;
                        if (thirdmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = thirdmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass3Model> flist = thirdmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;

                case 7:
                    List<DTO.LABURNUM.COM.AttendanceClass4Model> fourmodel = AttendanceByAdvanceSearch(model);
                    if (fourmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = fourmodel[0].MorningAttendanceDate;
                        if (fourmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = fourmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass4Model> flist = fourmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 8:
                    List<DTO.LABURNUM.COM.AttendanceClass5Model> fivemodel = AttendanceByAdvanceSearch(model);
                    if (fivemodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = fivemodel[0].MorningAttendanceDate;
                        if (fivemodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = fivemodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass5Model> flist = fivemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 9:
                    List<DTO.LABURNUM.COM.AttendanceClass6Model> sixmodel = AttendanceByAdvanceSearch(model);
                    if (sixmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = sixmodel[0].MorningAttendanceDate;
                        if (sixmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = sixmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass6Model> flist = sixmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 10:
                    List<DTO.LABURNUM.COM.AttendanceClass7Model> sevenmodel = AttendanceByAdvanceSearch(model);
                    if (sevenmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = sevenmodel[0].MorningAttendanceDate;
                        if (sevenmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = sevenmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass7Model> flist = sevenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 11:
                    List<DTO.LABURNUM.COM.AttendanceClass8Model> eightmodel = AttendanceByAdvanceSearch(model);
                    if (eightmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = eightmodel[0].MorningAttendanceDate;
                        if (eightmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = eightmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass8Model> flist = eightmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 12:
                    List<DTO.LABURNUM.COM.AttendanceClass9Model> ninemodel = AttendanceByAdvanceSearch(model);
                    if (ninemodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = ninemodel[0].MorningAttendanceDate;
                        if (ninemodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = ninemodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass9Model> flist = ninemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 13:
                    List<DTO.LABURNUM.COM.AttendanceClass10Model> tenmodel = AttendanceByAdvanceSearch(model);
                    if (tenmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = tenmodel[0].MorningAttendanceDate;
                        if (tenmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = tenmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass10Model> flist = tenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 14:
                    List<DTO.LABURNUM.COM.AttendanceClass11Model> elevenmodel = AttendanceByAdvanceSearch(model);
                    if (elevenmodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = elevenmodel[0].MorningAttendanceDate;
                        if (elevenmodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = elevenmodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass11Model> flist = elevenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
                case 15:
                    List<DTO.LABURNUM.COM.AttendanceClass12Model> twelvemodel = AttendanceByAdvanceSearch(model);
                    if (twelvemodel.Count > 0)
                    {
                        responsemodel.IsAttendanceSubmittedForTodayMoring = true;
                        responsemodel.MorningAttendanceSubmitDateTime = twelvemodel[0].MorningAttendanceDate;
                        if (twelvemodel[0].LunchAttendanceDate.GetValueOrDefault().Year != 0001)
                        {
                            responsemodel.IsAttendanceSubmittedForTodayLunch = true;
                            responsemodel.LunchAttendanceSubmitDateTime = twelvemodel[0].LunchAttendanceDate.GetValueOrDefault();
                        }
                    }
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (int i = r; i <= lstday; i++)
                        {
                            DateTime stdate;
                            if (model.MonthId > 0)
                            {
                                stdate = new DateTime(2017, model.MonthId, i, 00, 00, 00);
                            }
                            else { stdate = new DateTime(2017, model.StartDate.Month, i, 00, 00, 00); }
                            DateTime lstdate = stdate.AddDays(1).AddSeconds(-1);
                            List<DTO.LABURNUM.COM.AttendanceClass12Model> flist = twelvemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn >= stdate && x.CreatedOn <= lstdate).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, Month = model.MonthId, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = stdate, Day = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }
                    break;
            }
            responsemodel.StartDate = model.StartDate;
            responsemodel.EndDate = model.EndDate;
            responsemodel.ClassId = model.ClassId;
            responsemodel.SectionId = model.SectionId;
            return responsemodel;
        }

        public void SubmitAfterLunchAttendanceList(List<DTO.LABURNUM.COM.CommonAttendanceModel> model)
        {
            foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in model)
            {
                SubmitAfterLunchAttendanceAsPerClass(item);
            }
        }

        public void SubmitAfterLunchAttendanceAsPerClass(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            switch (model.ClassId)
            {
                case 1:
                    new FrontEndApi.AttendanceClassPreNurseryApi().Update(new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
                    {
                        AttendanceClassPreNurseryId = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;
                case 2:
                    new FrontEndApi.AttendanceClassLKGApi().Update(new DTO.LABURNUM.COM.AttendanceClassLKGModel()
                    {
                        AttendanceClassLKGId = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;
                case 3:
                    new FrontEndApi.AttendanceClassUKGApi().Update(new DTO.LABURNUM.COM.AttendanceClassUKGModel()
                    {
                        AttendanceClassUKGId = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;
                case 4:
                    new FrontEndApi.AttendanceClass1Api().Update(new DTO.LABURNUM.COM.AttendanceClass1Model()
                    {
                        AttendanceClass1Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 5:
                    new FrontEndApi.AttendanceClass2Api().Update(new DTO.LABURNUM.COM.AttendanceClass2Model()
                    {
                        AttendanceClass2Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 6:
                    new FrontEndApi.AttendanceClass3Api().Update(new DTO.LABURNUM.COM.AttendanceClass3Model()
                                        {
                                            AttendanceClass3Id = model.AttendanceId,
                                            IsPresentAfterLuch = model.IsPresentAfterLuch,
                                        });
                    break;

                case 7:
                    new FrontEndApi.AttendanceClass4Api().Update(new DTO.LABURNUM.COM.AttendanceClass4Model()
                    {
                        AttendanceClass4Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 8:
                    new FrontEndApi.AttendanceClass5Api().Update(new DTO.LABURNUM.COM.AttendanceClass5Model()
                    {
                        AttendanceClass5Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 9:
                    new FrontEndApi.AttendanceClass6Api().Update(new DTO.LABURNUM.COM.AttendanceClass6Model()
                    {
                        AttendanceClass6Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 10:
                    new FrontEndApi.AttendanceClass7Api().Update(new DTO.LABURNUM.COM.AttendanceClass7Model()
                   {
                       AttendanceClass7Id = model.AttendanceId,
                       IsPresentAfterLuch = model.IsPresentAfterLuch,
                   });
                    break;

                case 11:
                    new FrontEndApi.AttendanceClass8Api().Update(new DTO.LABURNUM.COM.AttendanceClass8Model()
                     {
                         AttendanceClass8Id = model.AttendanceId,
                         IsPresentAfterLuch = model.IsPresentAfterLuch,
                     });
                    break;

                case 12:
                    new FrontEndApi.AttendanceClass9Api().Update(new DTO.LABURNUM.COM.AttendanceClass9Model()
                     {
                         AttendanceClass9Id = model.AttendanceId,
                         IsPresentAfterLuch = model.IsPresentAfterLuch,
                     });
                    break;

                case 13:
                    new FrontEndApi.AttendanceClass10Api().Update(new DTO.LABURNUM.COM.AttendanceClass10Model()
                    {
                        AttendanceClass10Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;

                case 14:
                    new FrontEndApi.AttendanceClass11Api().Update(new DTO.LABURNUM.COM.AttendanceClass11Model()
                   {
                       AttendanceClass11Id = model.AttendanceId,
                       IsPresentAfterLuch = model.IsPresentAfterLuch,
                   });
                    break;

                case 15:
                    new FrontEndApi.AttendanceClass12Api().Update(new DTO.LABURNUM.COM.AttendanceClass12Model()
                    {
                        AttendanceClass12Id = model.AttendanceId,
                        IsPresentAfterLuch = model.IsPresentAfterLuch,
                    });
                    break;
            }
            string msg = "Blank";
            if (model.IsPresentAfterLuch) { msg = API.LABURNUM.COM.Component.Constants.SMSAPI.PRESENTSMSMSG; }
            else { msg = API.LABURNUM.COM.Component.Constants.SMSAPI.ABSENTSMSMSG; }
            model.Mobile = new FrontEndApi.StudentApi().GetStudentByStudentId(model.StudentId).Mobile;
            if (Component.Constants.DEFAULTVALUE.ISMSGSENDSTART)
            {
                new Component.MessageApiHelper().SendSingleSMS(model.Mobile, msg);
            }
        }
    }
}