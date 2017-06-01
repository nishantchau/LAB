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
            List<API.LABURNUM.COM.Student> dbStudents = new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(new DTO.LABURNUM.COM.StudentModel() { ClassId = model.ClassId, SectionId = model.SectionId });

            switch (model.ClassId)
            {
                case 1:
                    List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> aNlist = AttendanceByAdvanceSearch(model);
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> flist = aNlist.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClassPreNurseryModel item in aNlist)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 2:
                    List<DTO.LABURNUM.COM.AttendanceClassLKGModel> ALkgList = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClassLKGModel> flist = ALkgList.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClassLKGModel item in ALkgList)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 3:
                    List<DTO.LABURNUM.COM.AttendanceClassUKGModel> ukgmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClassUKGModel> flist = ukgmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClassUKGModel item in ukgmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;

                case 4:
                    List<DTO.LABURNUM.COM.AttendanceClass1Model> firstmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass1Model> flist = firstmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass1Model item in firstmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 5:
                    List<DTO.LABURNUM.COM.AttendanceClass2Model> secondmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass2Model> flist = secondmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass2Model item in secondmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 6:
                    List<DTO.LABURNUM.COM.AttendanceClass3Model> thirdmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass3Model> flist = thirdmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass3Model item in thirdmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;

                case 7:
                    List<DTO.LABURNUM.COM.AttendanceClass4Model> fourmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass4Model> flist = fourmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass4Model item in fourmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 8:
                    List<DTO.LABURNUM.COM.AttendanceClass5Model> fivemodel = AttendanceByAdvanceSearch(model);
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass5Model> flist = fivemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass5Model item in fivemodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 9:
                    List<DTO.LABURNUM.COM.AttendanceClass6Model> sixmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass6Model> flist = sixmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass6Model item in sixmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 10:
                    List<DTO.LABURNUM.COM.AttendanceClass7Model> sevenmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass7Model> flist = sevenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass7Model item in sevenmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 11:
                    List<DTO.LABURNUM.COM.AttendanceClass8Model> eightmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass8Model> flist = eightmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass8Model item in eightmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 12:
                    List<DTO.LABURNUM.COM.AttendanceClass9Model> ninemodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass9Model> flist = ninemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass9Model item in ninemodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 13:
                    List<DTO.LABURNUM.COM.AttendanceClass10Model> tenmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass10Model> flist = tenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass10Model item in tenmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 14:
                    List<DTO.LABURNUM.COM.AttendanceClass11Model> elevenmodel = AttendanceByAdvanceSearch(model);

                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass11Model> flist = elevenmodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass11Model item in elevenmodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
                    break;
                case 15:
                    List<DTO.LABURNUM.COM.AttendanceClass12Model> twelvemodel = AttendanceByAdvanceSearch(model);
                    foreach (API.LABURNUM.COM.Student item in dbStudents)
                    {
                        List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance> attendancelist = new List<DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance>();
                        for (DateTime i = model.StartDate; i < model.EndDate; i.AddDays(1))
                        {
                            List<DTO.LABURNUM.COM.AttendanceClass12Model> flist = twelvemodel.Where(x => x.StudentId == item.StudentId && x.CreatedOn == i).ToList();
                            if (flist.Count == 0) { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = false, IsPresentAtAfterLunch = false }); }
                            if (flist.Count == 1)
                            { attendancelist.Add(new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendance() { Date = i, IsPresentAtMorning = flist[0].IsPresentInMorning, IsPresentAtAfterLunch = flist[0].IsPresentAfterLuch }); }
                        }
                        responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { StudentId = item.StudentId, StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName, AttendanceList = attendancelist });
                    }

                    //foreach (DTO.LABURNUM.COM.AttendanceClass12Model item in twelvemodel)
                    //{
                    //    responsemodel.StudentList.Add(new DTO.LABURNUM.COM.AttendanceReporting.StudentAttendance() { Day = item.Date.Day, IsPresent = item.IsPresent, StudentId = item.StudentId, StudentName = item.StudentName });
                    //}
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