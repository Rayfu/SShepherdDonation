/// <reference path="jquery-1.10.2.min.js" />

$(function () {

    $("#ProcessTransaction").click(function () {
        $("#SecuredCardData").val($("#securefieldcode").val());
        return true;
    });

    var publicApiKey = "epk-9C8A2FB7-13FB-44AB-B1B0-A90CAF5A6813";
    var fieldStyles = "line-height: 1; height: 28px; border: 1px solid #AAA; color: #000; padding: 2px;";

    var nameFieldConfig = {
        publicApiKey: publicApiKey,
        fieldDivId: "eway-secure-field-name",
        fieldType: "name",
        styles: fieldStyles
    };
    var cardFieldConfig = {
        publicApiKey: publicApiKey,
        fieldDivId: "eway-secure-field-card",
        fieldType: "card",
        styles: fieldStyles,
        maskValues: false
    };
    var expiryFieldConfig = {
        publicApiKey: publicApiKey,
        fieldDivId: "eway-secure-field-expiry",
        fieldType: "expiry",
        styles: fieldStyles
    };
    var cvnFieldConfig = {
        publicApiKey: publicApiKey,
        fieldDivId: "eway-secure-field-cvn",
        fieldType: "cvn",
        styles: fieldStyles
    };
    function secureFieldCallback(event) {
        if (!event.fieldValid) {
            alert(event.errors);
        } else {
            // set the hidden Secure Field Code field
            var s = document.getElementById("securefieldcode");
            s.value = event.secureFieldCode
        }
    }
    //window.onload = function () {
    eWAY.setupSecureField(nameFieldConfig, secureFieldCallback);
    eWAY.setupSecureField(cardFieldConfig, secureFieldCallback);
    eWAY.setupSecureField(expiryFieldConfig, secureFieldCallback);
    eWAY.setupSecureField(cvnFieldConfig, secureFieldCallback);
})