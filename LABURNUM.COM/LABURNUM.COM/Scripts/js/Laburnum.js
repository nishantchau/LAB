//===========================================================================================================
//Config File Start
var _ISTOSHOWALERT = true;
var _DROPDOWNHEIGHT = 200;
var _DOMAINDIVID = "divDomain";
var _LOADERDIVID = "divLoader";
var _POPUPLOADERDIVID = "divPopupLoader";
var _MESSAGEDIVID = "divMessage";
var _POPUPMESSAGEDIVID = "divPopupMessage";
var _RESULTDIVID = "divResult";
var MESSAGES = {
    AddSuccessMessage: "SuccessFully Added",
    AddFailMessage: "Failed To Add Please Try Again Later",
    UpdateSuccessMessage: "SuccessFully Updated",
    UpdateFailMessage: "Failed To Update Please Try Again Later",
    UniversalSuccessMessage: "Successfully Done",
    UniversalFailMessage: "SomeThing Goes Wrong Please Try Again Later",
    ImageUploadStart: "Start Uploading...... ",
    ImageUploadSucessfully: "Image Upload Successfully.",
    ImageUploadFailed: "Failed To Upload Please Try Again Later.",
};

var LoginType = {
    Admin: 1,
    Principle: 2,
    Faculty: 3,
    Parent: 4,
    Student: 5
};


//Config File End
//===========================================================================================================

//===========================================================================================================
//Start Common Functions


function MyAlert(msg) {
    try {
        if (_ISTOSHOWALERT) { alert(msg); }
    }
    catch (e) { }
}

//Get WebSite Url.
function GetDomain(domaindivid) {
    try {
        return $("#" + domaindivid).html();
    }
    catch (e) { MyAlert("GetDomain" + e); }
}

//Display Loader.
function DisplayLoader(loderdivId) {
    try { $("#" + loderdivId).show(); }
    catch (e) { MyAlert("DisplayLoader" + e); }
}

//Hide Loader.
function HideLoader(loderdivId) {
    try { $("#" + loderdivId).hide(); }
    catch (e) { MyAlert("HideLoader" + e); }
}

var Validate = {
    StringValueValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value == "" || value == null) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    StringHtmlValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).html();
        var div = "#" + messagedivid;
        if (value == "" || value == null) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    IntValueValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value <= 0) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    IntHtmlValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value <= 0) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    }
}

// Send Ajax Request.
function SendAjaxRequest(url, messageDivId, btnId, successmsg, failmsg) {
    $("#" + btnId).prop("disabled", true);
    $.ajax({
        method: "POST",
        url: url,
        success: function (data) {
            $("#" + btnId).prop("disabled", false);
            switch (data.code) {
                case 0:
                    $("#" + messageDivId).html(successmsg);
                    $("#" + messageDivId).show();
                    $("#" + btnId).prop("disabled", true);
                    break;
                case -1:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
                case -2:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
                case 3:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
            }
        }
    });
}

//Fill Model View.
function FillViewInModelDiv(url, modelDivId) {
    try {
        SetHtmlBlank(modelDivId);
        SetHtml(modelDivId, BuildLoderHTML());
        $.ajax({
            method: "POST",
            url: url,
            success: function (data) {
                switch (data.code) {
                    case 0:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case -1:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case -2:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case -3:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case 99:
                        window.location = GetDomain(_DOMAINDIVID) + "Login/Index";
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                }
            }
        });
    }
    catch (e) { MyAlert("FillViewInModel : " + e); }
}

//Email format is ok.
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

//Get Value Or Zero
function GetValueOrZero(divId) {
    var x = GetValue(divId);
    if (x == "") { return 0; }
    else { return parseInt(x); }
}

//Show Success Result.
function FillSuccessResultMSG(data, messagedivId, successmsg, failmsg) {
    try {
        switch (data.code) {
            case 0:
                SetHtml(messagedivId, successmsg);
                break;
            case -1:
                SetHtml(messagedivId, failmsg);
                break;
            case -2:
                SetHtml(messagedivId, failmsg);
                break;
            case -3:
                SetHtml(messagedivId, failmsg);
                break;
        }
    }
    catch (e) { MyAlert("SuccessResult : " + e); }
}

//Fill Success Result View.
function FillSuccessResultView(data, resultDiv) {
    try {
        switch (data.code) {
            case 0:
                SetHtml(resultDiv, data.result);
                break;
            case -1:
                SetHtml(resultDiv, data.result);
                break;
            case -2:
                SetHtml(resultDiv, data.result);
                break;
        }
    }
    catch (e) { MyAlert("SuccessResult : " + e); }
}

// Show Message.
function SetHtml(messagedivId, message) {
    try {
        SetHtmlBlank(messagedivId);
        $("#" + messagedivId).html(message);
        $("#" + messagedivId).show();
    }
    catch (e) { MyAlert("SetHtml : " + e); }
}

// Return Number
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

//On Move To Next
function movetoNext(current, nextFiledId) {
    try {

        if (current.value.length == 1) {
            document.getElementById(nextFiledId).focus();
        }
        else {
            document.getElementById(nextFiledId).focus();
        }
    }
    catch (e) {
        MyAlert("movetoNext :" + e);
        return false;
    }
}

//Disable Button.
function Disablebutton(btnId) {
    try {
        $("#" + btnId).prop("disabled", true);
    } catch (e) {
        MyAlert("Disablebutton" + e);
    }
}

//Enable Button.
function Enablebutton(btnId) {
    try {
        $("#" + btnId).prop("disabled", false);
    } catch (e) {
        MyAlert("Enablebutton" + e);
    }
}

//Get Value.
function GetValue(divId) {
    try {
        return $("#" + divId).val();
    } catch (e) {
        MyAlert("GetValue : " + e);
    }
}

//Get HTML.
function GetHtml(divId) {
    try {
        return $("#" + divId).html();
    } catch (e) {
        MyAlert("GetHtml : " + e);
    }
}

//set Value Blank.
function SetValueBlank(divId) {
    try {
        $("#" + divId).val("");
    } catch (e) {
        MyAlert("SetValueBlank : " + e);
    }
}

//set HTML Blank.
function SetHtmlBlank(divId) {
    try {
        $("#" + divId).html("");
    } catch (e) {
        MyAlert("SetHtmlBlank : " + e);
    }
}

//Upload Files
function UploadFile(nameDivId, statusDivId, hiddenDivId, filenameDivId, inputid) {
    try {
        var name = $("#" + nameDivId).html();
        $("#" + statusDivId).hide();
        SetHtmlBlank(statusDivId);
        $("#" + inputid).fileupload({
            dataType: 'json',
            url: GetDomain(_DOMAINDIVID) + '/Common/UploadFiles?name=' + name.trim(),
            autoUpload: true,
            done: function (e, data) {
                var o = $("#" + filenameDivId);
                o.html(data.result.name);
                var h = $("#" + filenameDivId).html();
                $("#" + hiddenDivId).val(h);
                $("#" + statusDivId).show();
                SetHtml(statusDivId, MESSAGES.ImageUploadSucessfully);
                $("#" + inputid).val(data.result.name);
            }
        });
        $('#' + inputid).on('fileuploadstart', function (event) {
            $("#" + statusDivId).show();
            SetHtml(statusDivId, MESSAGES.ImageUploadStart);
        });
        return true;
    }
    catch (e) {
        MyAlert("UploadUserProfilePicture" + e);
        return false;
    }
}

function UploadCircular(statusDivId, hiddenDivId, filenameDivId, inputid) {
    try {
        //var name = $("#" + nameDivId).html();
        $("#" + statusDivId).hide();
        SetHtmlBlank(statusDivId);
        $("#" + inputid).fileupload({
            dataType: 'json',
            url: GetDomain(_DOMAINDIVID) + '/Common/UploadCircularFiles',
            autoUpload: true,
            done: function (e, data) {
                var o = $("#" + filenameDivId);
                o.html(data.result.name);
                var h = $("#" + filenameDivId).html();
                $("#" + hiddenDivId).val(h);
                $("#" + statusDivId).show();
                SetHtml(statusDivId, MESSAGES.ImageUploadSucessfully);
                $("#" + inputid).val(data.result.name);
            }
        });
        $('#' + inputid).on('fileuploadstart', function (event) {
            $("#" + statusDivId).show();
            SetHtml(statusDivId, MESSAGES.ImageUploadStart);
        });
        return true;
    }
    catch (e) {
        MyAlert("UploadCircular" + e);
        return false;
    }
}

function GetEncryptedId(id, redirectto) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    window.location = redirectto + data.id;
                    //alert(data.id);
                    //return data.id;
                }
                if (data.message == "n") {
                    // return null;
                }
            }
        });
    } catch (e) {
        MyAlert("GetEncryptedId : " + e);
    }
}

function SetEncryptIdFillView(id, resultDivid, url1) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    url1 = url1 + data.id;
                    FillViewInModelDiv(url1, resultDivid);
                }
                if (data.message == "n") {
                    // return null;
                }
            }
        });
    } catch (e) {
        MyAlert("SetEncryptIdFillView : " + e);
    }
}

//Create DatePicker.
function CreateDatePicker(boxId) {
    try {
        var currentDate = new Date();
        var id = "#" + boxId;
        $(id).datepicker({
            changeMonth: true,
            numberOfMonths: 1,
            minDate: currentDate,
            value: new Date(),
            autoclose: true,
        });
    } catch (e) {
        MyAlert("CreateDatePicker : " + e);
    }
}

