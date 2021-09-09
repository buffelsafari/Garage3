class MemberRegisterHandler {


    constructor() {



        document.getElementById("registerMember").addEventListener("click", (event) => this.#OnEnterModal(event));
        document.getElementById("RegisterMemberSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));

    }


    #OnEnterModal(event) {
        event.preventDefault();




    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        let firstName = document.getElementById("registerFirstName").value;
        let surname = document.getElementById("registerSurname").value;
        let phoneNumber = document.getElementById("registerPhoneNumber").value;
        let personalNumber = document.getElementById("registerPersonalNumber").value;
        let membership = document.getElementById("registerMembership").value;
        


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Members/OnRegisterSave",
            data: {
                __RequestVerificationToken: token, firstName: firstName, surname:surname, phoneNumber:phoneNumber, personalNumber:personalNumber, membership:membership
            },
            cache: false,
            success: (result) => {

                let res = JSON.parse(result);
                document.getElementById("registerFailMessage").innerHTML = "is valid?:" + res.Success + " -Server:" + res.Message;
                console.log("result is: " + result)
            }
        });

    }
}