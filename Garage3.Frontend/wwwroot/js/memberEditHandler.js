class MemberEditHandler {
    #memberId;

    constructor() {
        document.querySelectorAll(".editButton").forEach(element => {

            element.addEventListener("click", (event) => this.#OnEnterModal(event));

        });

        document.getElementById("MemberEditSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));

    }


    #OnEnterModal(event) {
        event.preventDefault();

        this.#memberId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",
            url: "/Members/OnVehicleEditButton",
            data: { id: this.#memberId },
            cache: false,
            success: function (result) {

                let details = JSON.parse(result);

                
                document.getElementById("memberEditFirstName").value=details.FirstName;
                document.getElementById("memberEditSurname").value=details.Surname;
                document.getElementById("memberEditPhoneNumber").value=details.PhoneNumber;
                document.getElementById("memberEditPersonalNumber").value = details.PersonalNumber;
                document.getElementById("memberEditMembership").value = details.MembershipType;


                document.getElementById("editFailMessage").innerHTML = "";
                console.log("result is: " + result);



            }
        });


    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        
        let firstName=document.getElementById("memberEditFirstName").value;
        let surname=document.getElementById("memberEditSurname").value;
        let phoneNumber=document.getElementById("memberEditPhoneNumber").value;
        let personalNumber=document.getElementById("memberEditPersonalNumber").value;
        let membershipType=document.getElementById("memberEditMembership").value;


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Members/OnEditSave",
            data: {
                __RequestVerificationToken: token, Id: this.#memberId, firstName: firstName, surname: surname, phoneNumber: phoneNumber, personalNumber: personalNumber, membershipType: membershipType
            },
            cache: false,
            success: (result) => {

                let res = JSON.parse(result);
                document.getElementById("memberEditFailMessage").innerHTML = "is valid?:" + res.Success + " -Server:" + res.Message;
                console.log("result is: " + result)
            }
        });

    }


}