function CreateDigitalWatch() {
    try {
        // Create two variable with the names of the months and days in an array
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]

        // Create a newDate() object
        var newDate = new Date();
        // Extract the current date from Date object
        newDate.setDate(newDate.getDate());
        // Output the day, date, month and year    
        $('#Date').html(dayNames[newDate.getDay()] + " " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

        setInterval(function () {
            // Create a newDate() object and extract the seconds of the current time on the visitor's
            var seconds = new Date().getSeconds();
            // Add a leading zero to seconds value
            $("#sec").html((seconds < 10 ? "0" : "") + seconds);
        }, 1000);

        setInterval(function () {
            // Create a newDate() object and extract the minutes of the current time on the visitor's
            var minutes = new Date().getMinutes();
            // Add a leading zero to the minutes value
            $("#min").html((minutes < 10 ? "0" : "") + minutes);
        }, 1000);

        setInterval(function () {
            // Create a newDate() object and extract the hours of the current time on the visitor's
            var hours = new Date().getHours();
            // Add a leading zero to the hours value
            $("#hours").html((hours < 10 ? "0" : "") + hours);
        }, 1000);
    } catch (e) {
        MyAlert("CreateDigitalWatch : " + e);
    }
}

// End Common Function;

//==============================================================================================================

function OnAddClassBegin() {
    try {
        if (Validate.StringValueValidate("txtClassName", _MESSAGEDIVID, "Please Enter Class Name")) { }
        else {
            return false;
        }
        DisplayLoader(_LOADERDIVID);
    }
    catch (e) { MyAlert("OnAddClassBegin" + e); }
}

function OnAddClassSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
        if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "SeeAllClass/Index"; }
        if (data.code != 0) { Enablebutton("btnAddClass"); }
    }
    catch (e) { MyAlert("OnAddClassSuccess" + e); }
}

function OnSeachClassByAdvanceSearchBegin() {
    try {
        SetHtmlBlank("divMessage");
        SetHtmlBlank("divResult");
        var classId = GetValue("txtClassId");
        var classname = GetValue("txtClassName");
        if (classId == "" && classname == "") {
            SetHtml("divMessage", "Please Enter Value in above box.")
            return false;
        }
        DisplayLoader("divLoader");

    } catch (e) {
        MyAlert("OnSeachClassByAdvanceSearchBegin : " + e);
    }
}

function OnSeachClassByAdvanceSearchSuccess(data) {
    HideLoader("divLoader");
    FillSuccessResultView(data, "divResult");
}

function OnClassAdvanceSeachIndexReady() {
    SetValueBlank("txtClassId");
}

function ResetEntries() {
    SetValueBlank("txtClassId");
    SetValueBlank("txtClassName");
    SetHtmlBlank("divResult");
    SetHtmlBlank("divMessage");
}

function EditClassPopup(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditClassPopup?id=" + data.id;
                    FillViewInModelDiv(url, "myModal");
                }
                if (data.message == "n") {
                }
            }
        });
    }
    catch (e) {
        MyAlert("EditClassPopup" + e);
    }
}

function OnEditClassBegin() {
    if (Validate.StringValueValidate("txtClassNameP", _POPUPMESSAGEDIVID, "Please Enter Class Name")) { }
    else {
        return false;
    }
    DisplayLoader("divPopupLoader");
    Disablebutton("btnSubmit");
}

function OnEditClassSuccess(data) {
    HideLoader("divPopupLoader");
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Updated Successfully", "Failed To Update Try Again Later");
    if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "SeeAllClass/Index" }
    if (data.code != 0) { Enablebutton("btnSubmit"); }
}

function UpdateStatusPoup(id, counter) {
    var tdid = "tdIsActive" + counter;
    var cIsActive = GetHtml(tdid);
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/StatusUpdateAlert?id=" + id + "&cIsActive=" + cIsActive;
    FillViewInModelDiv(url, "myModal");
}

function OnStatusUpdateBegin() {
    DisplayLoader(_POPUPLOADERDIVID);
}

function OnStatusUpdateSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
}

function OnAddAdmissionTypeBegin() {
    try {
        if (Validate.StringValueValidate("txtAdmissionTypeName", _MESSAGEDIVID, "Please Enter Admission Type Name")) { }
        else {
            return false;
        }
        DisplayLoader(_LOADERDIVID);
    }
    catch (e) { MyAlert("OnAddAdmissionTypeBegin" + e); }
}

function OnAddAdmissionTypeSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
    }
    catch (e) { MyAlert("OnAddAdmissionTypeSuccess" + e); }
}

function EditAdmissionTypePopup(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditAdmissionTypePopup?id=" + data.id;
                    FillViewInModelDiv(url, "myModal");
                }
                if (data.message == "n") {
                }
            }
        });
    }
    catch (e) {
        MyAlert("EditAdmissionTypePopup" + e);
    }
}

function OnEditAdmissionTypeBegin() {
    try {
        if (Validate.StringValueValidate("txtAdmissionTypeNameP", _POPUPMESSAGEDIVID, "Please Enter Admission Type Name")) { }
        else {
            return false;
        }
        DisplayLoader(_POPUPLOADERDIVID);
    }
    catch (e) {
        MyAlert("OnEditAdmissionTypeBegin : " + e);
    }
}

function OnEditAdmissionTypeSuccess(data) {
    try {
        HideLoader("divPopupLoader");
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Updated Successfully", "Failed To Update Try Again Later");
    }
    catch (e) {
        MyAlert("OnEditAdmissionTypeSuccess : " + e);
    }
}

function UpdateAdmissionTypeStatusPoup(id, counter) {
    var tdid = "tdIsActive" + counter;
    var cIsActive = GetHtml(tdid);
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AdmissionTypeStatusUpdateAlert?id=" + id + "&cIsActive=" + cIsActive;
    FillViewInModelDiv(url, "myModal");
}

function OnAdmissionTypeStatusUpdateBegin() {
    DisplayLoader(_POPUPLOADERDIVID);
}

function OnAdmissionTypeStatusUpdateSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
}

function OnSeachAdmissionTypeByAdvanceSearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        var admissionTypeId = GetValue("txtAdmissionTypeId");
        var admissionTypename = GetValue("txtAdmissionTypeName");
        if (admissionTypeId == "" && admissionTypename == "") {
            SetHtml(_MESSAGEDIVID, "Please Enter Value in above box.")
            return false;
        }
        DisplayLoader(_LOADERDIVID);

    } catch (e) {
        MyAlert("OnSeachAdmissionTypeByAdvanceSearchBegin : " + e);
    }
}

function OnSeachAdmissionTypeByAdvanceSearchSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, _RESULTDIVID);
}

function OnAdmissionTypeAdvanceSeachIndexReady() {
    SetValueBlank("txtAdmissionTypeId");
}

function OnLoginBegin() {
    SetHtmlBlank("divMessage");
    if (Validate.IntValueValidate("hdnLoginBy", "divMessage", "Please Choose Either \'Staff\' or \'Student\' or \'Parent\'")) { }
    else { return false; }

    if (Validate.StringValueValidate("txtUserName", "divMessage", "Plese Enter UserName.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtPassword", "divMessage", "Plese Enter Password.")) { }
    else { return false; }
    DisplayLoader(_LOADERDIVID);
}

function OnLoginSuccess(data) {
    HideLoader(_LOADERDIVID);
    switch (data.code) {
        case 0:
            SetHtml("divMessage", "LoginSuccessfully");
            window.location = GetDomain(_DOMAINDIVID) + "Dashboard/Index";
            break;
        case -1:
            SetHtml("divMessage", "Invalid UserName and/or Password");
            break;
        case -2:
            SetHtml("divMessage", "SomeThing Goes Wrong");
            break;
    }
}

function OnAddStudentReady() {
    BindSectionsDropdownByClass();
    $("#ddlSection").prop('disabled', true);
    var currentDate = new Date();
    $('#datepicker').datepicker({
        changeMonth: true,
        numberOfMonths: 1,
        minDate: currentDate,
        value: new Date(),
        autoclose: true,
    });
    $("#ddlBusRoute").val("0");
    ShowTranportCharge();
}

function UploadImage() {
    UploadFile("divPhotoName", "divImageUploadStatus", "hdnStudentPhoto", "file_name", "fileUpload");
}

function setImageName(isforfaculty) {

    if (isforfaculty) { $("#divPhotoName").html($("#txtFacultyName").val()); }
    else {
        $("#divPhotoName").html($("#txtAdmissionNumber").val());
    }
}

function OnAddStudentBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        if (Validate.IntValueValidate("ddlClass", "divMessage", "Please Select A Class.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlSection", "divMessage", "Please Select A Section.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlClassStartWith", "divMessage", "Please Select Initial Class.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlSalutation", "divMessage", "Please Select A Salutation.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFirstName", "divMessage", "Plese Enter First Name.")) { }
        else { return false; }
        //if (Validate.StringValueValidate("txtMiddleName", "divMessage", "Plese Enter Middle Name.")) { }
        //else { return false; }
        if (Validate.StringValueValidate("txtLastName", "divMessage", "Plese Enter Last Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMobile", "divMessage", "Plese Enter Mobile Number.")) { }
        else { return false; }
        //if (Validate.StringValueValidate("txtLandline", "divMessage", "Plese Enter Landline Number.")) { }
        //else { return false; }
        if (Validate.StringValueValidate("txtAddress", "divMessage", "Plese Enter Address.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherName", "divMessage", "Plese Enter Father's Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherProfession", "divMessage", "Plese Enter Father's Profession.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherMobile", "divMessage", "Plese Enter Father's Mobile Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherName", "divMessage", "Plese Enter Mother's Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherProfession", "divMessage", "Plese Enter Mother's Profession.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherMobile", "divMessage", "Plese Enter Mother's Mobile Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtEmail", "divMessage", "Plese Enter Email Id.")) { }
        else { return false; }
        if (!isEmail(GetValue("txtEmail"))) {
            SetHtml(_MESSAGEDIVID, "Please Enter Valid Email.");
            return false;
        }
        if (Validate.StringValueValidate("txtFatherAdharNo", "divMessage", "Plese Enter Father's Adhar Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherAdharNo", "divMessage", "Plese Enter Mother's Adhar Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtPAN", "divMessage", "Plese Enter PAN Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtStudentAdharNo", "divMessage", "Plese Enter Student's Adhar Number.")) { }
        else { return false; }
        if (istransportrqd = document.getElementById('chkIsTransportRqd').checked == true) {
            if (Validate.IntValueValidate("ddlBusRoute", _MESSAGEDIVID, "Please Select Bus Route.")) { }
            else { return false; }
        }
        //if (Validate.StringValueValidate("txtBusRoute", "divMessage", "Plese Enter Bus Route Number.")) { }
        //else { return false; }
        if (Validate.StringValueValidate("txtStudentUserName", "divMessage", "Plese Enter Student's UserName.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtStudentPassword", "divMessage", "Plese Enter Student's Password.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtParentUsername", "divMessage", "Plese Enter Parent's UserName.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtParentPassword", "divMessage", "Plese Enter Parent's Password.")) { }
        else { return false; }

        DisplayLoader(_LOADERDIVID);
        $("#btnSave").prop('disabled', true);
        $("#btnSaveNext").prop('disabled', true);
    }
    catch (e) {
        MyAlert("OnAddStudentBegin" + e);
    }
}

function OnAddStudentSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        switch (data.code) {
            case 0:
                SetHtml("divMessage", "Added Successfully");
                if (!data.studentModel.IsRedirecting) {
                    window.location = GetDomain(_DOMAINDIVID) + "StudentFee/Index?studentId=" + data.studentModel.StudentId + "&classId=" + data.studentModel.ClassId + "&sectionId=" + data.studentModel.SectionId + "&isNewAdmission=" + data.studentModel.IsNewAdmission;
                }
                break;
            case -1:
                SetHtml("divMessage", "SomeThing Goes Wrong Please Try Again Later");
                $("#btnSave").prop('disabled', false);
                $("#btnSaveNext").prop('disabled', false);
                break;
            case -2:
                SetHtml("divMessage", "SomeThing Goes Wrong");
                $("#btnSave").prop('disabled', false);
                $("#btnSaveNext").prop('disabled', false);
                break;
        }
    }
    catch (e) { MyAlert("OnAddStudentSuccess" + e); }
}

function SelectLoginType(value) {
    $("#hdnLoginBy").val(value);
    if (value == LoginType.Faculty) {
        $("#ParentLogin").prop('checked', false);
        $("#StudentLogin").prop('checked', false);
        $("#TeacherLogin").prop('checked', true);
    }

    if (value == LoginType.Parent) {
        $("#ParentLogin").prop('checked', true);
        $("#StudentLogin").prop('checked', false);
        $("#TeacherLogin").prop('checked', false);
    }

    if (value == LoginType.Student) {
        $("#ParentLogin").prop('checked', false);
        $("#StudentLogin").prop('checked', true);
        $("#TeacherLogin").prop('checked', false);
    }
}


function OnUpdateStudentReady() {
    try {
        BindSectionsDropdownByClass();
        var currentDate = $("#hdnDOB").val();
        $('#datepicker').datepicker({
            changeMonth: true,
            numberOfMonths: 1,
            minDate: currentDate,
            value: new Date(),
            autoclose: true,
        });
        BindCoreSectionsDropDownByClass(true);
        var isct = $("#hdnTransportRqd").val();
        if (isct == "True") {
            $("#chkIsTransportRqd").prop("checked", true);
            $("#divBusRoute").show();
        }
        if (isct == "False") {
            $("#chkIsTransportRqd").prop("checked", false);
            $("#divBusRoute").hide();
            $("#ddlBusRoute").val("0");
        }
        ShowTranportCharge();
    }
    catch (e)
    { MyAlert("OnUpdateStudentReady" + e); }
}

function OnUpdateStudentBegin() {
    try {
        SetHtmlBlank("divMessage");
        if (Validate.IntValueValidate("ddlClass", "divMessage", "Please Select A Class.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlSection", "divMessage", "Please Select A Section.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlClassStartWith", "divMessage", "Please Select Initial Class.")) { }
        else { return false; }
        if (Validate.StringValueValidate("ddlSalutation", "divMessage", "Please Select A Salutation.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFirstName", "divMessage", "Plese Enter First Name.")) { }
        else { return false; }
        //if (Validate.StringValueValidate("txtMiddleName", "divMessage", "Plese Enter Middle Name.")) { }
        //else { return false; }
        if (Validate.StringValueValidate("txtLastName", "divMessage", "Plese Enter Last Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMobile", "divMessage", "Plese Enter Mobile Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtLandline", "divMessage", "Plese Enter Landline Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtAddress", "divMessage", "Plese Enter Address.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherName", "divMessage", "Plese Enter Father's Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherProfession", "divMessage", "Plese Enter Father's Profession.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherMobile", "divMessage", "Plese Enter Father's Mobile Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherName", "divMessage", "Plese Enter Mother's Name.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherProfession", "divMessage", "Plese Enter Mother's Profession.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherMobile", "divMessage", "Plese Enter Mother's Mobile Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtEmail", "divMessage", "Plese Enter Email Id.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtFatherAdharNo", "divMessage", "Plese Enter Father's Adhar Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtMotherAdharNo", "divMessage", "Plese Enter Mother's Adhar Number.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtPAN", "divMessage", "Plese Enter PAN Number.")) { }
        else { return false; }

        if (Validate.StringValueValidate("txtStudentAdharNo", "divMessage", "Plese Enter Student's Adhar Number.")) { }
        else { return false; }

        if (istransportrqd = document.getElementById('chkIsTransportRqd').checked == true) {
            if (Validate.IntValueValidate("ddlBusRoute", _MESSAGEDIVID, "Please Select Bus Route.")) { }
            else { return false; }
        }

        //if (Validate.StringValueValidate("txtBusRoute", "divMessage", "Plese Enter Bus Route Number.")) { }
        //else { return false; }
        if (Validate.StringValueValidate("txtStudentUserName", "divMessage", "Plese Enter Student's UserName.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtStudentPassword", "divMessage", "Plese Enter Student's Password.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtParentUsername", "divMessage", "Plese Enter Parent's UserName.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtParentPassword", "divMessage", "Plese Enter Parent's Password.")) { }
        else { return false; }

        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSave");
        Disablebutton("btnSaveNext");

    }
    catch (e) {
        MyAlert("OnAddStudentSuccess" + e);
    }
}

function OnUpdateStudentSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        switch (data.code) {
            case 0:
                SetHtml("divMessage", MESSAGES.UpdateSuccessMessage);
                if (!data.studentModel.IsRedirecting) {
                    window.location = GetDomain(_DOMAINDIVID) + "StudentFee/Index?studentId=" + data.studentModel.StudentId + "&classId=" + data.studentModel.ClassId + "&isNewAdmission=" + data.studentModel.IsNewAdmission;
                }
                break;
            case -1:
                SetHtml("divMessage", MESSAGES.UpdateFailMessage);
                break;
            case -2:
                SetHtml("divMessage", MESSAGES.UpdateFailMessage);
                break;
        }
    }
    catch (e) { MyAlert("OnUpdateStudentSuccess" + e); }
}

function OnAddFeeBegin() {
    try {
        if (Validate.IntValueValidate("ddlAdmissionType", _MESSAGEDIVID, "Please Select AdmissionType")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlClass", _MESSAGEDIVID, "Please Select Class")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtAdmissionFee", _MESSAGEDIVID, "Please Enter Admission Fee")) { }
        else { return false; }
        DisplayLoader(_POPUPLOADERDIVID);
        Disablebutton("btnAdd");
    }
    catch (e)
    { MyAlert("OnAddFeeBegin : " + e) }
}

function OnAddFeeSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
        if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "Fee/SeeAllFee"; }
        if (data.code != 0) { Enablebutton("btnAdd") }
    }
    catch (e) { MyAlert("OnAddFeeSuccess" + e); }
}

function BindSectionsDropdownByClass() {
    $("#ddlClass").on("change", function () {
        BindCoreSectionsDropDownByClass();
    });
}

