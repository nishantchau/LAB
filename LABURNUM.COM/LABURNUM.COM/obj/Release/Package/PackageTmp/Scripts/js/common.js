
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
                    case 3:
                        SetHtml(modelDivId, data.result);
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
        $("#" + btnId).prop("disabled", true);
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