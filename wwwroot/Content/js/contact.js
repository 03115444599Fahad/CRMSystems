function getFormObj(formId) {
    var formElements = document.getElementById(formId).elements;
    var postData = {};
    for (var i = 0; i < formElements.length; i++) {
        if (formElements[i].type != "submit")//we dont want to include the submit-buttom
            postData[formElements[i].name] = formElements[i].value;
        if (formElements[i].type == "checkbox") {
            postData[formElements[i].name] = formElements[i].checked;
        }



    }
    return postData;
}

function SendContact() {
    $("#sendmessageDiv").show();
    var Url = "/Home/SendEmail";
    var data = getFormObj("contactForm");
    var formData = new FormData(); //create form
   
    $.ajax({
        method: "POST",
        url: Url,
        data: { Message: data.message, Name: data.name, Email: data.email, Subject: data.subject }
    }).done(function (result) {
        if (result.result) {
            $("#sendmessageDiv").show();
            
        }
        else {
            console.log(result.message)

        }

    });
}


$(document).ready(function () {
    
    (function($) {
        "use strict";

    
    jQuery.validator.addMethod('answercheck', function (value, element) {
        return this.optional(element) || /^\bcat\b$/.test(value)
    }, "type the correct answer -_-");

    // validate contactForm form
    $(function() {
        $('#contactForm').validate({
            rules: {
                name: {
                    required: true,
                    minlength: 2
                },
                subject: {
                    required: true,
                    minlength: 4
                },
                number: {
                    required: true,
                    minlength: 5
                },
                email: {
                    required: true,
                    email: true
                },
                message: {
                    required: true,
                    
                }
            },
            messages: {
                name: {
                    required: "come on, you have a name, don't you?",
                    minlength: "your name must consist of at least 2 characters"
                },
                subject: {
                    required: "come on, you have a subject, don't you?",
                    minlength: "your subject must consist of at least 4 characters"
                },
                number: {
                    required: "come on, you have a number, don't you?",
                    minlength: "your Number must consist of at least 5 characters"
                },
                email: {
                    required: "no email, no message"
                },
                message: {
                    required: "um...yea, you have to write something to send this form.",
                    minlength: "thats all? really?"
                }
            },
            submitHandler: function (form) {
        
                SendContact();
              
            }
        })
    })
        
 })(jQuery)
})