function BindCoreSectionsDropDownByClass(IsTriggeredByCode) {
    try {
        $("#ddlSection").prop('disabled', false);
        $("#ddlSection").empty();

        var value = $("#ddlClass option:selected").val();
        if (value == "") {
            $('#ddlSection').append(new Option("Please Select A Section", 0));
            $("#ddlSection").prop('disabled', true);
            return;
        }

        var url = GetDomain(_DOMAINDIVID) + "Common/SectionByClassId?classId=" + value;

        $.ajax({
            method: "POST",
            url: url,
            success: function (data) {

                data = eval(data);

                if (data.code == -1) {
                    $('#ddlSection').append(new Option("Please Select A Section", 0));
                    $("#ddlSection").prop('disabled', true);
                    return;
                }

                if (data.code == 0) {

                    $('#ddlSection').append(new Option("Please Select A Section", 0));
                    $.each(data.sections, function (i, item) {
                        $('#ddlSection').append(new Option(data.sections[i].SectionName, data.sections[i].SectionId));
                    });

                    //set selected index- ONLY_FOR_EDIT
                    if (IsTriggeredByCode != null) {
                        if (IsTriggeredByCode) {
                            var v = $("#hdnSectionId").val();
                            if (v != null && v != "") { $('#ddlSection').val(v); }
                            $("#hdnSectionId").val(v);
                        }
                    }
                }
            },
            error: function () {
                $('#divInfo').html('<p>An Error Has Occurred</p>');
            }
        });
    }
    catch (e) {
        MyAlert("BindCoDropDownListForState :" + e);
        return false;
    }
}

function SetRedirectingValue() {
    try {
        $("#hdnIsRedirecting").val(true);
        $("#btnSaveNext").click();
    }
    catch (e) {
        MyAlert("SetRedirectingValue :" + e);
        return false;
    }
}

function OnSearchStudentByAdvanceSearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        var fn = $("#txtFirstName").val();
        var mn = $("#txtMiddleName").val();
        var ln = $("#txtLastName").val();
        var cls = $("#ddlClass").val();
        var section = $("#ddlSection").val();
        var studentId = $("#txtStudentId").val();
        var fatherName = $("#txtFatherName").val();
        var motherName = $("#txtMotherName").val();

        if ((fn == "" || fn == null) && (mn == "" || mn == null) && (ln == "" || ln == null) && (cls == "" || cls == null) && (section == "" || section == null)
            && (studentId == "" || studentId == null) && (fatherName == "" || fatherName == null) && (motherName == "" || motherName == null)
            ) {
            SetHtml("divMessage", "Please Enter Value In Any Of The Above Fields");
            return false
        }

        DisplayLoader(_LOADERDIVID);

    } catch (e) {
        MyAlert("OnSeachClassByAdvanceSearchBegin : " + e);
    }
}

function OnSearchStudentByAdvanceSearchSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, "divResult");
}

function OnStudentAdvanceSeachIndexReady() {
    BindSectionsDropdownByClass();
    SetValueBlank("txtStudentId");
}

function EditStudent(id) {
    try {
        var redirectto = GetDomain(_DOMAINDIVID) + "UpdateStudent/Index?id=";
        GetEncryptedId(id, redirectto);
    }
    catch (e) {
        MyAlert("EditStudent" + e);
    }
}

function DeleteStudent(id) {
    try {
        var redirectto = GetDomain(_DOMAINDIVID) + "DeleteStudent/Index?id=";
        GetEncryptedId(id, redirectto);

        //var url = GetDomain(_DOMAINDIVID) + "DeleteStudent/Index?id=" + id;
        //FillViewInModelDiv(url, "myModal");
    }
    catch (e) {
        MyAlert("DeleteStudent" + e);
    }
}

function OnDeleteStudentBegin() {
    DisplayLoader(_LOADERDIVID);
}

function OnDeleteStudentSuccess() {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
    }
    catch (e) { MyAlert("OnDeleteStudentSuccess" + e); }
}

function ResetValues() {
    try {
        $(".ToReset").val('');
        $("#datepicker").val(new Date());
    } catch (e) {
        MyAlert("ResetValues : " + e);
    }
}

function CheckValidateStartWithClass() {
    try {
        var classjoin = GetValue("ddlClass");
        var classStartWith = GetValue("ddlClassStartWith");
        if (classStartWith > classjoin) {
            alert("Start Class Cannnot Be Grater Than Class Join");
            $("#ddlClassStartWith").val('');
        }
    } catch (e) {
        MyAlert("CheckValidateStartWithClass : " + e);
    }
}

function SetAdmissionType(value) {
    try {

        if (value) {
            $("#hdnAdmissionTypeId").val('1');
            $("#NewAdmission").prop('checked', true);
            $("#ReAdmission").prop('checked', false);
        }
        else {
            $("#hdnAdmissionTypeId").val('2');
            $("#NewAdmission").prop('checked', false);
            $("#ReAdmission").prop('checked', true);
        }
        var classid = GetValue("txtClassId");
        SearchFee(classid, value, false);

    } catch (e) {
        MyAlert("SetAdmissionType : " + e);
    }
}

function SearchFee(classid, value, callbymaster) {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/SearchFee?classId=" + classid + "&admissionType=" + value + "&callbymaster=" + callbymaster;
    FillViewInModelDiv(url, "divFeeDetail");
}

function AddStudentFeeIndexReady() {
    CalculatePayableAmount();
    if (parseInt(GetValue("hdnAdmissionTypeId")) == 1) {
        $("#NewAdmission").prop('checked', true);
        $("#ReAdmission").prop('checked', false);
    }
    else {
        $("#NewAdmission").prop('checked', false);
        $("#ReAdmission").prop('checked', true);
    }
}

function OnAddStudentFeeBegin() {
    SetHtmlBlank(_MESSAGEDIVID);
    if (Validate.IntValueValidate("txtAdmissionFee", "divMessage", "Please Enter Admission fee Value")) { }
    else { return false; }
    if (GetValue("txtDiscountAmount") > 0) {
        if (Validate.StringValueValidate("txtDiscountRemarks", _MESSAGEDIVID, "Please Enter Discount Remarks.")) { }
        else { return false; }
    }
    DisplayLoader(_LOADERDIVID);
}

function OnAddStudentFeeSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultMSG(data, "divMessage", "Admission Fee Paid Successfully", "Failed To Update Please Try Again Later");
    if (data.code == 0) {
        var html = "<button id='btnPrint' type='button' class='btn btn-default btn-adeptsubmit btn-adeptsubmitfirst' onclick=GenerateReceipt(" + data.id + ",'true') data-toggle='modal' data-target='#myModal'>Generate Receipt</button>";
        SetHtml("btndiv", html);
    }
    if (data.code != 0) { Enablebutton("btnSubmit"); Enablebutton("btnClose"); }
}

function OnAddFeeReady() {
    SetValueBlank("txtAdmissionFee");

    $("#ddlClass").on("change", function () {
        var cid = GetValue("ddlClass");
        var adty = GetValue("ddlAdmissionType");
        if (adty == 1) { adty = true; } else { adty = false; }
        SearchFee(cid, adty, true);
    });
}

function OnEditFeeBegin() {
    DisplayLoader(_LOADERDIVID);
    Disablebutton("btnEdit");
    Disablebutton("btnReset");
}

function OnEditFeeSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
        if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "Fee/SeeAllFee"; }
        if (data.code != 0) { Enablebutton("btnEdit"); }
    } catch (e)
    { MyAlert("OnEditFeeSuccess :" + e); }
}

function OnFeeAdvanceSeachIndexReady() { }

function OnSearchFeeByAdvanceSearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        var admissionType = GetValue("ddlAdmissionType");
        var cls = GetValue("ddlClass");

        if ((admissionType == "" || admissionType == null) && (cls == "" || cls == null)) {
            SetHtml("divMessage", "Please Enter Value In Any Of The Above Fields");
        }

        DisplayLoader(_LOADERDIVID);

    } catch (e) {
        MyAlert("OnSearchFeeByAdvanceSearchBegin : " + e);
    }
}

function OnSearchFeeByAdvanceSearchSuccess() {
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, "divResult");
}

function EditFee(id) {
    try {
        var redirecto = GetDomain(_DOMAINDIVID) + "Fee/EditFeeIndex?id=";
        GetEncryptedId(id, redirecto);
    }
    catch (e) {
        MyAlert("EditFee" + e);
    }
}

function OnStudentFeeAdvanceSeachIndexReady() {
    BindSectionsDropdownByClass();
    $("#ddlSection").prop('disabled', true);
    var currentDate = new Date();
    $('#datepicker').datepicker({
        changeMonth: true,
        numberOfMonths: 1,
        minDate: currentDate,
        value: new Date(),
        autoclose: true,
    });
    $('#datepicker1').datepicker({
        changeMonth: true,
        numberOfMonths: 1,
        minDate: currentDate,
        value: new Date(),
        autoclose: true,
    });
}

function OnSearchStudentFeeByAdvanceSearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        var section = GetValue("ddlSection");
        var cls = GetValue("ddlClass");
        var stdName = GetValue("txtStudentName");

        //if ((section == "" || section == null) && (cls == "" || cls == null) && (stdName == "" || stdName == null)) {
        //    SetHtml("divMessage", "Please Enter Value In Any Of The Above Fields");
        //    return false;
        //}

        DisplayLoader(_LOADERDIVID);

    } catch (e) {
        MyAlert("OnSearchStudentFeeByAdvanceSearchBegin : " + e);
    }
}

function OnSearchStudentFeeByAdvanceSearchSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, "divResult");
}

function ViewStudent(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/SearchStudent?id=" + data.id;
                    FillViewInModelDiv(url, "myModal");
                }
                if (data.message == "n") {
                }
            }
        });
    } catch (e)
    { MyAlert("ViewStudent : " + e); }
}

function UpdateFee(sid, cid, secid, counter) {
    try {
        var adty = GetHtml("tdAdmissionType" + counter);
        //alert(adty);
        //if (adty == "Yes") { adty = true; } else { adty = false; }
        window.location = GetDomain(_DOMAINDIVID) + "StudentFee/Index?studentId=" + sid + "&classId=" + cid + "&sectionId=" + secid + "&isNewAdmission=" + adty;
    }
    catch (e) {
        MyAlert("UpdateFee : " + e);
    }
}

function BuildLoderHTML() {
    var html = "<div style='margin-top: 10px;' class='text-center'><img src='" + GetDomain(_DOMAINDIVID) + "Images/loader.gif'/></div>";
    return html;
}

function OnLogInActAdvanceSeachIndexReady() {
    SetValueBlank("txtStudentId");
    SetValueBlank("txtUserTypeId");
    var currentDate = new Date();
    $('#txtStartDate').datepicker({
        changeMonth: true,
        numberOfMonths: 1,
        minDate: currentDate,
        value: new Date(),
        autoclose: true,
    });
    $('#txtEndDate').datepicker({
        changeMonth: true,
        numberOfMonths: 1,
        minDate: currentDate,
        value: new Date(),
        autoclose: true,
    });
}

function OnSearchLoginActByAdvanceSearchBegin() {
    DisplayLoader(_LOADERDIVID);
    Disablebutton("btnSearch");
}

function OnSearchLoginActByAdvanceSearchSuccess(data) {
    Enablebutton("btnSearch");
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, _RESULTDIVID);
}

function ShowHideClassSection() {
    try {
        if (document.getElementById('chkboxIsClassTeacher').checked) {
            $("#hdnIsClassTeacher").val("true");
            $("#divClassDetails").show();
        }
        else {
            $("#hdnIsClassTeacher").val("false");
            $("#chkboxIsClassTeacher").prop("checked", false);
            $("#divClassDetails").hide();
            $("#ddlClass").val("");
            $("#ddlSection").val("");
            $("#ddlSection").prop("disabled", true);
        }
    }
    catch (e) {
        MyAlert(e);
    }
}

function ShowHideSubjects() {
    if (document.getElementById('chkboxIsSubjectTeacher').checked) {
        $("#hdnIsSubjectTeacher").val("true");
        $("#divSubjectDetails").show();
    }
    else {
        $("#hdnIsSubjectTeacher").val("false");
        $("#ddlSubject").val("");
        $("#divSubjectDetails").hide();
    }
}

function OnAddFacultyIndexReady() {
    try {
        $("#ddlUserType option[value='4']").remove();
        $("#ddlUserType option[value='5']").remove();
        BindSectionsDropdownByClass();
        var uid = $("#divUserType").html();
        if (uid == LoginType.Admin) {
            $("#ddlUserType option[value='1']").remove();
        }
        if (uid == LoginType.Principle) {
            $("#divClassTeacher").show();
        }
        //$(":checkbox").on("click", function () {
        //    if ($(this).is(":checked")) {
        //        $("#hdnIsClassTeacher").val("true");
        //        $("#divClassDetails").show();
        //    }
        //    else {
        //        $("#hdnIsClassTeacher").val("false");
        //        $("#chkboxIsClassTeacher").prop("checked", false);
        //        $("#divClassDetails").hide();
        //        $("#ddlClass").val("");
        //        $("#ddlSection").val("0");
        //        $("#ddlSection").prop("disabled", true);
        //    }
        //});

        $("#ddlUserType").on("change", function () {
            var uid = $("#ddlUserType").val();
            if (uid == LoginType.Faculty) {
                $("#divClassTeacher").show();
            }
            else {
                $("#chkboxIsClassTeacher").prop("checked", false);
                $("#divClassTeacher").hide();
                $("#divClassDetails").hide();
                $("#ddlClass").val("");
                $("#ddlSection").val("");
                $("#ddlSection").prop("disabled", true);
            }
        });

    } catch (e) {
        MyAlert("OnAddFacultyIndexReady : " + e);
    }
}

function OnAddFacultyBegin() {
    try {
        if (GetHtml("divUserType") == LoginType.Admin) {
            if (Validate.IntValueValidate("ddlUserType", _MESSAGEDIVID, "Please Select User Type.")) { }
            else { return false; }
        }

        if (Validate.StringValueValidate("txtFacultyName", _MESSAGEDIVID, "Please Enter Faculty Name.")) { }
        else { return false; }

        if (isclassteacher = document.getElementById('chkboxIsClassTeacher').checked == true) {

            if (Validate.IntValueValidate("ddlClass", _MESSAGEDIVID, "Please Select Class.")) { }
            else { return false; }

            if (Validate.IntValueValidate("ddlSection", _MESSAGEDIVID, "Please Select Section Type.")) { }
            else { return false; }
        }

        if (issubjectteacher = document.getElementById('chkboxIsSubjectTeacher').checked == true) {
            if (Validate.IntValueValidate("ddlSubject", _MESSAGEDIVID, "Please Select Subject.")) { }
            else { return false; }
        }
        if (Validate.StringValueValidate("txtEmail", _MESSAGEDIVID, "Please Enter Email Id.")) { }
        else { return false; }

        if (!isEmail(GetValue("txtEmail"))) {
            SetHtml(_MESSAGEDIVID, "Please Enter Valid Email.");
            return false;
        }

        if (Validate.StringValueValidate("txtContactNumber", _MESSAGEDIVID, "Please Enter Contact No.")) { }
        else { return false; }

        if (Validate.StringValueValidate("txtUserName", _MESSAGEDIVID, "Please Enter User Name.")) { }
        else { return false; }

        if (Validate.StringValueValidate("txtPassword", _MESSAGEDIVID, "Please Enter Password Name.")) { }
        else { return false; }

        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnAdd");
        Disablebutton("btnReset");
    }
    catch (e) {
        MyAlert("OnAddFacultyBegin : " + e);
    }
}

function OnAddFacultySuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
        if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "Faculty/SeeAllFaculties"; }
        if (data.code != 0) { Enablebutton("btnAdd"); }
    } catch (e) {
        MyAlert("OnAddFacultySuccess : " + e);
    }
}

function EditFaculty(id) {
    try {
        var redirectto = GetDomain(_DOMAINDIVID) + "Faculty/EditFacultyIndex?id="
        GetEncryptedId(id, redirectto);

    } catch (e)
    { MyAlert("EditFaculty : " + e); }
}

function OnEditFacultyIndexReady() {
    try {
        BindSectionsDropdownByClass();
        BindCoreSectionsDropDownByClass(true);
        var uid = $("#hdnUid").html();
        if (uid == LoginType.Faculty) { $("#divClassTeacher").show(); }
        var isct = $("#hdnIsClassTeacher").val();
        if (isct == "True") {
            $("#chkboxIsClassTeacher").prop("checked", true);
            $("#divClassDetails").show();
        }
        if (isct == "False") {
            $("#chkboxIsClassTeacher").prop("checked", false);
            $("#divClassDetails").hide();
            $("#ddlClass").val("");
            $("#ddlSection").val("");
            $("#ddlSection").prop("disabled", true);
        }
        var isst = $("#hdnIsSubjectTeacher").val();
        if (isst == "True") {
            $("#chkboxIsSubjectTeacher").prop("checked", true);
            $("#divSubjectDetails").show();
        }
        if (isst == "False") {
            $("#chkboxIsSubjectTeacher").prop("checked", false);
            $("#divSubjectDetails").hide();
        }

        $("#ddlUserType").on("change", function () {
            var uid = $("#ddlUserType").val();
            if (uid == LoginType.Faculty) {
                $("#divClassTeacher").show();
            }
            else {
                $("#chkboxIsClassTeacher").prop("checked", false);
                $("#divClassTeacher").hide();
                $("#divClassDetails").hide();
                $("#ddlClass").val("");
                $("#ddlSection").val("");
                $("#ddlSection").prop("disabled", true);
            }
        });
    }
    catch (e) {
        MyAlert("OnEditFacultyIndexReady : " + e);
    }
}

function OnEditFacultyBegin() {
    SetHtmlBlank(_MESSAGEDIVID);
    if (GetHtml("divUserType") == LoginType.Admin) {
        //MyAlert($("#ddlUserType").val());
        if (Validate.IntValueValidate("ddlUserType", _MESSAGEDIVID, "Please Select User Type.")) { }
        else { return false; }
    }
    if (Validate.StringValueValidate("txtFacultyName", _MESSAGEDIVID, "Please Enter Faculty Name.")) { }
    else { return false; }

    if (isclassteacher = document.getElementById('chkboxIsClassTeacher').checked == true) {
        if (Validate.IntValueValidate("ddlClass", _MESSAGEDIVID, "Please Select Class.")) { }
        else { return false; }
        if (Validate.IntValueValidate("ddlSection", _MESSAGEDIVID, "Please Select Section.")) { }
        else { return false; }
    }

    if (issubjectteacher = document.getElementById('chkboxIsSubjectTeacher').checked == true) {
        if (Validate.IntValueValidate("ddlSubject", _MESSAGEDIVID, "Please Select Subject.")) { }
        else { return false; }
    }

    if (Validate.StringValueValidate("txtEmail", _MESSAGEDIVID, "Please Enter Email Id.")) { }
    else { return false; }

    if (!isEmail(GetValue("txtEmail"))) {
        SetHtml(_MESSAGEDIVID, "Please Enter Valid Email.");
        return false;
    }

    if (Validate.StringValueValidate("txtContactNumber", _MESSAGEDIVID, "Please Enter Contact No.")) { }
    else { return false; }

    if (Validate.StringValueValidate("txtUserName", _MESSAGEDIVID, "Please Enter User Name.")) { }
    else { return false; }

    if (Validate.StringValueValidate("txtPassword", _MESSAGEDIVID, "Please Enter Password Name.")) { }
    else { return false; }

    DisplayLoader(_LOADERDIVID);

    Disablebutton("btnUpdate");
}

function OnEditFacultySuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
    if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "Faculty/SeeAllFaculties"; }
    if (data.code != 0) { Enablebutton("btnUpdate"); }
}

function DownloadAllClasses() {

    $("#divTable").table2excel({
        exclude: ".noExl",
        name: "Excel Document Name",
        filename: DOWNLOADFILENAME.AllClasses,
        fileext: ".xls",
    });
}

function DownloadRecord(fileName) {
    $("#divTable").table2excel({
        exclude: ".noExl",
        name: "Excel Document Name",
        filename: fileName,
        fileext: ".xls",
    });
}

function AddNewClass() {
    window.location = GetDomain(_DOMAINDIVID) + "AddClass/Index";
}

function AddNewFee() {
    window.location = GetDomain(_DOMAINDIVID) + "Fee/AddIndex";
}

function ViewSections(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/SearchSectionPopup?id=";
        SetEncryptIdFillView(id, "myModal", url);
    }
    catch (e) {
        MyAlert("ViewSections : " + e);
    }
}

function EditSectionPopup(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditSectionPopup?id=";
        SetEncryptIdFillView(id, "myModal", url);

    } catch (e) {
        MyAlert("EditSectionPopup : " + e);
    }
}

function OnEditSectionBegin() {
    try {
        if (Validate.StringValueValidate("txtSectionName", _POPUPMESSAGEDIVID, "Please Enter Section Name.")) { }
        else { return false; }
        DisplayLoader(_POPUPLOADERDIVID);
    } catch (e) {
        MyAlert("OnEditSectionBegin : " + e);
    }
}

function OnEditSectionSuccess(data) {
    try {
        HideLoader(_POPUPLOADERDIVID);
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UniversalSuccessMessage, MESSAGES.UniversalFailMessage);
    } catch (e) {
        MyAlert("OnEditSectionSuccess : " + e);
    }
}

function AddNewSection() {
    try {
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AddNewSection";
        FillViewInModelDiv(url, "myModal");
    } catch (e) {

    }
}

function OnAddSectionBegin() {
    try {
        if (Validate.IntValueValidate("ddlClass", _POPUPMESSAGEDIVID, "Please Select Class.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtSectionName", _POPUPMESSAGEDIVID, "Please Enter Section Name.")) { }
        else { return false; }
        DisplayLoader(_POPUPLOADERDIVID);
    } catch (e) {
        MyAlert("OnEditSectionBegin : " + e);
    }
}

function OnAddSectionSuccess(data) {
    try {
        HideLoader(_POPUPLOADERDIVID);
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UniversalSuccessMessage, MESSAGES.UniversalFailMessage);
        if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "SeeAllSections/Index"; }
        if (data.code != 0) { Enablebutton("btnSubmit"); }
    } catch (e) {
        MyAlert("OnAddSectionSuccess : " + e);
    }
}

function PayMonthlyFee(sid, cid, secid, adfId, routeid, counter) {
    try {
        var adty = GetHtml("tdAdmissionType" + counter);
        //if (adty == "Yes") { adty = true; } else { adty = false; }
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/PayMonthlyFee?cid=" + cid + "&sid=" + sid + "&sectionId=" + secid + "&isNewAdmission=" + adty + "&adfId=" + adfId + "&routeId=" + routeid;
        FillViewInModelDiv(url, "myModal");
    }
    catch (e) {
        MyAlert("PayMonthlyFee : " + e);
    }
}

function OnPayMonthlyFeeIndexReady() {
    CalculatePayableAmount();
    ShowHideAnnualFee();
}

function CalculatePayableAmount() {
    try {
        var tf = parseFloat(GetHtml("hdnTotalFees"));
        var da = parseFloat(GetValueOrZero("txtDiscountAmount"));
        if (da > tf) {
            MyAlert("Discount Amount Can't Be Greater Than Total Amount.");
            return false;
        }
        $("#txtTotalPayableAmount").val(tf - da);
    }
    catch (e) {
        MyAlert("CalculatePayableAmount : " + e);
    }
}

function ShowHideAnnualFee() {
    var smonth = GetValue("ddlMonth");
    var affpm = GetValue("hdbAFFPM");
    if (smonth == affpm) {
        $("#divAnnualFunctionFee").removeClass("display_none");
        $("#txtAnnualFunctionFee").val(GetHtml("hdnAnnualFunctionFee"));
        $("#txtTotalPayableAmount").val((parseFloat($("#txtTotalPayableAmount").val()) + parseFloat(GetHtml("hdnAnnualFunctionFee"))));
    }
    //else
    //{
    //    $("#divAnnualFunctionFee").hide();
    //    $("#txtAnnualFunctionFee").val('0');
    //    $("#txtTotalPayableAmount").val((parseFloat($("#txtTotalPayableAmount").val()) - parseFloat(GetHtml("hdnAnnualFunctionFee"))));
    //}
}

function OnPayMonthlyFeeBegin() {
    SetHtmlBlank(_POPUPMESSAGEDIVID);
    if (GetValue("txtDiscountAmount") > 0) {
        if (Validate.StringValueValidate("txtDiscountRemarks", _POPUPMESSAGEDIVID, "Please Enter Discount Remarks.")) { }
        else { return false; }
    }
    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnPayMonthlyFeeSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    if (data.code == -3) {
        SetHtml(_POPUPMESSAGEDIVID, "This Month Fee Already paid. Duplicate Entery Not Allowed.");
        return false;
    }
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Monthly Fee Paid Successfully.", "Failed To Pay Please Try Again Later.");
    if (data.code == 0) {
        var html = "<button id='btnPrint' type='button' class='btn btn-default btn-adeptsubmit btn-adeptsubmitfirst' onclick=GenerateReceipt(" + data.id + ",'false')>Generate Receipt</button>";
        SetHtml("btndiv", html);
    }
    //if (data.code != 0) { Enablebutton("btnSubmit"); Enablebutton("btnClose"); }
}

function GenerateReceipt(id, isafr) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/GenerateReceipt?id=" + id + "&isAdmissionPaymentReceipt=" + isafr;
        FillViewInModelDiv(url, "myModal");
    }
    catch (e) {
        MyAlert("GenerateReceipt : " + e);
    }
}

function AddNewSubject() {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AddNewSubject";
    FillViewInModelDiv(url, "myModal");
}

function OnAddSubjectBegin() {
    if (Validate.StringValueValidate("txtSubjectName", _POPUPMESSAGEDIVID, "Please Enter Subject Name.")) { }
    else { return false; }
    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnAddSubjectSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UniversalSuccessMessage, MESSAGES.UniversalFailMessage);
}

function EditSubjectPopup(id) {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditSubjectPopup?id=";
    SetEncryptIdFillView(id, "myModal", url);
}

function OnEditSubjectBegin() {
    if (Validate.StringValueValidate("txtSubjectNameP", _POPUPMESSAGEDIVID, "Please Enter Subject Name.")) { }
    else { return false; }
    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnEditSubjectSuccess(data) {
    try {
        HideLoader(_POPUPLOADERDIVID);
        Enablebutton("btnSubmit")
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
    } catch (e) {
        MyAlert("OnEditSubjectSuccess : " + e);
    }
}

function ShowHideBusRoute() {
    if (document.getElementById('chkIsTransportRqd').checked) {
        $("#hdnTransportRqd").val("true");
        $("#divBusRoute").show();
    }
    else {
        $("#hdnTransportRqd").val("false");
        $("#divBusRoute").hide();
        $("#ddlBusRoute").val('');
    }
}

function ShowTranportCharge() {
    $("#ddlBusRoute").on('change', function () {
        var value = $("#ddlBusRoute option:selected").val();
        if (value == "" || value == 0) { return; }
        var url = GetDomain(_DOMAINDIVID) + "Common/SearchTransportCharge?id=" + value;
        $.ajax({
            method: "POST",
            url: url,
            success: function (data) {

                data = eval(data);

                if (data.message == "n") {
                    //show some message and return.
                    return;
                }
                if (data.message == "y") {
                    $("#divCharges").show();
                    $("#divtcharge").html(data.TransportCharge);
                }
            },
            error: function () {
                $('#divInfo').html('<p>An Error Has Occurred</p>');
                $("#divCharges").hide();
            }
        });
    });
}

function OnAddBusRouteBegin() {
    if (Validate.StringValueValidate("txtBusStartFrom", _POPUPMESSAGEDIVID, "Please Enter Bus Start From.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtBusEndAt", _POPUPMESSAGEDIVID, "Please Enter Bus End At.")) { }
    else { return false; }
    if (Validate.IntValueValidate("txtBusRouteNumber", _POPUPMESSAGEDIVID, "Please Enter Bus Route Number.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtTranportCharges", _POPUPMESSAGEDIVID, "Please Enter Charges.")) { }
    else { return false; }

    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnAddBusRouteSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UniversalSuccessMessage, MESSAGES.UniversalFailMessage);
    if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "BusRoute/SeeAllBusRoutesIndex"; }
    if (data.code != 0) { Enablebutton("btnSubmit"); }
}

function OnEditBusRouteBegin() {
    if (Validate.StringValueValidate("txtBusStartFrom", _POPUPMESSAGEDIVID, "Please Enter Bus Start From.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtBusEndAt", _POPUPMESSAGEDIVID, "Please Enter Bus End At.")) { }
    else { return false; }
    if (Validate.IntValueValidate("txtBusRouteNumber", _POPUPMESSAGEDIVID, "Please Enter Bus Route Number.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtTranportCharges", _POPUPMESSAGEDIVID, "Please Enter Charges.")) { }
    else { return false; }

    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnEditBusRouteSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
    if (data.code == 0) { window.location = GetDomain(_DOMAINDIVID) + "BusRoute/SeeAllBusRoutesIndex"; }
    if (data.code != 0) { Enablebutton("btnSubmit"); }
}

function AddNewBusRoutes() {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AddNewBusRoutePopup";
    FillViewInModelDiv(url, "myModal");
}

function EditBusRoutePopup(id) {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditBusRoutePopup?id=";
    SetEncryptIdFillView(id, "myModal", url);
}

function OnAddBusRouteReady() {
    try {
        SetValueBlank("txtTranportCharges");

    } catch (e) {
        MyAlert("OnAddBusRouteReady : " + e);
    }
}

function OnEditBusRouteReady() {
    try {
        SetValueBlank("txtTranportCharges");
    } catch (e) {
        MyAlert("OnEditBusRouteReady : " + e);
    }
}

function OnUpdateProfileBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        if (Validate.StringValueValidate("txtCurrentPassword", _MESSAGEDIVID, "Please Enter Current Message")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtNewPassword", _MESSAGEDIVID, "Please Enter Current Message")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtReNewPassword", _MESSAGEDIVID, "Please Enter Current Message")) { }
        else { return false; }
        if (GetValue("txtReNewPassword") != GetValue("txtNewPassword")) {
            SetHtml(_MESSAGEDIVID, "New Password Not Match With Re-New Password.");
            return false;
        }
        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSubmit");
        Disablebutton("btnReset");
    }
    catch (e) {
        MyAlert("OnUpdateProfileBegin : " + e);
    }
}

function OnUpdateProfileSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        switch (data.code) {
            case 0:
                SetHtml(_MESSAGEDIVID, "Sucessfully Update, Use New Password For Next Login.");
                $("#btnReset").click();
                break;
            case -1:
                SetHtml(_MESSAGEDIVID, "Current Password Not Matched.");
                Enablebutton("btnSubmit");
                Enablebutton("btnReset");
                break;
            case -2:
                SetHtml(_MESSAGEDIVID, "Failed To Update Please Try Again Later.");
                Enablebutton("btnSubmit");
                Enablebutton("btnReset");
                break;
            case -2:
                SetHtml(_MESSAGEDIVID, "Failed To Update Please Try Again Later.");
                Enablebutton("btnSubmit");
                Enablebutton("btnReset");
                break;
        }
    } catch (e) {
        MyAlert("OnUpdateProfileSuccess : " + e);
    }
}

function AddNewLateFeePanelty() {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AddNewLateFeePanelty";
    FillViewInModelDiv(url, "myModal");
}

function OnAddLateFeePaneltyReady() {
    SetValueBlank("txtDaysAfter");
    SetValueBlank("txtFine");
}

function OnAddLateFeePaneltyMasterBegin() {
    SetHtmlBlank(_POPUPMESSAGEDIVID);
    if (Validate.StringValueValidate("txtDaysAfter", _POPUPMESSAGEDIVID, "Please Enter Days After.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtFine", _POPUPMESSAGEDIVID, "Please Enter Fine.")) { }
    else { return false; }
    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnAddLateFeePaneltyMasterSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Successfully Added.", "Failed To Add Late Fee Panelty.");
}

function EditLateFeePaneltyMasterPopup(id) {
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditLateFeePaneltyPopup?id=";
    SetEncryptIdFillView(id, "myModal", url);
}

function OnEditLateFeePaneltyMasterBegin() {
    SetHtmlBlank(_POPUPMESSAGEDIVID);
    if (Validate.StringValueValidate("txtDaysAfter", _POPUPMESSAGEDIVID, "Please Enter Days After.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtFine", _POPUPMESSAGEDIVID, "Please Enter Fine.")) { }
    else { return false; }
    DisplayLoader(_POPUPLOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnClose");
}

function OnEditLateFeePaneltyMasterSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Successfully Updated.", "Failed To Update Late Fee Panelty.");
}

function OnAddHomeWorkBegin() {
    SetHtmlBlank(_MESSAGEDIVID);
    if (Validate.IntValueValidate("ddlClass", _MESSAGEDIVID, "Please Select A Class.")) { }
    else { return false; }
    if (Validate.IntValueValidate("ddlSection", _MESSAGEDIVID, "Please Select A Section.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtHomeWorkText", _MESSAGEDIVID, "Please Enter Home Work Details.")) { }
    else { return false; }
    if (Validate.IntValueValidate("ddlSubject", _MESSAGEDIVID, "Please Select A Subject.")) { }
    else { return false; }

    Disablebutton("btnSubmit");
    Disablebutton("btnReset");
    DisplayLoader(_LOADERDIVID);
}

function OnAddHomeWorkSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultMSG(data, _MESSAGEDIVID, "Successfully Assigned.", "Failed To Assign Please Try Again Later.");
    if (data.code == 0) { }
    else {
        Enablebutton("btnSubmit");
        Enablebutton("btnReset");
    }
}

function OnAddHomeWorkIndex() {
    try {
        BindSectionsDropdownByClass();
        var isst = GetHtml("hdnIsSubjectTeacher");
        if (isst) {
            $("#ddlSubject").prop("disabled", true);
        }
    }
    catch (e) {
        MyAlert("OnAddHomeWorkIndex : " + e);
    }
}

function OnSearchHomeWorkIndexReady() {
    try {
        CreateDatePicker("txtStartDate");
        CreateDatePicker("txtEndDate");
        GetHtml("hdnIsSubjectTeacher");
        GetHtml("hdnIsClassTeacher");
        if (GetHtml("hdnIsSubjectTeacher")) { $("#ddlSubject").prop('disabled', true); }
    } catch (e) {
        MyAlert("OnSearchHomeWorkIndexReady : " + e);
    }
}

function OnSearchAssignedHomeworkBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSubmit");
        Disablebutton("btnReset");
    } catch (e) {
        MyAlert("OnSearchAssignedHomeworkBegin : " + e);
    }
}

function OnSearchAssignedHomeworkSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        Enablebutton("btnSubmit");
        Enablebutton("btnReset");
        FillSuccessResultView(data, _RESULTDIVID);
    }
    catch (e) {
        MyAlert("OnSearchAssignedHomeworkSuccess : " + e);
    }
}

function OnAddCircularIndex() {
    CreateDatePicker("txtPublishedOn");
    $("#chkIsForAdmin").prop("checked", true);
}

function OnAddCircularBegin() {
    SetHtmlBlank(_MESSAGEDIVID);
    if (Validate.StringValueValidate("txtSubject", _MESSAGEDIVID, "Subject Cannot be Null or Blank.")) { }
    else { return false; }
    if (Validate.StringValueValidate("txtDetails", _MESSAGEDIVID, "Details Cannot be Null or Blank.")) { }
    else { return false; }
    HideLoader(_LOADERDIVID);
    Disablebutton("btnSubmit");
    Disablebutton("btnReset");
    DisplayLoader(_LOADERDIVID);
}

function OnAddCircularSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultMSG(data, _MESSAGEDIVID, "Circular Successfully Published.", "Failed To Publish Circular Please Try Again Later.");
    if (data.code != 0) {
        Enablebutton("btnSubmit");
        Enablebutton("btnReset");
        Enablebutton("btnSave");
        Enablebutton("btnSavePublish");
    }
}

function UploadCircularAttachment() {
    UploadCircular('divCircularUploadStatus', 'hdnAttachment', 'file_name', 'fileUpload');
}

function SaveCircular() {
    try {
        Disablebutton("btnSave");
        Disablebutton("btnSavePublish");
        $("#btnSubmit").click();

    } catch (e) {
        MyAlert("SaveCircular :" + e);
    }
}

function SavePublishCircular() {
    try {
        $("#hdnIsPublishNow").val('true');
        Disablebutton("btnSave");
        Disablebutton("btnSavePublish");
        $("#btnSubmit").click();
    } catch (e) {
        MyAlert("SavePublishCircular :" + e);
    }
}

function OnCircularSeachIndexReady() {
    try {
        CreateDatePicker("txtStartDate");
        CreateDatePicker("txtEndDate");

    } catch (e) {
        MyAlert("OnCircularSeachIndexReady : " + e);
    }
}

function OnSearchCircularBegin() {
    DisplayLoader(_LOADERDIVID);
}

function OnSearchCircularSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultView(data, _RESULTDIVID);
    } catch (e) {
        MyAlert("OnSearchCircularSuccess :" + e);
    }
}

function EditCircular(id) {
    try {
        var redirectto = GetDomain(_DOMAINDIVID) + "Circular/EditCircularIndex?id=";
        GetEncryptedId(id, redirectto);
    } catch (e) {
        MyAlert("EditCircular : " + e);
    }
}

function OnEditCircularIndex() {
    try {
        CreateDatePicker("txtPublishedOn");
    } catch (e) {
        MyAlert("OnEditCircularIndex : " + e);
    }
}

function OnEditCircularBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        if (Validate.StringValueValidate("txtSubject", _MESSAGEDIVID, "Subject Cannot be Null or Blank.")) { }
        else { return false; }
        if (Validate.StringValueValidate("txtDetails", _MESSAGEDIVID, "Details Cannot be Null or Blank.")) { }
        else { return false; }
        HideLoader(_LOADERDIVID);
        Disablebutton("btnSubmit");
        Disablebutton("btnReset");
        DisplayLoader(_LOADERDIVID);
    } catch (e) {
        MyAlert("OnEditCircularBegin : " + e);
    }
}

function OnEditCircularSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, "Circular Successfully Published.", "Failed To Publish Circular Please Try Again Later.");
        if (data.code != 0) {
            Enablebutton("btnSubmit");
            Enablebutton("btnReset");
            Enablebutton("btnSave");
            Enablebutton("btnSavePublish");
        }
    } catch (e) {
        MyAlert("OnEditCircularSuccess : " + e);
    }
}

function OnAddClassSubjectFacultyIndex() {
    try {
        BindSectionsDropdownByClass();
        BindFacultyDropdownBySubject();
    } catch (e) {
        MyAlert("OnAddClassSubjectFacultyIndex : " + e);
    }
}

function OnAddClassSubjectFacultyBegin() {
    SetHtmlBlank(_MESSAGEDIVID);
    if (Validate.IntValueValidate("ddlClass", _MESSAGEDIVID, "Please Select A Class")) { }
    else { return false; }
    if (Validate.IntValueValidate("ddlSection", _MESSAGEDIVID, "Please Select A Section")) { }
    else { return false; }
    if (Validate.IntValueValidate("ddlSubject", _MESSAGEDIVID, "Please Select A Subject")) { }
    else { return false; }
    if (Validate.IntValueValidate("ddlFaculty", _MESSAGEDIVID, "Please Select A Faculty")) { }
    else { return false; }
    Disablebutton("btnSubmit");
    Disablebutton("btnReset");
    DisplayLoader(_LOADERDIVID);
}

function OnAddClassSubjectFacultySuccess(data) {
    HideLoader(_LOADERDIVID);
    if (data.code == -3) {
        SetHtml(_MESSAGEDIVID, "For This Class and Subject Faculty Already Assigned Please Re-Assigned it Before New Faculty Assign.");
        return false;
    }
    FillSuccessResultMSG(data, _MESSAGEDIVID, "Successfully Assigned.", "Failed To Assign Please Try Again Later");
    if (data.code != 0) { }
}

function BindFacultyDropdownBySubject() {
    $("#ddlSubject").on("change", function () {
        BindCoreFacultiesDropDownBySubject();
    });
}

function BindCoreFacultiesDropDownBySubject(IsTriggeredByCode) {
    try {
        $("#ddlFaculty").prop('disabled', false);
        $("#ddlFaculty").empty();

        var value = $("#ddlSubject option:selected").val();
        if (value == "") {
            $('#ddlFaculty').append(new Option("Please Select A Faculty", 0));
            $("#ddlFaculty").prop('disabled', true);
            return;
        }

        var url = GetDomain(_DOMAINDIVID) + "Common/FacultyBySubjectId?subjectId=" + value;

        $.ajax({
            method: "POST",
            url: url,
            success: function (data) {

                data = eval(data);

                if (data.code == -1) {
                    $('#ddlFaculty').append(new Option("Please Select A Faculty", 0));
                    $("#ddlFaculty").prop('disabled', true);
                    return;
                }

                if (data.code == 0) {
                    $('#ddlFaculty').append(new Option("Please Select A Faculty", 0));
                    $.each(data.faculties, function (i, item) {
                        $('#ddlFaculty').append(new Option(data.faculties[i].FacultyName, data.faculties[i].FacultyId));
                    });

                    //set selected index- ONLY_FOR_EDIT
                    if (IsTriggeredByCode != null) {
                        if (IsTriggeredByCode) {
                            var v = $("#hdnFacultyId").val();
                            if (v != null && v != "") { $('#ddlFaculty').val(v); }
                            $("#hdnFacultyId").val(v);
                        }
                    }
                }
            },
            error: function () {
                $('#divInfo').html('<p>An Error Has Occurred</p>');
            }
        });
    }
    catch (e) {
        MyAlert("BindCoreFacultiesDropDownBySubject :" + e);
        return false;
    }
}

function OnStudentFeeReportingIndexReady() {
    try {
        $("ddlAcademicYear").val(GetHtml("divAcademicYear"));
        BindSectionsDropdownByClass();
    } catch (e) {
        MyAlert("OnStudentFeeReportingIndexReady : " + e);
    }
}

function OnStudentFeeReportingBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);

        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSearch");
        Disablebutton("btnReset");
    } catch (e) {
        MyAlert("OnStudentFeeReportingBegin : " + e);
    }
}

function OnStudentFeeReportingSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultView(data, _RESULTDIVID);
        if (data.code != 0) {
            Enablebutton("btnSearch");
            Enablebutton("btnReset");
        }
    } catch (e) {
        MyAlert("OnStudentFeeReportingSuccess : " + e);
    }
}

function OnSearchClassSubjectWiseFacultyIndexReady() {
    try {
        BindSectionsDropdownByClass();
        BindFacultyDropdownBySubject();
    } catch (e) {
        MyAlert("OnSearchClassSubjectWiseFacultyIndexReady : " + e);
    }
}

function OnClassSubjectFacultySearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSearch");
        Disablebutton("btnReset");
    } catch (e) {
        MyAlert("OnClassSubjectFacultySearchBegin : " + e);
    }
}

function OnClassSubjectFacultySearchSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        Enablebutton("btnSearch");
        Enablebutton("btnReset");
        FillSuccessResultView(data, _RESULTDIVID);
    } catch (e) {
        MyAlert("OnClassSubjectFacultySearchSuccess : " + e);
    }
}

function DeleteClassSubjectFacultyPopup(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "Common/EncrptId?id=" + id;
        $.ajax({
            method: "Post",
            url: url,
            success: function (data) {
                data = eval(data);
                if (data.message == "y") {
                    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/DeleteClassSubjectFacultyPopup?id=" + data.id;
                    FillViewInModelDiv(url, "myModal");
                }
                if (data.message == "n") {
                }
            }
        });

    } catch (e) {
        MyAlert("DeleteClassSubjectFacultyPopup : " + e);
    }
}

function OnDeleteClassSubjectFacultyBegin() {
    try {
        DisplayLoader(_POPUPLOADERDIVID);
        Disablebutton("btnSubmit");
    } catch (e) {
        MyAlert("OnDeleteClassSubjectFacultyBegin : " + e);
    }
}

function OnDeleteClassSubjectFacultySuccess(data) {
    try {
        HideLoader(_POPUPLOADERDIVID);
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Successfull Remove.", "Failed To Proceed Please Try Again Lator.");
        if (data.code != 0) { Enablebutton("btnSubmit"); }
    } catch (e) {
        MyAlert("OnDeleteClassSubjectFacultySuccess : " + e);
    }
}

function OnSearchStudentHomeWorkIndexReady() {
    try {
        CreateDatePicker("txtStartDate");
        CreateDatePicker("txtEndDate");
    } catch (e) {
        MyAlert("OnSearchStudentHomeWorkIndexReady : " + e);
    }
}

function OnSearchStudentAssignedHomeworkBegin() {
    try {
        DisplayLoader(_LOADERDIVID);
        Disablebutton("btnSubmit");
        Disablebutton("btnReset");

    } catch (e) {
        MyAlert("OnSearchStudentAssignedHomeworkBegin : " + e);
    }
}

function OnSearchStudentAssignedHomeworkSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        Enablebutton("btnSubmit");
        Enablebutton("btnReset");
        FillSuccessResultView(data, _RESULTDIVID);
    } catch (e) {
        MyAlert("OnSearchStudentAssignedHomeworkSuccess : " + e);
    }
}

function OnDashBoardReady() {
    try {
        CreateDigitalWatch();
    } catch (e) {
        MyAlert("OnDashBoardReady : " + e);
    }
}

function OnSubmitAttendanceBegin() {
    try {
        Disablebutton("btnSubmit");
        DisplayLoader(_LOADERDIVID);
    } catch (e) {
        MyAlert("OnSubmitAttendanceBegin : " + e);
    }
}

function OnSubmitAttendanceSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        if (data.code != 0) { Enablebutton("btnSubmit"); }
        FillSuccessResultMSG(data, _MESSAGEDIVID, "Attendance Submitted SuccessFully.", "Failed To Submit Please Try Again Later.");
    } catch (e) {
        MyAlert("OnSubmitAttendanceSuccess : " + e);
    }
}